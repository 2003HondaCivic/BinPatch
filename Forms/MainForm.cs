using BinPatch.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinPatch
{
    public partial class MainForm : Form
    {
        private Control selectedButton;
        private Form PatcherForm;
        private Form PatchGenForm;
        private Form SettingsForm;
        private Form currentChildForm;
        public MainForm()
        {
            //Anyone that reads this code should know I HATE designing GUI's 
            InitializeComponent();
            try
            {
                UseImmersiveDarkMode(this.Handle, true);
            }
            catch {/*Just in case???*/}
            underlinePanel.BringToFront();
            underlinePanel.Left = PatcherMenuBttn.Left  + 15;
            underlinePanel.Width = PatcherMenuBttn.Width -20;
            underlinePanel.BackColor = Color.White;
            PatcherMenuBttn.ForeColor = Color.White;
            this.selectedButton = PatcherMenuBttn;
        }

        private void SwitchChildForm(Form childForm)
        {
            if (childForm == null || currentChildForm == childForm)
            {
                return;
            }

            if (currentChildForm != null)
            {
                currentChildForm.Hide();
            }

            currentChildForm = childForm;

            if (!mainPanel.Controls.Contains(childForm))
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;

                // Instead of setting Dock to Fill, set a custom size and location
                childForm.Size = new Size(mainPanel.Width - 20, mainPanel.Height - 20); // Example size
                childForm.Location = new Point(10, 10); // Example margin
                mainPanel.Controls.Add(childForm);
            }

            
            childForm.BringToFront();
            childForm.Show();
        }
        private System.Windows.Forms.Timer animationTimer;

        private void MoveUnderline(Control button)
        {
            int shrinkAmount = 15;
            int targetLeft = button.Left + shrinkAmount;
            int targetWidth = button.Width - shrinkAmount - 5;

            // Stop the previous animation if it's still running
            if (animationTimer != null)
            {
                animationTimer.Stop();
                animationTimer.Dispose();
            }

            // Initialize a new timer for the current animation
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;

            animationTimer.Tick += (s, args) =>
            {
                int leftDifference = targetLeft - underlinePanel.Left;
                int widthDifference = targetWidth - underlinePanel.Width;

                // Smooth transition of the underline panel
                underlinePanel.Left += Math.Sign(leftDifference) * Math.Max(1, Math.Abs(leftDifference) / 3);
                underlinePanel.Width += Math.Sign(widthDifference) * Math.Max(1, Math.Abs(widthDifference) / 3);

                // Stop the animation when the target position is reached
                if (Math.Abs(leftDifference) <= 1 && Math.Abs(widthDifference) <= 1)
                {
                    underlinePanel.Left = targetLeft;
                    underlinePanel.Width = targetWidth;
                    animationTimer.Stop();
                    animationTimer.Dispose();
                }
            };

            // Start the animation
            animationTimer.Start();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"BinPatch | v{Patcher.Instance.version}";
            PatcherForm = new Forms.PatcherForm();
            PatchGenForm = new PatchGenForm();
            SettingsForm = new SettingsForm();
            SwitchChildForm(PatcherForm);

        }


        #region Dark Mode
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
        #endregion Dark Mode

        private void PatcherMenuBttn_MouseHover(object sender, EventArgs e)
        {
            PatcherMenuBttn.ForeColor = Color.White;
        }

        private void PatcherMenuBttn_MouseLeave(object sender, EventArgs e)
        {
            if (selectedButton != PatcherMenuBttn)
            {
                PatcherMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            }
        }

        private void PatchGenMenuBttn_MouseHover(object sender, EventArgs e)
        {
            PatchGenMenuBttn.ForeColor = Color.White;
        }

        private void PatchGenMenuBttn_MouseLeave(object sender, EventArgs e)
        {
            if (selectedButton != PatchGenMenuBttn) 
            { 
            PatchGenMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            }
        }

        private void SettingsMenuBttn_MouseHover(object sender, EventArgs e)
        {
            SettingsMenuBttn.ForeColor = Color.White;
        }

        private void SettingsMenuBttn_MouseLeave(object sender, EventArgs e)
        {
            if (selectedButton != SettingsMenuBttn) 
            { 
            SettingsMenuBttn.ForeColor = Color.FromArgb(202, 211, 245); 
            }
        }

        private void PatcherMenuBttn_Click(object sender, EventArgs e)
        {
            MoveUnderline(PatcherMenuBttn);
            selectedButton = PatcherMenuBttn;
            PatchGenMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            SettingsMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            SwitchChildForm(PatcherForm);
        }

        private void PatchGenMenuBttn_Click(object sender, EventArgs e)
        {
            MoveUnderline(PatchGenMenuBttn);
            selectedButton = PatchGenMenuBttn;
            PatcherMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            SettingsMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            SwitchChildForm(PatchGenForm);
        }

        private void SettingsMenuBttn_Click(object sender, EventArgs e)
        {
            MoveUnderline(SettingsMenuBttn);
            selectedButton = SettingsMenuBttn;
            PatcherMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            PatchGenMenuBttn.ForeColor = Color.FromArgb(202, 211, 245);
            SwitchChildForm(SettingsForm);
        }
    }

}
