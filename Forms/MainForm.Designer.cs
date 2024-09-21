namespace BinPatch
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            controlsPanel = new Panel();
            underlinePanel = new Panel();
            SettingsMenuBttn = new Label();
            PatchGenMenuBttn = new Label();
            PatcherMenuBttn = new Label();
            mainPanel = new Panel();
            controlsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // controlsPanel
            // 
            controlsPanel.Controls.Add(underlinePanel);
            controlsPanel.Controls.Add(SettingsMenuBttn);
            controlsPanel.Controls.Add(PatchGenMenuBttn);
            controlsPanel.Controls.Add(PatcherMenuBttn);
            controlsPanel.Dock = DockStyle.Top;
            controlsPanel.Location = new Point(0, 0);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(884, 52);
            controlsPanel.TabIndex = 0;
            // 
            // underlinePanel
            // 
            underlinePanel.BackColor = Color.FromArgb(202, 211, 245);
            underlinePanel.Location = new Point(12, 45);
            underlinePanel.Name = "underlinePanel";
            underlinePanel.Size = new Size(91, 3);
            underlinePanel.TabIndex = 1;
            // 
            // SettingsMenuBttn
            // 
            SettingsMenuBttn.AutoSize = true;
            SettingsMenuBttn.Dock = DockStyle.Left;
            SettingsMenuBttn.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            SettingsMenuBttn.Location = new Point(244, 0);
            SettingsMenuBttn.Name = "SettingsMenuBttn";
            SettingsMenuBttn.Padding = new Padding(10, 10, 0, 0);
            SettingsMenuBttn.Size = new Size(114, 47);
            SettingsMenuBttn.TabIndex = 2;
            SettingsMenuBttn.Text = "Settings";
            SettingsMenuBttn.Click += SettingsMenuBttn_Click;
            SettingsMenuBttn.MouseLeave += SettingsMenuBttn_MouseLeave;
            SettingsMenuBttn.MouseHover += SettingsMenuBttn_MouseHover;
            // 
            // PatchGenMenuBttn
            // 
            PatchGenMenuBttn.AutoSize = true;
            PatchGenMenuBttn.Dock = DockStyle.Left;
            PatchGenMenuBttn.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            PatchGenMenuBttn.Location = new Point(109, 0);
            PatchGenMenuBttn.Name = "PatchGenMenuBttn";
            PatchGenMenuBttn.Padding = new Padding(10, 10, 0, 0);
            PatchGenMenuBttn.Size = new Size(135, 47);
            PatchGenMenuBttn.TabIndex = 1;
            PatchGenMenuBttn.Text = "Generator";
            PatchGenMenuBttn.Click += PatchGenMenuBttn_Click;
            PatchGenMenuBttn.MouseLeave += PatchGenMenuBttn_MouseLeave;
            PatchGenMenuBttn.MouseHover += PatchGenMenuBttn_MouseHover;
            // 
            // PatcherMenuBttn
            // 
            PatcherMenuBttn.AutoSize = true;
            PatcherMenuBttn.Dock = DockStyle.Left;
            PatcherMenuBttn.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            PatcherMenuBttn.Location = new Point(0, 0);
            PatcherMenuBttn.Name = "PatcherMenuBttn";
            PatcherMenuBttn.Padding = new Padding(10, 10, 0, 0);
            PatcherMenuBttn.Size = new Size(109, 47);
            PatcherMenuBttn.TabIndex = 0;
            PatcherMenuBttn.Text = "Patcher";
            PatcherMenuBttn.Click += PatcherMenuBttn_Click;
            PatcherMenuBttn.MouseLeave += PatcherMenuBttn_MouseLeave;
            PatcherMenuBttn.MouseHover += PatcherMenuBttn_MouseHover;
            // 
            // mainPanel
            // 
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Font = new Font("Sans Serif Collection", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            mainPanel.ForeColor = Color.FromArgb(202, 211, 245);
            mainPanel.Location = new Point(0, 52);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(884, 509);
            mainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 39, 58);
            ClientSize = new Size(884, 561);
            Controls.Add(mainPanel);
            Controls.Add(controlsPanel);
            Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(202, 211, 245);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "BinPatch | vX.X.X";
            Load += MainForm_Load;
            controlsPanel.ResumeLayout(false);
            controlsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel controlsPanel;
        private Label PatcherMenuBttn;
        private Label SettingsMenuBttn;
        private Label PatchGenMenuBttn;
        private Panel underlinePanel;
        private Panel mainPanel;
    }
}