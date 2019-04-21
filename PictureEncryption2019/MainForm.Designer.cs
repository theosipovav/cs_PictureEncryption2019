namespace PictureEncryption2019
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.TextBoxGoogalStatus = new System.Windows.Forms.TextBox();
            this.ProgressBarStatus = new MetroFramework.Controls.MetroProgressBar();
            this.ButtonGoogleSaveFile = new MetroFramework.Controls.MetroTile();
            this.ButtonGoogleOpenFile = new MetroFramework.Controls.MetroTile();
            this.ButtonGoogleAuth = new MetroFramework.Controls.MetroTile();
            this.ButtonSaveLocalFile = new MetroFramework.Controls.MetroTile();
            this.ButtonDecryption = new MetroFramework.Controls.MetroTile();
            this.ButtonEncryption = new MetroFramework.Controls.MetroTile();
            this.ButtonOpenLocalFile = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.LabelImageTitle = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxText = new System.Windows.Forms.TextBox();
            this.PictureBoxImage = new System.Windows.Forms.PictureBox();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(18, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "МЕНЮ";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.Controls.Add(this.TextBoxGoogalStatus);
            this.metroPanel1.Controls.Add(this.ProgressBarStatus);
            this.metroPanel1.Controls.Add(this.ButtonGoogleSaveFile);
            this.metroPanel1.Controls.Add(this.ButtonGoogleOpenFile);
            this.metroPanel1.Controls.Add(this.ButtonGoogleAuth);
            this.metroPanel1.Controls.Add(this.ButtonSaveLocalFile);
            this.metroPanel1.Controls.Add(this.ButtonDecryption);
            this.metroPanel1.Controls.Add(this.ButtonEncryption);
            this.metroPanel1.Controls.Add(this.ButtonOpenLocalFile);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(230, 543);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // TextBoxGoogalStatus
            // 
            this.TextBoxGoogalStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxGoogalStatus.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Italic);
            this.TextBoxGoogalStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.TextBoxGoogalStatus.Location = new System.Drawing.Point(13, 299);
            this.TextBoxGoogalStatus.Name = "TextBoxGoogalStatus";
            this.TextBoxGoogalStatus.Size = new System.Drawing.Size(204, 18);
            this.TextBoxGoogalStatus.TabIndex = 12;
            this.TextBoxGoogalStatus.Text = "Авторизация не произведена";
            this.TextBoxGoogalStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ProgressBarStatus
            // 
            this.ProgressBarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarStatus.Location = new System.Drawing.Point(13, 508);
            this.ProgressBarStatus.Name = "ProgressBarStatus";
            this.ProgressBarStatus.Size = new System.Drawing.Size(204, 22);
            this.ProgressBarStatus.Style = MetroFramework.MetroColorStyle.Teal;
            this.ProgressBarStatus.TabIndex = 10;
            // 
            // ButtonGoogleSaveFile
            // 
            this.ButtonGoogleSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGoogleSaveFile.Location = new System.Drawing.Point(13, 428);
            this.ButtonGoogleSaveFile.Name = "ButtonGoogleSaveFile";
            this.ButtonGoogleSaveFile.Size = new System.Drawing.Size(204, 44);
            this.ButtonGoogleSaveFile.TabIndex = 9;
            this.ButtonGoogleSaveFile.Text = "Загрузить файл изображения";
            this.ButtonGoogleSaveFile.Click += new System.EventHandler(this.ButtonGoogleSaveFile_Click);
            // 
            // ButtonGoogleOpenFile
            // 
            this.ButtonGoogleOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGoogleOpenFile.Location = new System.Drawing.Point(13, 378);
            this.ButtonGoogleOpenFile.Name = "ButtonGoogleOpenFile";
            this.ButtonGoogleOpenFile.Size = new System.Drawing.Size(204, 44);
            this.ButtonGoogleOpenFile.TabIndex = 9;
            this.ButtonGoogleOpenFile.Text = "Скачать файл изображения";
            this.ButtonGoogleOpenFile.Click += new System.EventHandler(this.ButtonGoogleOpenFile_Click);
            // 
            // ButtonGoogleAuth
            // 
            this.ButtonGoogleAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGoogleAuth.Location = new System.Drawing.Point(13, 328);
            this.ButtonGoogleAuth.Name = "ButtonGoogleAuth";
            this.ButtonGoogleAuth.Size = new System.Drawing.Size(204, 44);
            this.ButtonGoogleAuth.Style = MetroFramework.MetroColorStyle.Blue;
            this.ButtonGoogleAuth.TabIndex = 5;
            this.ButtonGoogleAuth.Text = "Авторизация";
            this.ButtonGoogleAuth.Click += new System.EventHandler(this.ButtonGoogleAuth_Click);
            // 
            // ButtonSaveLocalFile
            // 
            this.ButtonSaveLocalFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSaveLocalFile.Location = new System.Drawing.Point(13, 91);
            this.ButtonSaveLocalFile.Name = "ButtonSaveLocalFile";
            this.ButtonSaveLocalFile.Size = new System.Drawing.Size(204, 44);
            this.ButtonSaveLocalFile.Style = MetroFramework.MetroColorStyle.Teal;
            this.ButtonSaveLocalFile.TabIndex = 2;
            this.ButtonSaveLocalFile.Text = "Сохранить файл изображения";
            this.ButtonSaveLocalFile.Click += new System.EventHandler(this.ButtonSaveLocalFile_Click);
            // 
            // ButtonDecryption
            // 
            this.ButtonDecryption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDecryption.Location = new System.Drawing.Point(13, 196);
            this.ButtonDecryption.Name = "ButtonDecryption";
            this.ButtonDecryption.Size = new System.Drawing.Size(204, 44);
            this.ButtonDecryption.Style = MetroFramework.MetroColorStyle.Teal;
            this.ButtonDecryption.TabIndex = 4;
            this.ButtonDecryption.Text = "Выполнить дешифрование";
            this.ButtonDecryption.Click += new System.EventHandler(this.ButtonDecryption_Click);
            // 
            // ButtonEncryption
            // 
            this.ButtonEncryption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEncryption.Location = new System.Drawing.Point(13, 141);
            this.ButtonEncryption.Name = "ButtonEncryption";
            this.ButtonEncryption.Size = new System.Drawing.Size(204, 49);
            this.ButtonEncryption.Style = MetroFramework.MetroColorStyle.Teal;
            this.ButtonEncryption.TabIndex = 3;
            this.ButtonEncryption.Text = "Выполнить шифрование";
            this.ButtonEncryption.Click += new System.EventHandler(this.ButtonEncryption_Click);
            // 
            // ButtonOpenLocalFile
            // 
            this.ButtonOpenLocalFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOpenLocalFile.Location = new System.Drawing.Point(13, 41);
            this.ButtonOpenLocalFile.Name = "ButtonOpenLocalFile";
            this.ButtonOpenLocalFile.Size = new System.Drawing.Size(204, 44);
            this.ButtonOpenLocalFile.Style = MetroFramework.MetroColorStyle.Teal;
            this.ButtonOpenLocalFile.TabIndex = 1;
            this.ButtonOpenLocalFile.Text = "Открыть файл изображения";
            this.ButtonOpenLocalFile.Click += new System.EventHandler(this.ButtonOpenLocalFile_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(18, 271);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(111, 25);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Google Drive";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel2.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel2.Controls.Add(this.LabelImageTitle);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.TextBoxText);
            this.metroPanel2.Controls.Add(this.PictureBoxImage);
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(259, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(662, 543);
            this.metroPanel2.TabIndex = 4;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // LabelImageTitle
            // 
            this.LabelImageTitle.AutoSize = true;
            this.LabelImageTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LabelImageTitle.Location = new System.Drawing.Point(13, 13);
            this.LabelImageTitle.Name = "LabelImageTitle";
            this.LabelImageTitle.Size = new System.Drawing.Size(121, 25);
            this.LabelImageTitle.TabIndex = 8;
            this.LabelImageTitle.Text = "Изображение";
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(13, 399);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(52, 25);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Текст";
            // 
            // TextBoxText
            // 
            this.TextBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxText.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxText.Location = new System.Drawing.Point(13, 427);
            this.TextBoxText.Multiline = true;
            this.TextBoxText.Name = "TextBoxText";
            this.TextBoxText.Size = new System.Drawing.Size(634, 103);
            this.TextBoxText.TabIndex = 3;
            // 
            // PictureBoxImage
            // 
            this.PictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PictureBoxImage.Location = new System.Drawing.Point(13, 41);
            this.PictureBoxImage.Name = "PictureBoxImage";
            this.PictureBoxImage.Size = new System.Drawing.Size(634, 352);
            this.PictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxImage.TabIndex = 2;
            this.PictureBoxImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 629);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Шифрование текста";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile ButtonDecryption;
        private MetroFramework.Controls.MetroTile ButtonEncryption;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile ButtonSaveLocalFile;
        private MetroFramework.Controls.MetroTile ButtonOpenLocalFile;
        private MetroFramework.Controls.MetroTile ButtonGoogleSaveFile;
        private MetroFramework.Controls.MetroTile ButtonGoogleOpenFile;
        private MetroFramework.Controls.MetroTile ButtonGoogleAuth;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.PictureBox PictureBoxImage;
        private MetroFramework.Controls.MetroLabel LabelImageTitle;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox TextBoxText;
        private MetroFramework.Controls.MetroProgressBar ProgressBarStatus;
        private System.Windows.Forms.TextBox TextBoxGoogalStatus;
    }
}

