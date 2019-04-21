using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEncryption2019
{
    public partial class SaveFileGoogleDriveFrom : MetroFramework.Forms.MetroForm
    {
        private string sNameFile { get; set; }
        public SaveFileGoogleDriveFrom(string name)
        {
            InitializeComponent();
            sNameFile = name;
            TextBoxName.Text = name;
        }
        public string GetNameFile()
        {
            return sNameFile;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            sNameFile = TextBoxName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            sNameFile = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
