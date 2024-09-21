using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BinPatch
{
    public class Patcher
    {
        //this only works with the new ui as of v0.1.1b despite old ui being present
        //maybe one day I will improve the flexibility or add a log/progress toggle
        #region Instance
        private static Patcher? _instance;
        private static readonly object _lock = new object();
        public static Patcher Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new Patcher();
                }
            }
        }
        #endregion Instance
        #region Version
        public string version = "0.1.1b";
        public string github = "https://github.com/2003HondaCivic/BinPatch";
        #endregion Version

        public string? targetFilePath;
        public string? patchFilePath; //not sure if I ever use these...

        public void Patch(string targetFilePath, string patchFilePath, bool md5 = true, bool backup = true)
        {
            var patcherForm = (BinPatch.Forms.PatcherForm)Application.OpenForms["PatcherForm"];
            if (!File.Exists(patchFilePath) || !File.Exists(targetFilePath))
            {
                Log("[ERROR]: Target file or patch file not found.", patcherForm);
                return;
            }

            Log($"BinPatch version {version}", patcherForm);
            Log($"BinPatch github: {github}", patcherForm);
            Log($"Thank you for using BinPatch", patcherForm);
            if (MainSettings.Default.ForceIgnoreBackups) { backup = false; }
            if (backup)
            {
                try
                {
                    File.Copy(targetFilePath, targetFilePath + ".bak");
                }
                catch
                {
                    Log($"[WARNING]: File {targetFilePath}.bak already exists. Skipping...", patcherForm);
                }
            }

            this.patchFilePath = patchFilePath;
            this.targetFilePath = targetFilePath;

            Log($"[INFO]: Reading target file...", patcherForm);

            try
            {
                File.Open(targetFilePath, FileMode.Open).Close();
                File.Open(patchFilePath, FileMode.Open).Close();
            }
            catch (IOException)
            {
                Log($"[ERROR]: One or more file(s) could not be read. Are the files locked?", patcherForm);
            }

            byte[] targetFileBytes = File.ReadAllBytes(targetFilePath);
            string[] patchFileLines = File.ReadAllLines(patchFilePath);
            string expectedMD5 = "";
            long totalBytesRemoved = 0;
            long offset = 0;
            string operationType = "";
            byte[] originalBytes = null;
            byte[] replacementBytes = null;

            Log($"[INFO]: Reading patch file and patching...", patcherForm);

            var patchOperations = new List<PatchOperation>();

            foreach (string patchLine in patchFileLines)
            {
                UpdateProgress(patcherForm, patcherForm.patchProgBar.Value + patchFileLines.Length / 100);

                if (patchLine.StartsWith("#") || string.IsNullOrWhiteSpace(patchLine)) continue;

                if (patchLine.StartsWith("MD5:"))
                {
                    expectedMD5 = patchLine.Split(':')[1].Trim();
                    string actualMD5 = CalculateMD5(targetFileBytes);

                    if (!string.Equals(expectedMD5, actualMD5, StringComparison.OrdinalIgnoreCase) && md5)
                    {
                        Log("[ERROR]: File version mismatch. Actual file MD5 does not match expected MD5.", patcherForm);
                        UpdateProgress(patcherForm, 0);
                        return;
                    }
                }
                else if (patchLine.StartsWith("Offset:"))
                {
                    offset = long.Parse(patchLine.Split(':')[1].Trim().Replace("0x", ""), NumberStyles.HexNumber);
                }
                else if (patchLine.StartsWith("Operation:"))
                {
                    operationType = patchLine.Split(':')[1].Trim();
                }
                else if (patchLine.StartsWith("TargetBytes:"))
                {
                    originalBytes = ParseHexBytes(patchLine.Split(':')[1].Trim());
                }
                else if (patchLine.StartsWith("NewBytes:"))
                {
                    replacementBytes = ParseHexBytes(patchLine.Split(':')[1].Trim());
                }

                if (!string.IsNullOrEmpty(operationType) && offset >= 0)
                {
                    patchOperations.Add(new PatchOperation
                    {
                        Offset = offset,
                        Operation = operationType,
                        TargetBytes = originalBytes,
                        NewBytes = replacementBytes
                    });

                    offset = -1;
                    operationType = "";
                    originalBytes = null;
                    replacementBytes = null;
                }
            }

            using (FileStream targetFileStream = new FileStream(targetFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                foreach (var patchOperation in patchOperations)
                {
                    long adjustedOffset = patchOperation.Offset - totalBytesRemoved;

                    switch (patchOperation.Operation)
                    {
                        case "Overwrite":
                            OverwriteBytes(targetFileStream, adjustedOffset, patchOperation.TargetBytes, patchOperation.NewBytes, patcherForm);
                            break;
                        case "Insert":
                            InsertBytes(targetFileStream, adjustedOffset, patchOperation.NewBytes, patcherForm);
                            break;
                        case "Remove":
                            RemoveBytes(targetFileStream, adjustedOffset, patchOperation.TargetBytes, patcherForm);
                            totalBytesRemoved += patchOperation.TargetBytes.Length;
                            break;
                        default:
                            Log($"[ERROR]: Unknown operation '{patchOperation.Operation}'. Please check your .patch file for errors.", patcherForm);
                            break;
                    }
                }
            }

            UpdateProgress(patcherForm, 100);
            Log("[INFO]: Patch applied successfully!", patcherForm);
        }

        class PatchOperation
        {
            public long Offset { get; set; }
            public string Operation { get; set; }
            public byte[] TargetBytes { get; set; }
            public byte[] NewBytes { get; set; }
        }

        static byte[] ParseHexBytes(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray(); //this code came to me in a dream
        }

        static void OverwriteBytes(FileStream fileStream, long offset, byte[] targetBytes, byte[] newBytes, BinPatch.Forms.PatcherForm patcherForm)
        {
            fileStream.Seek(offset, SeekOrigin.Begin);
            byte[] currentBytes = new byte[targetBytes.Length];
            fileStream.Read(currentBytes, 0, targetBytes.Length);

            if (!currentBytes.SequenceEqual(targetBytes))
            {
                Log($"[ERROR]: Target bytes do not match for Overwrite operation, aborting. Expected: {BitConverter.ToString(targetBytes)} Actual: {BitConverter.ToString(currentBytes)}", patcherForm);
                return;
            }

            fileStream.Seek(offset, SeekOrigin.Begin);
            fileStream.Write(newBytes, 0, newBytes.Length);
            Log($"[INFO]: Overwrite operation successful at offset 0x{offset:X}.", patcherForm);
        }

        static void InsertBytes(FileStream fileStream, long offset, byte[] newBytes, BinPatch.Forms.PatcherForm patcherForm)
        {
            if (offset < 0 || offset > fileStream.Length)
            {
                Log("[ERROR]: Insert offset is out of file bounds.", patcherForm);
                return;
            }

            fileStream.Seek(offset, SeekOrigin.Begin);
            byte[] remainingBytes = new byte[fileStream.Length - offset];
            fileStream.Read(remainingBytes, 0, remainingBytes.Length);

            fileStream.Seek(offset, SeekOrigin.Begin);
            fileStream.Write(newBytes, 0, newBytes.Length);
            fileStream.Write(remainingBytes, 0, remainingBytes.Length);
            Log($"[INFO]: Insert operation successful at offset 0x{offset:X}.", patcherForm);
        }

        static void RemoveBytes(FileStream fileStream, long offset, byte[] targetBytes, BinPatch.Forms.PatcherForm patcherForm)
        {
            fileStream.Seek(offset, SeekOrigin.Begin);
            byte[] currentBytes = new byte[targetBytes.Length];
            fileStream.Read(currentBytes, 0, targetBytes.Length);

            if (!currentBytes.SequenceEqual(targetBytes))
            {
                Log($"[ERROR]: Target bytes do not match for Remove operation. Expected: {BitConverter.ToString(targetBytes)} Actual: {BitConverter.ToString(currentBytes)}", patcherForm);
                return;
            }

            byte[] remainingBytes = new byte[fileStream.Length - offset - targetBytes.Length];
            fileStream.Seek(offset + targetBytes.Length, SeekOrigin.Begin);
            fileStream.Read(remainingBytes, 0, remainingBytes.Length);

            fileStream.SetLength(offset);
            fileStream.Seek(offset, SeekOrigin.Begin);
            fileStream.Write(remainingBytes, 0, remainingBytes.Length);
            Log($"[INFO]: Remove operation successful at offset 0x{offset:X}.", patcherForm);
        }

        static string CalculateMD5(byte[] fileBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(fileBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        static void Log(string message, BinPatch.Forms.PatcherForm patcherForm)
        {
            if (patcherForm.InvokeRequired)
            {
                patcherForm.Invoke(new Action(() =>
                {
                    AppendLogMessage(message, patcherForm);
                }));
            }
            else
            {
                AppendLogMessage(message, patcherForm);
            }
        }

        static void AppendLogMessage(string message, BinPatch.Forms.PatcherForm patcherForm)
        {

            patcherForm.patchLogBox.SelectionStart = patcherForm.patchLogBox.TextLength;
            patcherForm.patchLogBox.SelectionLength = 0;

         
            if (message.StartsWith("[ERROR]"))
            {
                patcherForm.patchLogBox.SelectionColor = System.Drawing.Color.FromArgb(237, 135, 150);
            }
            else if (message.StartsWith("[WARNING]")){
                patcherForm.patchLogBox.SelectionColor = System.Drawing.Color.FromArgb(238, 212, 159);
            }
            else
            {
                patcherForm.patchLogBox.SelectionColor = System.Drawing.Color.FromArgb(202, 211, 245); // Default color
            }

            
            patcherForm.patchLogBox.AppendText("\n" + message);


            patcherForm.patchLogBox.SelectionColor = patcherForm.patchLogBox.ForeColor;
        }

        static void UpdateProgress(BinPatch.Forms.PatcherForm patcherForm, int value)
        {
            if (value > 100)
            {
                value = 100;
            }
            if (patcherForm.InvokeRequired)
            {
                patcherForm.Invoke(new Action(() => patcherForm.patchProgBar.Value = value));
            }
            else
            {
                patcherForm.patchProgBar.Value = value;
            }
        }
    }
}
