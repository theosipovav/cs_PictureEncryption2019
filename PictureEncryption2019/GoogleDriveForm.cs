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
    public partial class GoogleDriveForm : MetroFramework.Forms.MetroForm
    {
        private string sError { get; set; }
        private List<Google.Apis.Drive.v3.Data.File> ListGoogleDriveFiles { get; set; }
        private Google.Apis.Drive.v3.Data.File GoogleDriveFileCurrent { get; set; }

        public GoogleDriveForm(IList<Google.Apis.Drive.v3.Data.File> google_files)
        {
            InitializeComponent();
            TreeViewGoogleFiles.Nodes.Clear();
            /*
            if (new_varGoogleDriveFiles == null)
            {
                for (int i = 0; i < 100; i++)
                {
                    string name = "Файл изображения " + i + " .png";
                    TreeViewGoogleFiles.Nodes.Add(name, name, 1);
                }
                return;
            }
            */
            ListGoogleDriveFiles = new List<Google.Apis.Drive.v3.Data.File>();
            try
            {
                for (int i = 0; i < google_files.Count; i++)
                {
                    string name = google_files[i].Name;
                    ListGoogleDriveFiles.Add(google_files[i]);
                    TreeViewGoogleFiles.Nodes.Add(name, name, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace, "Ошибка!");
                Close();
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            SelectIamge();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Google.Apis.Drive.v3.Data.File GetGoogleDriveFileCurrent()
        {
            return GoogleDriveFileCurrent;
        }

        private void TreeViewGoogleFiles_DoubleClick(object sender, EventArgs e)
        {
            SelectIamge();
        }

        private void SelectIamge()
        {
            string sFileName = TreeViewGoogleFiles.SelectedNode.Name;
            if ((System.IO.Path.GetExtension(sFileName) != ".jpg") && (System.IO.Path.GetExtension(sFileName) != ".JPG") &&
                (System.IO.Path.GetExtension(sFileName) != ".jpeg") && (System.IO.Path.GetExtension(sFileName) != ".JPEG") &&
                (System.IO.Path.GetExtension(sFileName) != ".png") && (System.IO.Path.GetExtension(sFileName) != ".PNG") &&
                (System.IO.Path.GetExtension(sFileName) != ".bmp") && (System.IO.Path.GetExtension(sFileName) != ".BMP"))
            {
                MessageBox.Show("Выбран файл с не верным форматом!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GoogleDriveFileCurrent = ListGoogleDriveFiles[TreeViewGoogleFiles.SelectedNode.Index];
                Close();
            }
        }

    }
}
