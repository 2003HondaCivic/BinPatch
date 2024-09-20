namespace BinPatch
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            logBox = new RichTextBox();
            TargetPathBox = new TextBox();
            PatchPathBox = new TextBox();
            TargetFileDialog = new OpenFileDialog();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            openFileDialog3 = new OpenFileDialog();
            openFileDialog4 = new OpenFileDialog();
            openFileDialog5 = new OpenFileDialog();
            PatchFileDialog = new OpenFileDialog();
            OpenTargetFileDialogBttn = new Button();
            OpenPatchFileDialogBttn = new Button();
            TFileLabel = new Label();
            PFileLabel = new Label();
            PatchBttn = new Button();
            MainProgressBar = new ProgressBar();
            PatcherTitleLabel = new Label();
            label1 = new Label();
            GeneratePatchBttn = new Button();
            ModFileLabel = new Label();
            OGFileLabel = new Label();
            OpenModFileDialogBttn = new Button();
            OpenOrgFileDialogBttn = new Button();
            ModFilePathBox = new TextBox();
            OGFilePathBox = new TextBox();
            AuthorLabel = new Label();
            AuthorBox = new TextBox();
            OrgFileLabel = new Label();
            OrgFileVersionBox = new TextBox();
            DescriptionLabel = new Label();
            DescriptionBox = new TextBox();
            GenLogBox = new RichTextBox();
            OrgFileDialog = new OpenFileDialog();
            ModFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // logBox
            // 
            logBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            logBox.Location = new Point(8, 158);
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(874, 381);
            logBox.TabIndex = 0;
            logBox.Text = "";
            // 
            // TargetPathBox
            // 
            TargetPathBox.Location = new Point(8, 75);
            TargetPathBox.Name = "TargetPathBox";
            TargetPathBox.Size = new Size(759, 23);
            TargetPathBox.TabIndex = 1;
            // 
            // PatchPathBox
            // 
            PatchPathBox.Location = new Point(8, 129);
            PatchPathBox.Name = "PatchPathBox";
            PatchPathBox.Size = new Size(759, 23);
            PatchPathBox.TabIndex = 2;
            // 
            // TargetFileDialog
            // 
            TargetFileDialog.FileName = "*.exe";
            TargetFileDialog.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            TargetFileDialog.FileOk += TargetFileDialog_FileOk;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "*.exe";
            openFileDialog1.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "*.exe";
            openFileDialog2.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "*.exe";
            openFileDialog3.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            // 
            // openFileDialog4
            // 
            openFileDialog4.FileName = "*.exe";
            openFileDialog4.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            // 
            // openFileDialog5
            // 
            openFileDialog5.FileName = "*.exe";
            openFileDialog5.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            // 
            // PatchFileDialog
            // 
            PatchFileDialog.FileName = "*.patch";
            PatchFileDialog.Filter = "Patch files (*.patch)|*.patch|All files (*.*)|*.*";
            PatchFileDialog.FileOk += PatchFileDialog_FileOk;
            // 
            // OpenTargetFileDialogBttn
            // 
            OpenTargetFileDialogBttn.Location = new Point(773, 74);
            OpenTargetFileDialogBttn.Name = "OpenTargetFileDialogBttn";
            OpenTargetFileDialogBttn.Size = new Size(29, 23);
            OpenTargetFileDialogBttn.TabIndex = 3;
            OpenTargetFileDialogBttn.Text = "...";
            OpenTargetFileDialogBttn.UseVisualStyleBackColor = true;
            OpenTargetFileDialogBttn.Click += OpenTargetFileDialogBttn_Click;
            // 
            // OpenPatchFileDialogBttn
            // 
            OpenPatchFileDialogBttn.Location = new Point(773, 128);
            OpenPatchFileDialogBttn.Name = "OpenPatchFileDialogBttn";
            OpenPatchFileDialogBttn.Size = new Size(29, 23);
            OpenPatchFileDialogBttn.TabIndex = 4;
            OpenPatchFileDialogBttn.Text = "...";
            OpenPatchFileDialogBttn.UseVisualStyleBackColor = true;
            OpenPatchFileDialogBttn.Click += OpenPatchFileDialogBttn_Click;
            // 
            // TFileLabel
            // 
            TFileLabel.AutoSize = true;
            TFileLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TFileLabel.Location = new Point(8, 47);
            TFileLabel.Name = "TFileLabel";
            TFileLabel.Size = new Size(95, 25);
            TFileLabel.TabIndex = 5;
            TFileLabel.Text = "Target file";
            // 
            // PFileLabel
            // 
            PFileLabel.AutoSize = true;
            PFileLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PFileLabel.Location = new Point(8, 101);
            PFileLabel.Name = "PFileLabel";
            PFileLabel.Size = new Size(89, 25);
            PFileLabel.TabIndex = 6;
            PFileLabel.Text = "Patch file";
            // 
            // PatchBttn
            // 
            PatchBttn.ForeColor = Color.Green;
            PatchBttn.Location = new Point(808, 116);
            PatchBttn.Name = "PatchBttn";
            PatchBttn.Size = new Size(74, 36);
            PatchBttn.TabIndex = 7;
            PatchBttn.Text = "Patch!";
            PatchBttn.UseVisualStyleBackColor = true;
            PatchBttn.Click += PatchBttn_Click;
            // 
            // MainProgressBar
            // 
            MainProgressBar.Location = new Point(8, 545);
            MainProgressBar.Name = "MainProgressBar";
            MainProgressBar.Size = new Size(874, 23);
            MainProgressBar.TabIndex = 8;
            // 
            // PatcherTitleLabel
            // 
            PatcherTitleLabel.AutoSize = true;
            PatcherTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            PatcherTitleLabel.Location = new Point(8, 9);
            PatcherTitleLabel.Name = "PatcherTitleLabel";
            PatcherTitleLabel.Size = new Size(99, 32);
            PatcherTitleLabel.TabIndex = 9;
            PatcherTitleLabel.Text = "Patcher";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(8, 584);
            label1.Name = "label1";
            label1.Size = new Size(244, 32);
            label1.TabIndex = 10;
            label1.Text = "Patch File Generator";
            // 
            // GeneratePatchBttn
            // 
            GeneratePatchBttn.ForeColor = Color.Green;
            GeneratePatchBttn.Location = new Point(773, 815);
            GeneratePatchBttn.Name = "GeneratePatchBttn";
            GeneratePatchBttn.Size = new Size(109, 36);
            GeneratePatchBttn.TabIndex = 17;
            GeneratePatchBttn.Text = "Generate";
            GeneratePatchBttn.UseVisualStyleBackColor = true;
            GeneratePatchBttn.Click += GeneratePatchBttn_Click;
            // 
            // ModFileLabel
            // 
            ModFileLabel.AutoSize = true;
            ModFileLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ModFileLabel.Location = new Point(8, 670);
            ModFileLabel.Name = "ModFileLabel";
            ModFileLabel.Size = new Size(127, 25);
            ModFileLabel.TabIndex = 16;
            ModFileLabel.Text = "Modified file*";
            // 
            // OGFileLabel
            // 
            OGFileLabel.AutoSize = true;
            OGFileLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            OGFileLabel.Location = new Point(8, 616);
            OGFileLabel.Name = "OGFileLabel";
            OGFileLabel.Size = new Size(119, 25);
            OGFileLabel.TabIndex = 15;
            OGFileLabel.Text = "Original file*";
            // 
            // OpenModFileDialogBttn
            // 
            OpenModFileDialogBttn.Location = new Point(773, 697);
            OpenModFileDialogBttn.Name = "OpenModFileDialogBttn";
            OpenModFileDialogBttn.Size = new Size(29, 23);
            OpenModFileDialogBttn.TabIndex = 14;
            OpenModFileDialogBttn.Text = "...";
            OpenModFileDialogBttn.UseVisualStyleBackColor = true;
            OpenModFileDialogBttn.Click += OpenModFileDialogBttn_Click;
            // 
            // OpenOrgFileDialogBttn
            // 
            OpenOrgFileDialogBttn.Location = new Point(773, 643);
            OpenOrgFileDialogBttn.Name = "OpenOrgFileDialogBttn";
            OpenOrgFileDialogBttn.Size = new Size(29, 23);
            OpenOrgFileDialogBttn.TabIndex = 13;
            OpenOrgFileDialogBttn.Text = "...";
            OpenOrgFileDialogBttn.UseVisualStyleBackColor = true;
            OpenOrgFileDialogBttn.Click += OpenOrgFileDialogBttn_Click;
            // 
            // ModFilePathBox
            // 
            ModFilePathBox.Location = new Point(8, 698);
            ModFilePathBox.Name = "ModFilePathBox";
            ModFilePathBox.Size = new Size(759, 23);
            ModFilePathBox.TabIndex = 12;
            // 
            // OGFilePathBox
            // 
            OGFilePathBox.Location = new Point(8, 644);
            OGFilePathBox.Name = "OGFilePathBox";
            OGFilePathBox.Size = new Size(759, 23);
            OGFilePathBox.TabIndex = 11;
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            AuthorLabel.Location = new Point(8, 735);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(70, 25);
            AuthorLabel.TabIndex = 19;
            AuthorLabel.Text = "Author";
            // 
            // AuthorBox
            // 
            AuthorBox.Location = new Point(8, 763);
            AuthorBox.Name = "AuthorBox";
            AuthorBox.Size = new Size(393, 23);
            AuthorBox.TabIndex = 18;
            // 
            // OrgFileLabel
            // 
            OrgFileLabel.AutoSize = true;
            OrgFileLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            OrgFileLabel.Location = new Point(414, 735);
            OrgFileLabel.Name = "OrgFileLabel";
            OrgFileLabel.Size = new Size(177, 25);
            OrgFileLabel.TabIndex = 21;
            OrgFileLabel.Text = "Original file version";
            // 
            // OrgFileVersionBox
            // 
            OrgFileVersionBox.Location = new Point(414, 763);
            OrgFileVersionBox.Name = "OrgFileVersionBox";
            OrgFileVersionBox.Size = new Size(353, 23);
            OrgFileVersionBox.TabIndex = 20;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLabel.Location = new Point(8, 800);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(108, 25);
            DescriptionLabel.TabIndex = 23;
            DescriptionLabel.Text = "Description";
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(8, 828);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(759, 23);
            DescriptionBox.TabIndex = 22;
            // 
            // GenLogBox
            // 
            GenLogBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GenLogBox.Location = new Point(8, 868);
            GenLogBox.Name = "GenLogBox";
            GenLogBox.ReadOnly = true;
            GenLogBox.Size = new Size(874, 345);
            GenLogBox.TabIndex = 24;
            GenLogBox.Text = "";
            // 
            // OrgFileDialog
            // 
            OrgFileDialog.FileName = "*.exe";
            OrgFileDialog.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            OrgFileDialog.FileOk += OrgFileDialog_FileOk;
            // 
            // ModFileDialog
            // 
            ModFileDialog.FileName = "*.exe";
            ModFileDialog.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            ModFileDialog.FileOk += ModFileDialog_FileOk;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 1225);
            Controls.Add(GenLogBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(DescriptionBox);
            Controls.Add(OrgFileLabel);
            Controls.Add(OrgFileVersionBox);
            Controls.Add(AuthorLabel);
            Controls.Add(AuthorBox);
            Controls.Add(GeneratePatchBttn);
            Controls.Add(ModFileLabel);
            Controls.Add(OGFileLabel);
            Controls.Add(OpenModFileDialogBttn);
            Controls.Add(OpenOrgFileDialogBttn);
            Controls.Add(ModFilePathBox);
            Controls.Add(OGFilePathBox);
            Controls.Add(label1);
            Controls.Add(PatcherTitleLabel);
            Controls.Add(MainProgressBar);
            Controls.Add(PatchBttn);
            Controls.Add(PFileLabel);
            Controls.Add(TFileLabel);
            Controls.Add(OpenPatchFileDialogBttn);
            Controls.Add(OpenTargetFileDialogBttn);
            Controls.Add(PatchPathBox);
            Controls.Add(TargetPathBox);
            Controls.Add(logBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "BinPatch";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TargetPathBox;
        private TextBox PatchPathBox;
        private OpenFileDialog TargetFileDialog;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private OpenFileDialog openFileDialog4;
        private OpenFileDialog openFileDialog5;
        private OpenFileDialog PatchFileDialog;
        private Button OpenTargetFileDialogBttn;
        private Button OpenPatchFileDialogBttn;
        private Label TFileLabel;
        private Label PFileLabel;
        private Button PatchBttn;
        public RichTextBox logBox;
        public ProgressBar MainProgressBar;
        private Label PatcherTitleLabel;
        private Label label1;
        private Button GeneratePatchBttn;
        private Label ModFileLabel;
        private Label OGFileLabel;
        private Button OpenModFileDialogBttn;
        private Button OpenOrgFileDialogBttn;
        private TextBox ModFilePathBox;
        private TextBox OGFilePathBox;
        private Label AuthorLabel;
        private TextBox AuthorBox;
        private Label OrgFileLabel;
        private TextBox OrgFileVersionBox;
        private Label DescriptionLabel;
        private TextBox DescriptionBox;
        public RichTextBox GenLogBox;
        private OpenFileDialog OrgFileDialog;
        private OpenFileDialog ModFileDialog;
    }
}
