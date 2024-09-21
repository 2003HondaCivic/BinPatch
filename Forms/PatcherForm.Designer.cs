namespace BinPatch.Forms
{
    partial class PatcherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TargetLabel = new Label();
            TargetFilePathBox = new TextBox();
            OpenTargetFileDialog = new Button();
            OpenPatchFileDialog = new Button();
            PatchFilePathBox = new TextBox();
            label1 = new Label();
            md5Check = new CheckBox();
            backupChk = new CheckBox();
            patchBttn = new Button();
            patchLogBox = new RichTextBox();
            patchProgBar = new ProgressBar();
            TargetFileDialog = new OpenFileDialog();
            PatchFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // TargetLabel
            // 
            TargetLabel.AutoSize = true;
            TargetLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            TargetLabel.Location = new Point(12, 9);
            TargetLabel.Name = "TargetLabel";
            TargetLabel.Size = new Size(129, 32);
            TargetLabel.TabIndex = 0;
            TargetLabel.Text = "Target file*";
            // 
            // TargetFilePathBox
            // 
            TargetFilePathBox.BackColor = Color.FromArgb(36, 39, 58);
            TargetFilePathBox.BorderStyle = BorderStyle.FixedSingle;
            TargetFilePathBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            TargetFilePathBox.ForeColor = Color.FromArgb(202, 211, 245);
            TargetFilePathBox.Location = new Point(137, 12);
            TargetFilePathBox.Name = "TargetFilePathBox";
            TargetFilePathBox.Size = new Size(627, 32);
            TargetFilePathBox.TabIndex = 1;
            // 
            // OpenTargetFileDialog
            // 
            OpenTargetFileDialog.FlatStyle = FlatStyle.Flat;
            OpenTargetFileDialog.Location = new Point(770, 12);
            OpenTargetFileDialog.Name = "OpenTargetFileDialog";
            OpenTargetFileDialog.Size = new Size(86, 32);
            OpenTargetFileDialog.TabIndex = 2;
            OpenTargetFileDialog.Text = "Select";
            OpenTargetFileDialog.UseVisualStyleBackColor = true;
            OpenTargetFileDialog.Click += OpenTargetFileDialog_Click;
            // 
            // OpenPatchFileDialog
            // 
            OpenPatchFileDialog.FlatStyle = FlatStyle.Flat;
            OpenPatchFileDialog.Location = new Point(770, 50);
            OpenPatchFileDialog.Name = "OpenPatchFileDialog";
            OpenPatchFileDialog.Size = new Size(86, 32);
            OpenPatchFileDialog.TabIndex = 5;
            OpenPatchFileDialog.Text = "Select";
            OpenPatchFileDialog.UseVisualStyleBackColor = true;
            OpenPatchFileDialog.Click += OpenPatchFileDialog_Click;
            // 
            // PatchFilePathBox
            // 
            PatchFilePathBox.BackColor = Color.FromArgb(36, 39, 58);
            PatchFilePathBox.BorderStyle = BorderStyle.FixedSingle;
            PatchFilePathBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PatchFilePathBox.ForeColor = Color.FromArgb(202, 211, 245);
            PatchFilePathBox.Location = new Point(137, 50);
            PatchFilePathBox.Name = "PatchFilePathBox";
            PatchFilePathBox.Size = new Size(627, 32);
            PatchFilePathBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(121, 32);
            label1.TabIndex = 3;
            label1.Text = "Patch file*";
            // 
            // md5Check
            // 
            md5Check.AutoSize = true;
            md5Check.Checked = true;
            md5Check.CheckState = CheckState.Checked;
            md5Check.FlatStyle = FlatStyle.Flat;
            md5Check.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            md5Check.Location = new Point(16, 89);
            md5Check.Name = "md5Check";
            md5Check.Size = new Size(121, 29);
            md5Check.TabIndex = 6;
            md5Check.Text = "Verify MD5";
            md5Check.UseVisualStyleBackColor = true;
            // 
            // backupChk
            // 
            backupChk.AutoSize = true;
            backupChk.Checked = true;
            backupChk.CheckState = CheckState.Checked;
            backupChk.FlatStyle = FlatStyle.Flat;
            backupChk.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            backupChk.Location = new Point(143, 89);
            backupChk.Name = "backupChk";
            backupChk.Size = new Size(190, 29);
            backupChk.TabIndex = 7;
            backupChk.Text = "Backup original file";
            backupChk.UseVisualStyleBackColor = true;
            // 
            // patchBttn
            // 
            patchBttn.FlatStyle = FlatStyle.Flat;
            patchBttn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            patchBttn.ForeColor = Color.FromArgb(166, 218, 149);
            patchBttn.Location = new Point(656, 90);
            patchBttn.Name = "patchBttn";
            patchBttn.Size = new Size(200, 32);
            patchBttn.TabIndex = 8;
            patchBttn.Text = "Patch!";
            patchBttn.UseVisualStyleBackColor = true;
            patchBttn.Click += patchBttn_Click;
            // 
            // patchLogBox
            // 
            patchLogBox.BackColor = Color.FromArgb(36, 39, 58);
            patchLogBox.BorderStyle = BorderStyle.FixedSingle;
            patchLogBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            patchLogBox.ForeColor = Color.FromArgb(202, 211, 245);
            patchLogBox.Location = new Point(12, 136);
            patchLogBox.Name = "patchLogBox";
            patchLogBox.ReadOnly = true;
            patchLogBox.Size = new Size(844, 323);
            patchLogBox.TabIndex = 9;
            patchLogBox.Text = "";
            // 
            // patchProgBar
            // 
            patchProgBar.ForeColor = Color.FromArgb(166, 218, 149);
            patchProgBar.Location = new Point(12, 465);
            patchProgBar.Name = "patchProgBar";
            patchProgBar.Size = new Size(844, 23);
            patchProgBar.TabIndex = 10;
            // 
            // TargetFileDialog
            // 
            TargetFileDialog.FileName = "*.exe";
            TargetFileDialog.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            TargetFileDialog.FileOk += TargetFileDialog_FileOk;
            // 
            // PatchFileDialog
            // 
            PatchFileDialog.FileName = "*.patch";
            PatchFileDialog.Filter = "Patch files (*.patch)|*.patch|All files (*.*)|*.*";
            PatchFileDialog.FileOk += PatchFileDialog_FileOk;
            // 
            // PatcherForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(36, 39, 58);
            ClientSize = new Size(868, 500);
            Controls.Add(patchProgBar);
            Controls.Add(patchLogBox);
            Controls.Add(patchBttn);
            Controls.Add(backupChk);
            Controls.Add(md5Check);
            Controls.Add(OpenPatchFileDialog);
            Controls.Add(PatchFilePathBox);
            Controls.Add(label1);
            Controls.Add(OpenTargetFileDialog);
            Controls.Add(TargetFilePathBox);
            Controls.Add(TargetLabel);
            ForeColor = Color.FromArgb(202, 211, 245);
            Name = "PatcherForm";
            Text = "PatcherForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TargetLabel;
        private TextBox TargetFilePathBox;
        private Button OpenTargetFileDialog;
        private Button OpenPatchFileDialog;
        private TextBox PatchFilePathBox;
        private Label label1;
        private CheckBox md5Check;
        private CheckBox backupChk;
        private Button patchBttn;
        private OpenFileDialog TargetFileDialog;
        private OpenFileDialog PatchFileDialog;
        public RichTextBox patchLogBox;
        public ProgressBar patchProgBar;
    }
}