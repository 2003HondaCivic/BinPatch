using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BinPatch
{
    public class PatchFileGenerator
    {
        public static void GeneratePatchFile(string sourceFilePath, string targetFilePath, string patchFilePath, string author = "Placeholder", string version = "Placeholder", string description = "Placeholder")
        {
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
            if (!File.Exists(sourceFilePath) || !File.Exists(targetFilePath))
            {
                SafeLog("ERROR: Source file or target file not found.", mainForm);

                return;
            }

            byte[] sourceBytes = File.ReadAllBytes(sourceFilePath);
            byte[] targetBytes = File.ReadAllBytes(targetFilePath);
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

                string md5Checksum = CalculateMD5(sourceBytes, mainForm);
                writer.WriteLine($"MD5: {md5Checksum}");

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
                                SafeLog("Added remove operation...", mainForm);
                            }
                            else
                            {
                                writer.WriteLine($"Offset: 0x{startOffset:X}");
                                writer.WriteLine($"TargetBytes: {BitConverter.ToString(removeBytes.ToArray()).Replace("-", "")}");
                                writer.WriteLine($"NewBytes: {BitConverter.ToString(overwriteBytes.ToArray()).Replace("-", "")}");
                                writer.WriteLine("Operation: Overwrite");
                                SafeLog("Added overwrite operation...", mainForm);
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
                        SafeLog("Added insert operation...", mainForm);
                    }

                    sourceOffset++;
                    targetOffset++;
                }

                SafeLog("Patch file generated successfully.", mainForm);
            }
        }

        private static string CalculateMD5(byte[] fileBytes, MainForm mainForm)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(fileBytes);
                SafeLog("Calculating MD5...", mainForm);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        static void SafeLog(string message, MainForm mainForm)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.GenLogBox.AppendText("\n" + message)));
            }
            else
            {
                mainForm.GenLogBox.AppendText("\n" + message);
            }
        }
    }
}
