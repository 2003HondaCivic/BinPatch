using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinPatch.Forms
{
    public partial class PatchGenForm : Form
    {
        public PatchGenForm()
        {
            InitializeComponent();
        }

        private void OrgFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OrgFilePathBox.Text = OrgFileDialog.FileName;
        }

        private void ModFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            ModFilePathBox.Text = ModFileDialog.FileName;
        }

        private void OpenTargetFileDialog_Click(object sender, EventArgs e)
        {
            OrgFileDialog.ShowDialog();
        }

        private void OpenModFileDialog_Click(object sender, EventArgs e)
        {
            ModFileDialog.ShowDialog();
        }

        private async void GenPatchBttn_Click(object sender, EventArgs e)
        {
            GenLogBox.Text = "";
            GenLogBox.AppendText($"Patch generator starting at {DateTime.Now.ToString("hh:mm:ss")}");
            if (String.IsNullOrEmpty(ModFilePathBox.Text) || String.IsNullOrEmpty(OrgFilePathBox.Text))
            {
                GenLogBox.SelectionColor = Color.FromArgb(237, 135, 150);
                GenLogBox.AppendText("\n[ERROR]: Please supply your original file path and the modified file path");
                GenLogBox.SelectionColor = Color.FromArgb(202, 211, 245);
                GenLogBox.AppendText($"\nPatch generator finished at {DateTime.Now.ToString("hh:mm:ss")}");
                return;
            }
            if (String.IsNullOrEmpty(PatchNameBox.Text)) { PatchNameBox.Text = "New Patch"; }
            string patchFilePath = (System.IO.Directory.GetCurrentDirectory() + $@"\{PatchNameBox.Text}.patch");
            bool md5override = md5Check.Checked;
            if (MainSettings.Default.ForceIgnoreMD5)
            {
                md5override = false;
            }

            Task Generate = new Task(() =>
            {
                PatchFileGenerator.GeneratePatchFile(OrgFilePathBox.Text, ModFilePathBox.Text, patchFilePath, AuthorBox.Text, VersionBox.Text, DescBox.Text);
            });
            Generate.Start();
            await Generate;
            GenLogBox.AppendText($"\nPatch generator finished at {DateTime.Now.ToString("hh:mm:ss")}");
        }

        private void PatchGenForm_Load(object sender, EventArgs e)
        {
            if (MainSettings.Default.UseSameAuthor)
            {
                AuthorBox.Text = MainSettings.Default.AuthorName;
            }
        }
    }
}
