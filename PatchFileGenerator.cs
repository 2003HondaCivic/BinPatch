using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BinPatch
{
    public class PatchFileGenerator
    {
        public static void GeneratePatchFile(string sourceFilePath, string targetFilePath, string patchFilePath, string author = "Placeholder", string version = "Placeholder", string description = "Placeholder", bool md5 = true)
        {
            BinPatch.Forms.PatchGenForm mainForm = (BinPatch.Forms.PatchGenForm)Application.OpenForms["PatchGenForm"];
            if (!File.Exists(sourceFilePath) || !File.Exists(targetFilePath))
            {
                Log("[ERROR]: Source file or target file not found.", mainForm);

                return;
            }

            byte[] sourceBytes = File.ReadAllBytes(sourceFilePath);
            byte[] targetBytes = File.ReadAllBytes(targetFilePath);

            if (sourceBytes == targetBytes) 
            {
                Log("[WARNING]: Files appear to be the same, continuing...", mainForm);
            }

            using (StreamWriter writer = new StreamWriter(patchFilePath))
            {
                // Writing header information
                writer.WriteLine($"# Author: {author}");
                writer.WriteLine($"# Target File: {Path.GetFileName(targetFilePath)}");
                writer.WriteLine($"# Target File Version: {version}");
                writer.WriteLine($"# Description: {description}");
                writer.WriteLine("#===================================================");
                writer.WriteLine("# BinPatch Docs & Formatting:");
                writer.WriteLine("# MD5: <md5 checksum> (optional for file version verification)");
                writer.WriteLine("# Address: <hex address>");
                writer.WriteLine("# TargetBytes: <hex bytes> (for Remove or Overwrite)");
                writer.WriteLine("# NewBytes: <hex bytes> (for Insert or Overwrite)");
                writer.WriteLine("# Operation: <Remove | Insert | Overwrite> (Must be last parameter)");
                writer.WriteLine("#===================================================");
                if (md5)
                {
                    string md5Checksum = CalculateMD5(sourceBytes, mainForm);
                    writer.WriteLine($"MD5: {md5Checksum}");
                }

                int sourceOffset = 0;
                int targetOffset = 0;

                while (sourceOffset < sourceBytes.Length || targetOffset < targetBytes.Length)
                {

                    if (sourceOffset < sourceBytes.Length && targetOffset < targetBytes.Length)
                    {
                        if (sourceBytes[sourceOffset] != targetBytes[targetOffset])
                        {
                            List<byte> removeBytes = new List<byte>();
                            List<byte> overwriteBytes = new List<byte>();
                            List<byte> newBytes = new List<byte>();


                            int startOffset = sourceOffset;

                            while (sourceOffset < sourceBytes.Length && targetOffset < targetBytes.Length && sourceBytes[sourceOffset] != targetBytes[targetOffset])
                            {
                                removeBytes.Add(sourceBytes[sourceOffset]);
                                overwriteBytes.Add(targetBytes[targetOffset]);
                                sourceOffset++;
                                targetOffset++;
                            }

                            if (overwriteBytes.Count == 0)
                            {
                                writer.WriteLine($"Offset: 0x{startOffset:X}");
                                writer.WriteLine($"TargetBytes: {BitConverter.ToString(removeBytes.ToArray()).Replace("-", "")}");
                                writer.WriteLine("Operation: Remove");
                                Log("[INFO]: Added remove operation...", mainForm);
                            }
                            else
                            {
                                writer.WriteLine($"Offset: 0x{startOffset:X}");
                                writer.WriteLine($"TargetBytes: {BitConverter.ToString(removeBytes.ToArray()).Replace("-", "")}");
                                writer.WriteLine($"NewBytes: {BitConverter.ToString(overwriteBytes.ToArray()).Replace("-", "")}");
                                writer.WriteLine("Operation: Overwrite");
                                Log("[INFO]: Added overwrite operation...", mainForm);
                            }

                            continue;
                        }
                    }


                    if (targetOffset < targetBytes.Length && sourceOffset >= sourceBytes.Length)
                    {
                        List<byte> insertBytes = new List<byte>();
                        int startOffset = targetOffset;

                        while (targetOffset < targetBytes.Length)
                        {
                            insertBytes.Add(targetBytes[targetOffset]);
                            targetOffset++;
                        }

                        writer.WriteLine($"Offset: 0x{startOffset:X}");
                        writer.WriteLine($"NewBytes: {BitConverter.ToString(insertBytes.ToArray()).Replace("-", "")}");
                        writer.WriteLine("Operation: Insert");
                        Log("[INFO]: Added insert operation...", mainForm);
                    }

                    sourceOffset++;
                    targetOffset++;
                }

                Log("[INFO]: Patch file generated successfully.", mainForm);
            }
        }

        private static string CalculateMD5(byte[] fileBytes, BinPatch.Forms.PatchGenForm mainForm)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(fileBytes);
                Log("[INFO]: Calculating MD5...", mainForm);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        static void Log(string message, BinPatch.Forms.PatchGenForm patchGenForm)
        {
            if (patchGenForm.InvokeRequired)
            {
                patchGenForm.Invoke(new Action(() =>
                {
                    AppendLogMessage(message, patchGenForm);
                }));
            }
            else
            {
                AppendLogMessage(message, patchGenForm);
            }
        }

        static void AppendLogMessage(string message, BinPatch.Forms.PatchGenForm patchGenForm)
        {

            patchGenForm.GenLogBox.SelectionStart = patchGenForm.GenLogBox.TextLength;
            patchGenForm.GenLogBox.SelectionLength = 0;


            if (message.StartsWith("[ERROR]"))
            {
                patchGenForm.GenLogBox.SelectionColor = System.Drawing.Color.FromArgb(237, 135, 150); 
            }
            else if (message.StartsWith("[WARNING]"))
            {
                patchGenForm.GenLogBox.SelectionColor = System.Drawing.Color.FromArgb(238, 212, 159); 
            }
            else
            {
                patchGenForm.GenLogBox.SelectionColor = System.Drawing.Color.FromArgb(202, 211, 245); 
            }


            patchGenForm.GenLogBox.AppendText("\n" + message);


            patchGenForm.GenLogBox.SelectionColor = patchGenForm.GenLogBox.ForeColor;
        }
    }
}
