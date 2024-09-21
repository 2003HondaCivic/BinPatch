namespace BinPatch.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            authorNameCheck = new CheckBox();
            TargetLabel = new Label();
            forceNoMd5 = new CheckBox();
            label1 = new Label();
            forceNoBackups = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            richTextBox2 = new RichTextBox();
            label6 = new Label();
            label7 = new Label();
            richTextBox3 = new RichTextBox();
            SuspendLayout();
            // 
            // authorNameCheck
            // 
            authorNameCheck.AutoSize = true;
            authorNameCheck.FlatStyle = FlatStyle.Flat;
            authorNameCheck.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            authorNameCheck.Location = new Point(12, 61);
            authorNameCheck.Name = "authorNameCheck";
            authorNameCheck.Size = new Size(282, 29);
            authorNameCheck.TabIndex = 16;
            authorNameCheck.Text = "Always use same author name";
            authorNameCheck.UseVisualStyleBackColor = true;
            authorNameCheck.CheckedChanged += authorNameCheck_CheckedChanged;
            // 
            // TargetLabel
            // 
            TargetLabel.AutoSize = true;
            TargetLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            TargetLabel.ForeColor = Color.White;
            TargetLabel.Location = new Point(12, 9);
            TargetLabel.Name = "TargetLabel";
            TargetLabel.Size = new Size(153, 32);
            TargetLabel.TabIndex = 17;
            TargetLabel.Text = "Convenience";
            // 
            // forceNoMd5
            // 
            forceNoMd5.AutoSize = true;
            forceNoMd5.FlatStyle = FlatStyle.Flat;
            forceNoMd5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            forceNoMd5.Location = new Point(12, 109);
            forceNoMd5.Name = "forceNoMd5";
            forceNoMd5.Size = new Size(224, 29);
            forceNoMd5.TabIndex = 18;
            forceNoMd5.Text = "Force never check MD5";
            forceNoMd5.UseVisualStyleBackColor = true;
            forceNoMd5.CheckedChanged += forceNoMd5_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 169);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 19;
            label1.Text = "Patching";
            // 
            // forceNoBackups
            // 
            forceNoBackups.AutoSize = true;
            forceNoBackups.FlatStyle = FlatStyle.Flat;
            forceNoBackups.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            forceNoBackups.Location = new Point(12, 224);
            forceNoBackups.Name = "forceNoBackups";
            forceNoBackups.Size = new Size(200, 29);
            forceNoBackups.TabIndex = 20;
            forceNoBackups.Text = "Dont create backups";
            forceNoBackups.UseVisualStyleBackColor = true;
            forceNoBackups.CheckedChanged += forceNoBackups_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(352, 9);
            label2.Name = "label2";
            label2.Size = new Size(79, 32);
            label2.TabIndex = 21;
            label2.Text = "About";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(352, 65);
            label3.Name = "label3";
            label3.Size = new Size(334, 25);
            label3.TabIndex = 22;
            label3.Text = "Program and GUI by 2003 Honda Civic";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(352, 109);
            label4.Name = "label4";
            label4.Size = new Size(364, 25);
            label4.TabIndex = 23;
            label4.Text = "Icon from FlatIcon and created by Freepik:";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(36, 39, 58);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.ForeColor = Color.FromArgb(202, 211, 245);
            richTextBox1.Location = new Point(352, 151);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(426, 32);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = " https://www.flaticon.com/free-icons/binary-code";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(352, 186);
            label5.Name = "label5";
            label5.Size = new Size(146, 32);
            label5.TabIndex = 25;
            label5.Text = "Source code";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.FromArgb(36, 39, 58);
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox2.ForeColor = Color.FromArgb(202, 211, 245);
            richTextBox2.Location = new Point(352, 226);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(426, 32);
            richTextBox2.TabIndex = 26;
            richTextBox2.Text = " https://github.com/2003HondaCivic/BinPatch";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 274);
            label6.Name = "label6";
            label6.Size = new Size(92, 32);
            label6.TabIndex = 27;
            label6.Text = "License";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(-8, 306);
            label7.Name = "label7";
            label7.Size = new Size(562, 200);
            label7.TabIndex = 28;
            label7.Text = resources.GetString("label7.Text");
            // 
            // richTextBox3
            // 
            richTextBox3.BackColor = Color.FromArgb(36, 39, 58);
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox3.ForeColor = Color.FromArgb(202, 211, 245);
            richTextBox3.Location = new Point(17, 456);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(599, 32);
            richTextBox3.TabIndex = 29;
            richTextBox3.Text = "https://github.com/2003HondaCivic/BinPatch/blob/master/LICENSE.txt";
            // 
            // SettingsForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(36, 39, 58);
            ClientSize = new Size(868, 500);
            Controls.Add(richTextBox3);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(richTextBox2);
            Controls.Add(label5);
            Controls.Add(richTextBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(forceNoBackups);
            Controls.Add(label1);
            Controls.Add(forceNoMd5);
            Controls.Add(TargetLabel);
            Controls.Add(authorNameCheck);
            ForeColor = Color.FromArgb(202, 211, 245);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox authorNameCheck;
        private Label TargetLabel;
        private CheckBox forceNoMd5;
        private Label label1;
        private CheckBox forceNoBackups;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox richTextBox1;
        private Label label5;
        private RichTextBox richTextBox2;
        private Label label6;
        private Label label7;
        private RichTextBox richTextBox3;
    }
}