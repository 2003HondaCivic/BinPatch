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
        #region Instance
        private static Patcher? _instance;
        private static readonly object _lock = new object();
        public static Patcher Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Patcher();
                    }
                    return _instance;
                }
            }
        }
        #endregion Instance

        #region VersionInfo
        string version = "0.0.1b";
        string github = "TBD";
        #endregion VersionInfo

        public string? targetFilePath;
        public string? patchFilePath;

        public void Patch(string targetFilePath, string patchFilePath)
        {
            File.Copy(targetFilePath, targetFilePath + ".bak");
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
            SafeLog($"BinPatch version {version}", mainForm);
            SafeLog($"BinPatch github: {github}", mainForm);
            SafeLog($"Thank you for using BinPatch", mainForm);

            this.patchFilePath = patchFilePath;
            this.targetFilePath = targetFilePath;

            if (!File.Exists(patchFilePath) || !File.Exists(targetFilePath))
            {
                SafeLog("ERROR: Target file or patch file not found.", mainForm);
                return;
            }

            SafeLog($"INFO: Reading target file...", mainForm);

            try
            {
                
                var dummy = File.Open(targetFilePath, FileMode.Open);
                dummy.Close();
                dummy = File.Open(patchFilePath, FileMode.Open);
                dummy.Close();
                dummy = null;
            }
            catch (IOException ex)
            {
                SafeLog($"ERROR: One or more file(s) could not be read. Are the files locked?", mainForm);
            }
            byte[] targetBytes = File.ReadAllBytes(targetFilePath);
            string[] patchOperations = File.ReadAllLines(patchFilePath);
            string expectedMD5 = "";
            long totalBytesRemoved = 0;
            long offset = 0;
            string operation = "";
            byte[] orgBytes = null;
            byte[] newBytes = null;

            SafeUpdateProgress(mainForm, 10);
            SafeLog($"INFO: Reading patch file and patching...", mainForm);

            var operations = new List<PatchOperation>();

            foreach (string line in patchOperations)
            {
                SafeUpdateProgress(mainForm, mainForm.MainProgressBar.Value + patchOperations.Length / 90);

                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("MD5:"))
                {
                    expectedMD5 = line.Split(':')[1].Trim();
                    string actualMD5 = CalculateMD5(targetBytes);

                    if (!string.Equals(expectedMD5, actualMD5, StringComparison.OrdinalIgnoreCase))
                    {
                        SafeLog("ERROR: File version mismatch. Actual file MD5 does not match expected MD5.", mainForm);
                        SafeUpdateProgress(mainForm, 0);
                        return;
                    }
                }
                else if (line.StartsWith("Offset:"))
                {
                    offset = long.Parse(line.Split(':')[1].Trim().Replace("0x", ""), NumberStyles.HexNumber);
                }
                else if (line.StartsWith("Operation:"))
                {
                    operation = line.Split(':')[1].Trim();
                }
                else if (line.StartsWith("TargetBytes:"))
                {
                    orgBytes = ParseHexBytes(line.Split(':')[1].Trim());
                }
                else if (line.StartsWith("NewBytes:"))
                {
                    newBytes = ParseHexBytes(line.Split(':')[1].Trim());
                }

                if (!string.IsNullOrEmpty(operation) && offset >= 0)
                {
                    operations.Add(new PatchOperation
                    {
                        Offset = offset,
                        Operation = operation,
                        TargetBytes = orgBytes,
                        NewBytes = newBytes
                    });

                    offset = -1;
                    operation = "";
                    orgBytes = null;
                    newBytes = null;
                }
            }


            using (FileStream fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                foreach (var patchOperation in operations)
                {

                    long adjustedOffset = patchOperation.Offset - totalBytesRemoved;

                    switch (patchOperation.Operation)
                    {
                        case "Overwrite":
                            OverwriteBytes(fs, adjustedOffset, patchOperation.TargetBytes, patchOperation.NewBytes, mainForm);
                            break;
                        case "Insert":
                            InsertBytes(fs, adjustedOffset, patchOperation.NewBytes, mainForm);
                            break;
                        case "Remove":
                            RemoveBytes(fs, adjustedOffset, patchOperation.TargetBytes, mainForm);
                            totalBytesRemoved += patchOperation.TargetBytes.Length; 
                            break;
                        default:
                            SafeLog($"ERROR: Unknown operation '{patchOperation.Operation}'. Please check your .patch file for errors.", mainForm);
                            break;
                    }
                }
            }

            SafeUpdateProgress(mainForm, 100);
            SafeLog("Patch applied successfully!", mainForm);
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
                             .ToArray();
        }

        static void OverwriteBytes(FileStream fs, long offset, byte[] targetBytes, byte[] newBytes, MainForm mainForm)
        {
            fs.Seek(offset, SeekOrigin.Begin);

            byte[] currentBytes = new byte[targetBytes.Length];
            fs.Read(currentBytes, 0, targetBytes.Length);

            if (!currentBytes.SequenceEqual(targetBytes))
            {
                SafeLog($"ERROR: Target bytes do not match for Overwrite operation, aborting. Expected: {BitConverter.ToString(targetBytes)} Actual: {BitConverter.ToString(currentBytes)}", mainForm);
                
                return;
            }

            fs.Seek(offset, SeekOrigin.Begin);
            fs.Write(newBytes, 0, newBytes.Length);
            SafeLog($"INFO: Overwrite operation successful at offset 0x{offset:X}.", mainForm);
        }

        static void InsertBytes(FileStream fs, long offset, byte[] newBytes, MainForm mainForm)
        {
            if (offset < 0 || offset > fs.Length)
            {
                SafeLog("ERROR: Insert offset is out of file bounds.", mainForm);
                return;
            }

            fs.Seek(offset, SeekOrigin.Begin);
            byte[] remainingBytes = new byte[fs.Length - offset];
            fs.Read(remainingBytes, 0, remainingBytes.Length);

            fs.Seek(offset, SeekOrigin.Begin);
            fs.Write(newBytes, 0, newBytes.Length);
            fs.Write(remainingBytes, 0, remainingBytes.Length);
            SafeLog($"INFO: Insert operation successful at offset 0x{offset:X}.", mainForm);
        }

        static void RemoveBytes(FileStream fs, long offset, byte[] targetBytes, MainForm mainForm)
        {
            fs.Seek(offset, SeekOrigin.Begin);

            byte[] currentBytes = new byte[targetBytes.Length];
            fs.Read(currentBytes, 0, targetBytes.Length);

            if (!currentBytes.SequenceEqual(targetBytes))
            {
                SafeLog($"ERROR: Target bytes do not match for Remove operation. Expected: {BitConverter.ToString(targetBytes)} Actual: {BitConverter.ToString(currentBytes)}", mainForm);
                return;
            }

            byte[] remainingBytes = new byte[fs.Length - offset - targetBytes.Length];
            fs.Seek(offset + targetBytes.Length, SeekOrigin.Begin);
            fs.Read(remainingBytes, 0, remainingBytes.Length);

            fs.SetLength(offset);
            fs.Seek(offset, SeekOrigin.Begin);

            fs.Write(remainingBytes, 0, remainingBytes.Length);
            SafeLog($"INFO: Remove operation successful at offset 0x{offset:X}.", mainForm);
        }

        static string CalculateMD5(byte[] fileBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(fileBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        static void SafeLog(string message, MainForm mainForm)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.logBox.AppendText("\n" + message)));
            }
            else
            {
                mainForm.logBox.AppendText("\n" + message);
            }
        }

        static void SafeUpdateProgress(MainForm mainForm, int value)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.MainProgressBar.Value = value));
            }
            else
            {
                mainForm.MainProgressBar.Value = value;
            }
        }

    }
}
