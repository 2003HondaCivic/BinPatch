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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void authorNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            BinPatch.Forms.PatchGenForm mainForm = (BinPatch.Forms.PatchGenForm)Application.OpenForms["PatchGenForm"];
            string authorname = mainForm.AuthorBox.Text;

            if (authorNameCheck.Checked)
            {
                MainSettings.Default.UseSameAuthor = true;
                MainSettings.Default.AuthorName = authorname;
            }
            else
            {
                MainSettings.Default.UseSameAuthor = false;
                MainSettings.Default.AuthorName = "";
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            forceNoBackups.Checked = MainSettings.Default.ForceIgnoreBackups;
            forceNoMd5.Checked = MainSettings.Default.ForceIgnoreMD5;
            authorNameCheck.Checked = MainSettings.Default.UseSameAuthor;

        }

        private void forceNoBackups_CheckedChanged(object sender, EventArgs e)
        {
            if (forceNoBackups.Checked)
            {
                MainSettings.Default.ForceIgnoreBackups = true;
            }
            else
            {
                MainSettings.Default.ForceIgnoreBackups= false;
            }
        }

        private void forceNoMd5_CheckedChanged(object sender, EventArgs e)
        {
            if (forceNoMd5.Checked)
            {
                MainSettings.Default.ForceIgnoreMD5 = true;
            }
            else 
            {
                MainSettings.Default.ForceIgnoreMD5 = false;
            }
        }
    }
}
