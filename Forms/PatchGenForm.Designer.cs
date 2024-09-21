namespace BinPatch.Forms
{
    partial class PatchGenForm
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
            GenPatchBttn = new Button();
            md5Check = new CheckBox();
            OpenModFileDialog = new Button();
            ModFilePathBox = new TextBox();
            label1 = new Label();
            OpenTargetFileDialog = new Button();
            OrgFilePathBox = new TextBox();
            OrgFileLabel = new Label();
            AuthorBox = new TextBox();
            label2 = new Label();
            VersionBox = new TextBox();
            label3 = new Label();
            DescBox = new TextBox();
            label4 = new Label();
            GenLogBox = new RichTextBox();
            ModFileDialog = new OpenFileDialog();
            OrgFileDialog = new OpenFileDialog();
            PatchNameBox = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // GenPatchBttn
            // 
            GenPatchBttn.FlatStyle = FlatStyle.Flat;
            GenPatchBttn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            GenPatchBttn.ForeColor = Color.FromArgb(166, 218, 149);
            GenPatchBttn.Location = new Point(656, 164);
            GenPatchBttn.Name = "GenPatchBttn";
            GenPatchBttn.Size = new Size(200, 32);
            GenPatchBttn.TabIndex = 17;
            GenPatchBttn.Text = "Generate Patch!";
            GenPatchBttn.UseVisualStyleBackColor = true;
            GenPatchBttn.Click += GenPatchBttn_Click;
            // 
            // md5Check
            // 
            md5Check.AutoSize = true;
            md5Check.Checked = true;
            md5Check.CheckState = CheckState.Checked;
            md5Check.FlatStyle = FlatStyle.Flat;
            md5Check.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            md5Check.Location = new Point(462, 167);
            md5Check.Name = "md5Check";
            md5Check.Size = new Size(188, 29);
            md5Check.TabIndex = 15;
            md5Check.Text = "Include MD5 check";
            md5Check.UseVisualStyleBackColor = true;
            // 
            // OpenModFileDialog
            // 
            OpenModFileDialog.FlatStyle = FlatStyle.Flat;
            OpenModFileDialog.Location = new Point(770, 50);
            OpenModFileDialog.Name = "OpenModFileDialog";
            OpenModFileDialog.Size = new Size(86, 32);
            OpenModFileDialog.TabIndex = 14;
            OpenModFileDialog.Text = "Select";
            OpenModFileDialog.UseVisualStyleBackColor = true;
            OpenModFileDialog.Click += OpenModFileDialog_Click;
            // 
            // ModFilePathBox
            // 
            ModFilePathBox.BackColor = Color.FromArgb(36, 39, 58);
            ModFilePathBox.BorderStyle = BorderStyle.FixedSingle;
            ModFilePathBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ModFilePathBox.ForeColor = Color.FromArgb(202, 211, 245);
            ModFilePathBox.Location = new Point(169, 50);
            ModFilePathBox.Name = "ModFilePathBox";
            ModFilePathBox.Size = new Size(595, 32);
            ModFilePathBox.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(161, 32);
            label1.TabIndex = 12;
            label1.Text = "Modified file*";
            // 
            // OpenTargetFileDialog
            // 
            OpenTargetFileDialog.FlatStyle = FlatStyle.Flat;
            OpenTargetFileDialog.Location = new Point(770, 12);
            OpenTargetFileDialog.Name = "OpenTargetFileDialog";
            OpenTargetFileDialog.Size = new Size(86, 32);
            OpenTargetFileDialog.TabIndex = 11;
            OpenTargetFileDialog.Text = "Select";
            OpenTargetFileDialog.UseVisualStyleBackColor = true;
            OpenTargetFileDialog.Click += OpenTargetFileDialog_Click;
            // 
            // OrgFilePathBox
            // 
            OrgFilePathBox.BackColor = Color.FromArgb(36, 39, 58);
            OrgFilePathBox.BorderStyle = BorderStyle.FixedSingle;
            OrgFilePathBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            OrgFilePathBox.ForeColor = Color.FromArgb(202, 211, 245);
            OrgFilePathBox.Location = new Point(169, 12);
            OrgFilePathBox.Name = "OrgFilePathBox";
            OrgFilePathBox.Size = new Size(595, 32);
            OrgFilePathBox.TabIndex = 10;
            // 
            // OrgFileLabel
            // 
            OrgFileLabel.AutoSize = true;
            OrgFileLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            OrgFileLabel.Location = new Point(12, 9);
            OrgFileLabel.Name = "OrgFileLabel";
            OrgFileLabel.Size = new Size(148, 32);
            OrgFileLabel.TabIndex = 9;
            OrgFileLabel.Text = "Original file*";
            // 
            // AuthorBox
            // 
            AuthorBox.BackColor = Color.FromArgb(36, 39, 58);
            AuthorBox.BorderStyle = BorderStyle.FixedSingle;
            AuthorBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            AuthorBox.ForeColor = Color.FromArgb(202, 211, 245);
            AuthorBox.Location = new Point(169, 88);
            AuthorBox.Name = "AuthorBox";
            AuthorBox.Size = new Size(292, 32);
            AuthorBox.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(154, 32);
            label2.TabIndex = 18;
            label2.Text = "Author name";
            // 
            // VersionBox
            // 
            VersionBox.BackColor = Color.FromArgb(36, 39, 58);
            VersionBox.BorderStyle = BorderStyle.FixedSingle;
            VersionBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            VersionBox.ForeColor = Color.FromArgb(202, 211, 245);
            VersionBox.Location = new Point(638, 88);
            VersionBox.Name = "VersionBox";
            VersionBox.Size = new Size(218, 32);
            VersionBox.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(481, 85);
            label3.Name = "label3";
            label3.Size = new Size(135, 32);
            label3.TabIndex = 20;
            label3.Text = "File version";
            // 
            // DescBox
            // 
            DescBox.BackColor = Color.FromArgb(36, 39, 58);
            DescBox.BorderStyle = BorderStyle.FixedSingle;
            DescBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            DescBox.ForeColor = Color.FromArgb(202, 211, 245);
            DescBox.Location = new Point(169, 126);
            DescBox.Name = "DescBox";
            DescBox.Size = new Size(687, 32);
            DescBox.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 123);
            label4.Name = "label4";
            label4.Size = new Size(135, 32);
            label4.TabIndex = 22;
            label4.Text = "Description";
            // 
            // GenLogBox
            // 
            GenLogBox.BackColor = Color.FromArgb(36, 39, 58);
            GenLogBox.BorderStyle = BorderStyle.FixedSingle;
            GenLogBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            GenLogBox.ForeColor = Color.FromArgb(202, 211, 245);
            GenLogBox.Location = new Point(12, 202);
            GenLogBox.Name = "GenLogBox";
            GenLogBox.ReadOnly = true;
            GenLogBox.Size = new Size(844, 288);
            GenLogBox.TabIndex = 24;
            GenLogBox.Text = "";
            // 
            // ModFileDialog
            // 
            ModFileDialog.FileName = "*.exe";
            ModFileDialog.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            ModFileDialog.FileOk += ModFileDialog_FileOk;
            // 
            // OrgFileDialog
            // 
            OrgFileDialog.FileName = "*.exe";
            OrgFileDialog.Filter = "Binary files(*.exe,*.dll,*.scr)|*.exe,*.dll,*.scr|All files (*.*)|*.*";
            OrgFileDialog.FileOk += OrgFileDialog_FileOk;
            // 
            // PatchNameBox
            // 
            PatchNameBox.BackColor = Color.FromArgb(36, 39, 58);
            PatchNameBox.BorderStyle = BorderStyle.FixedSingle;
            PatchNameBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PatchNameBox.ForeColor = Color.FromArgb(202, 211, 245);
            PatchNameBox.Location = new Point(169, 166);
            PatchNameBox.Name = "PatchNameBox";
            PatchNameBox.Size = new Size(276, 32);
            PatchNameBox.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 164);
            label5.Name = "label5";
            label5.Size = new Size(138, 32);
            label5.TabIndex = 25;
            label5.Text = "Patch name";
            // 
            // PatchGenForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(36, 39, 58);
            ClientSize = new Size(868, 500);
            Controls.Add(PatchNameBox);
            Controls.Add(label5);
            Controls.Add(GenLogBox);
            Controls.Add(DescBox);
            Controls.Add(label4);
            Controls.Add(VersionBox);
            Controls.Add(label3);
            Controls.Add(AuthorBox);
            Controls.Add(label2);
            Controls.Add(GenPatchBttn);
            Controls.Add(md5Check);
            Controls.Add(OpenModFileDialog);
            Controls.Add(ModFilePathBox);
            Controls.Add(label1);
            Controls.Add(OpenTargetFileDialog);
            Controls.Add(OrgFilePathBox);
            Controls.Add(OrgFileLabel);
            ForeColor = Color.FromArgb(202, 211, 245);
            Name = "PatchGenForm";
            Text = "PatchGenForm";
            Load += PatchGenForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenPatchBttn;
        private CheckBox md5Check;
        private Button OpenModFileDialog;
        private TextBox ModFilePathBox;
        private Label label1;
        private Button OpenTargetFileDialog;
        private TextBox OrgFilePathBox;
        private Label OrgFileLabel;
        private Label label2;
        private TextBox VersionBox;
        private Label label3;
        private TextBox DescBox;
        private Label label4;
        public RichTextBox GenLogBox;
        private OpenFileDialog ModFileDialog;
        private OpenFileDialog OrgFileDialog;
        private TextBox PatchNameBox;
        private Label label5;
        public TextBox AuthorBox;
    }
}