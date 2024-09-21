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
    public partial class PatcherForm : Form
    {
        public PatcherForm()
        {
            InitializeComponent();

        }

        private void TargetFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TargetFilePathBox.Text = TargetFileDialog.FileName;
        }

        private void PatchFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            PatchFilePathBox.Text = PatchFileDialog.FileName;
        }

        private void OpenTargetFileDialog_Click(object sender, EventArgs e)
        {
            TargetFileDialog.ShowDialog();
        }

        private void OpenPatchFileDialog_Click(object sender, EventArgs e)
        {
            
            PatchFileDialog.ShowDialog();
        }

        private async void patchBttn_Click(object sender, EventArgs e)

        {
            patchProgBar.Value = 0;
            patchLogBox.Text = "";
            patchLogBox.AppendText($"Patcher starting at {DateTime.Now.ToString("hh:mm:ss")}");
            bool md5override = md5Check.Checked;
            if (MainSettings.Default.ForceIgnoreMD5)
            {
                md5override = false;
            }
            Task Patch = new Task(() =>
            {
                Patcher.Instance.Patch(TargetFilePathBox.Text, PatchFilePathBox.Text,md5Check.Checked, backupChk.Checked);
            });

            Patch.Start();
            await Patch;
            patchLogBox.AppendText($"\nPatcher finished at {DateTime.Now.ToString("hh:mm:ss")}");

        }
    }
}
