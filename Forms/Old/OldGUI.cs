using System.Security.Cryptography.X509Certificates;

namespace BinPatch
{
    public partial class PatcherForm : Form
    {
        public static PatcherForm Instance;
        public PatcherForm()
        {

            InitializeComponent();
        }

        private void OpenTargetFileDialogBttn_Click(object sender, EventArgs e)
        {
            TargetFileDialog.ShowDialog();
        }

        private void OpenPatchFileDialogBttn_Click(object sender, EventArgs e)
        {
            PatchFileDialog.ShowDialog();
        }

        private void TargetFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TargetPathBox.Text = TargetFileDialog.FileName;
        }

        private void PatchFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PatchPathBox.Text = PatchFileDialog.FileName;
        }

        private async void PatchBttn_Click(object sender, EventArgs e)
        {
            logBox.Text = "";
            logBox.AppendText($"Patcher starting at {DateTime.Now.ToString("hh:mm:ss")}");
            Task Patch = new Task(() =>
            {
                Patcher.Instance.Patch(TargetPathBox.Text, PatchPathBox.Text);
            });

            Patch.Start();
            await Patch;
            logBox.AppendText("\n" + $"Patcher finished at {DateTime.Now.ToString("hh:mm:ss")}");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void OpenOrgFileDialogBttn_Click(object sender, EventArgs e)
        {
            OrgFileDialog.ShowDialog();
        }

        private void OpenModFileDialogBttn_Click(object sender, EventArgs e)
        {
            ModFileDialog.ShowDialog();
        }

        private void OrgFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OGFilePathBox.Text = OrgFileDialog.FileName;
        }

        private void ModFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ModFilePathBox.Text = ModFileDialog.FileName;
        }

        private async void GeneratePatchBttn_Click(object sender, EventArgs e)
        {
            GenLogBox.Text = "";
            GenLogBox.AppendText($"Patch generator starting at {DateTime.Now.ToString("hh:mm:ss")}");
            if (String.IsNullOrEmpty(ModFilePathBox.Text) || String.IsNullOrEmpty(OGFilePathBox.Text))
            {
                GenLogBox.AppendText("ERROR: Please supply your original file path and the modified file path");
                return;
            }
            string patchFilePath = (System.IO.Directory.GetCurrentDirectory()+@"\New Patch.patch");
            Task Generate = new Task(() =>
            {
                PatchFileGenerator.GeneratePatchFile(OGFilePathBox.Text, ModFilePathBox.Text, patchFilePath, AuthorBox.Text, OrgFileVersionBox.Text, DescriptionBox.Text);
            });
            Generate.Start();
            await Generate;
            GenLogBox.AppendText($"Patch generator finished at {DateTime.Now.ToString("hh:mm:ss")}");

        }
    }
}
