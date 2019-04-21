namespace PictureEncryption2019
{
    partial class GoogleDriveForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleDriveForm));
            this.ButtonCancel = new MetroFramework.Controls.MetroTile();
            this.ButtonSelect = new MetroFramework.Controls.MetroTile();
            this.TreeViewGoogleFiles = new System.Windows.Forms.TreeView();
            this.ImageListGoogleFile = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(648, 385);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(129, 42);
            this.ButtonCancel.Style = MetroFramework.MetroColorStyle.Yellow;
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelect.Location = new System.Drawing.Point(513, 385);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(129, 42);
            this.ButtonSelect.TabIndex = 2;
            this.ButtonSelect.Text = "Выбрать";
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // TreeViewGoogleFiles
            // 
            this.TreeViewGoogleFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewGoogleFiles.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.TreeViewGoogleFiles.FullRowSelect = true;
            this.TreeViewGoogleFiles.Location = new System.Drawing.Point(13, 63);
            this.TreeViewGoogleFiles.Name = "TreeViewGoogleFiles";
            this.TreeViewGoogleFiles.ShowPlusMinus = false;
            this.TreeViewGoogleFiles.Size = new System.Drawing.Size(764, 316);
            this.TreeViewGoogleFiles.StateImageList = this.ImageListGoogleFile;
            this.TreeViewGoogleFiles.TabIndex = 0;
            this.TreeViewGoogleFiles.DoubleClick += new System.EventHandler(this.TreeViewGoogleFiles_DoubleClick);
            // 
            // ImageListGoogleFile
            // 
            this.ImageListGoogleFile.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListGoogleFile.ImageStream")));
            this.ImageListGoogleFile.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListGoogleFile.Images.SetKeyName(0, "IcoBmp_64.png");
            this.ImageListGoogleFile.Images.SetKeyName(1, "IcoJpg_64.png");
            this.ImageListGoogleFile.Images.SetKeyName(2, "IcoOther_64.png");
            this.ImageListGoogleFile.Images.SetKeyName(3, "IcoPng_64.png");
            // 
            // GoogleDriveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TreeViewGoogleFiles);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "GoogleDriveForm";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.SystemShadow;
            this.Text = "Google Диск";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile ButtonCancel;
        private MetroFramework.Controls.MetroTile ButtonSelect;
        private System.Windows.Forms.TreeView TreeViewGoogleFiles;
        private System.Windows.Forms.ImageList ImageListGoogleFile;
    }
}