using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;

namespace PictureEncryption2019
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private string sSecretText;                 // Текст для шифрования
        private string sCurrentNameImage;           // Текущее открытое изображение
        private string sTempPath;                   // Путь к временной папке текущего пользователя
        private Bitmap bitmapCurrentImage;          // Текущее открытое изображение
        private apiGoogleDrive varGoogleDrive;      // Пользовательский класс для работы с Google Drive API

        public MainForm()
        {
            InitializeComponent();
            sSecretText = "";
            sCurrentNameImage = "";
            sTempPath = Path.GetTempPath();
            varGoogleDrive = new apiGoogleDrive();
            InitializationStatusComponent();
        }

        /// <summary>
        /// Опрделение статуса элементов интерфейса программы (скрывает или показывает элементы)
        /// </summary>
        private void InitializationStatusComponent()
        {
            // Задается стартовое отображение объектов в зависимости от авторизации пользователя в Google
            if (varGoogleDrive.isConnection)
            {
                // Восстановлена ранняя произведенная авторизация
                if (varGoogleDrive.ConnectionGoogleDrive())
                {
                    // Авторизация в Google Drive выполнена
                    TextBoxGoogalStatus.ForeColor = Color.DarkBlue;
                    ComponentGoogleDriveEnabled(true);
                }
                else
                {
                    // Ошибка при восстановление ранней произведенной авторизации
                    MessageBox.Show(varGoogleDrive.sError, "Ошибка!");
                    ComponentGoogleDriveEnabled(false);
                }
            }
            else
            {
                // Авторизация в Google Drive не выполнена
                ComponentGoogleDriveEnabled(false);
            }
        }

        private void ComponentGoogleDriveEnabled(bool isEnabled)
        {
            if (isEnabled)
            {
                ButtonGoogleAuth.Text = "Выйти из Google Drive";
                ButtonGoogleAuth.Style = MetroFramework.MetroColorStyle.Yellow;
                ButtonGoogleOpenFile.Enabled = true;
                ButtonGoogleSaveFile.Enabled = true;
                if (varGoogleDrive.getUserName() != null)
                {
                    TextBoxGoogalStatus.Text = varGoogleDrive.getUserName();
                }
                else
                {
                    TextBoxGoogalStatus.Text = "Авторизация выполнена";
                }
                TextBoxGoogalStatus.ForeColor = Color.DarkBlue;
            }
            else
            {
                ButtonGoogleAuth.Text = "Авторизация";
                ButtonGoogleAuth.Style = MetroFramework.MetroColorStyle.Default;
                ButtonGoogleOpenFile.Enabled = false;
                ButtonGoogleSaveFile.Enabled = false;
                TextBoxGoogalStatus.Text = "Авторизация не выполнена";
                TextBoxGoogalStatus.ForeColor = Color.DarkRed;
            }
        }
        /// <summary>
        /// Удаление текущего изображения
        /// </summary>
        private void DeletedCurrentImage()
        {
            try
            {
                sCurrentNameImage = "";
                bitmapCurrentImage = null;
                PictureBoxImage.Image = null;
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message + "\n\nПодробное описание:\n" + excError.StackTrace, "Ошибка!");
            }
        }
        /// <summary>
        /// Конвертирование изображения типа " BitmapImage " в тип " Bitmap"
        /// </summary>
        Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            return bitmap;
        }
        /// <summary>
        /// Установка файла картинки в превью приложения.
        /// </summary>
        /// <param name="bitmapImage">Переменная типа <Bitmap>, которую небходимо показать в превью</param>
        private void ViewCurrentImage(Bitmap bitmapImage)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmapImage.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                PictureBoxImage.Image = bitmapImage;
            }
        }
        /// <summary>
        /// Реализация шифрование сообщения в изображение
        /// </summary>
        private bool Encryption()
        {
            try
            {
                System.Drawing.Color colorPixel;
                int x = 0;
                byte[] B = Encoding.GetEncoding(1251).GetBytes(TextBoxText.Text + '/');
                bool f = false;
                ProgressBarStatus.Maximum = bitmapCurrentImage.Width;
                for (int i = 0; i < bitmapCurrentImage.Width; i++)
                {
                    if (f) break;
                    for (int j = 0; j < bitmapCurrentImage.Height; j++)
                    {
                        colorPixel = bitmapCurrentImage.GetPixel(i, j);
                        if (x == B.Length) { f = true; break; }
                        Bits m = new Bits(B[x++]);
                        while (m.Length != 8)
                        {
                            m.Insert(0, 0);
                        }
                        Bits r = new Bits(colorPixel.R);
                        while (r.Length != 8)
                        {
                            r.Insert(0, 0);
                        }
                        Bits g = new Bits(colorPixel.G);
                        while (g.Length != 8)
                        {
                            g.Insert(0, 0);
                        }
                        Bits b = new Bits(colorPixel.B);
                        while (b.Length != 8)
                        {
                            b.Insert(0, 0);
                        }
                        r[6] = m[0];
                        r[7] = m[1];
                        g[5] = m[2];
                        g[6] = m[3];
                        g[7] = m[4];
                        b[5] = m[5];
                        b[6] = m[6];
                        b[7] = m[7];
                        bitmapCurrentImage.SetPixel(i, j, System.Drawing.Color.FromArgb(r.Number, g.Number, b.Number));
                    }
                }
                bitmapCurrentImage.Save(sTempPath + sCurrentNameImage);
                ProgressBarStatus.Value = ProgressBarStatus.Maximum;
                MessageBox.Show("Шифрование выполнено.", "Внимание!");
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message + "\n\nПодробное описание:\n" + excError.StackTrace, "Ошибка!");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Реализация дешифрование сообщения в изображение
        /// </summary>
        private bool Decryption()
        {
            try
            {
                System.Drawing.Color colorPixel;
                ArrayList array = new ArrayList();
                bool f = false;
                ProgressBarStatus.Maximum = bitmapCurrentImage.Width;
                for (int i = 0; i < bitmapCurrentImage.Width; i++)
                {
                    if (f) break;
                    for (int j = 0; j < bitmapCurrentImage.Height; j++)
                    {
                        colorPixel = bitmapCurrentImage.GetPixel(i, j);
                        Bits m = new Bits(255);
                        Bits r = new Bits(colorPixel.R);
                        while (r.Length != 8)
                        {
                            r.Insert(0, 0);
                        }
                        Bits g = new Bits(colorPixel.G);
                        while (g.Length != 8)
                        {
                            g.Insert(0, 0);
                        }
                        Bits b = new Bits(colorPixel.B);
                        while (b.Length != 8)
                        {
                            b.Insert(0, 0);
                        }
                        m[0] = r[6];
                        m[1] = r[7];
                        m[2] = g[5];
                        m[3] = g[6];
                        m[4] = g[7];
                        m[5] = b[5];
                        m[6] = b[6];
                        m[7] = b[7];
                        if (m.Char == '/')
                        {
                            f = true;
                            break;
                        }
                        array.Add(m.Number);
                    }
                }
                byte[] byteMsg = new byte[array.Count];
                for (int i = 0; i < array.Count; i++)
                {
                    byteMsg[i] = Convert.ToByte(array[i]);
                }
                sSecretText = Encoding.GetEncoding(1251).GetString(byteMsg);
                TextBoxText.Clear();
                TextBoxText.Text = sSecretText;
                ProgressBarStatus.Value = ProgressBarStatus.Maximum;
                MessageBox.Show("Дешифрация выполнена!", "Зашифрованный текст");
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message + "\n\nПодробное описание:\n" + excError.StackTrace, "Ошибка!");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Открыть файл изображения» (локально)
        /// </summary>
        private void ButtonOpenLocalFile_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressBarStatus.Maximum = 100;
                ProgressBarStatus.Value = 0;
                DeletedCurrentImage();
                OpenFileDialog ofdOpenImage = new OpenFileDialog();
                ofdOpenImage.Filter = "Изображения(*.bmp *.jpg *.png)|*.bmp;*jpg;*png|Все файлы(*.*)|*.*";
                ofdOpenImage.FileName = "";
                ProgressBarStatus.Maximum = 20;
                if (ofdOpenImage.ShowDialog() == DialogResult.OK)
                {
                    ProgressBarStatus.Maximum = 40;
                    string filetype = ofdOpenImage.FileName.Substring(ofdOpenImage.FileName.Length - 3);
                    if ((filetype == "jpg") || (filetype == "JPG"))
                    {
                        bitmapCurrentImage = ConvertToBitmap(ofdOpenImage.FileName);
                    }
                    else
                    {
                        bitmapCurrentImage = (Bitmap)System.Drawing.Image.FromFile(ofdOpenImage.FileName);
                    }
                    ProgressBarStatus.Maximum = 60;
                    ViewCurrentImage(bitmapCurrentImage);
                    sCurrentNameImage = ofdOpenImage.SafeFileName;
                    LabelImageTitle.Text = sCurrentNameImage;
                    ProgressBarStatus.Maximum = 100;
                }
                else
                {
                    DeletedCurrentImage();
                }
                TextBoxText.Clear();
                ProgressBarStatus.Value = 0;
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message + "\n\nПодробное описание:\n" + excError.StackTrace, "Ошибка!");
                DeletedCurrentImage();
                ProgressBarStatus.Value = 0;
            }
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Авторизация» (Google)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGoogleAuth_Click(object sender, EventArgs e)
        {
            try
            {
                if (varGoogleDrive.isConnection)
                {
                    // Подключение к Goole Drive и получение токена
                    if (!varGoogleDrive.Disconnect(sTempPath))
                    {
                        if (varGoogleDrive.isError)
                        {
                            MessageBox.Show(varGoogleDrive.sError, "Ошибка!");
                        }
                    }
                    varGoogleDrive = new apiGoogleDrive();
                    // Деактивация элементов интерфейса для работы с Google Drive
                    ComponentGoogleDriveEnabled(false);
                }
                else
                {
                    // Подключение к Goole Drive и получение токена
                    if (!varGoogleDrive.ConnectionGoogleDrive())
                    {
                        if (varGoogleDrive.isError)
                        {
                            MessageBox.Show(varGoogleDrive.sError, "Ошибка!");
                        }
                    }
                    // Активация элементов интерфейса для работы с Google Drive
                    ComponentGoogleDriveEnabled(true);
                }
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message + "\n\nПодробное описание:\n" + excError.StackTrace, "Ошибка!");
                ComponentGoogleDriveEnabled(true);
            }
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Открыть файл изображения» (Google)
        /// </summary>
        private void ButtonGoogleOpenFile_Click(object sender, EventArgs e)
        {
            ProgressBarStatus.Value = 0;
            ProgressBarStatus.Maximum = 100;
            // Проверка подключения к Google Drive
            if (!varGoogleDrive.isConnection)
            {
                MessageBox.Show("Вы не авторизованы в системе Google Drive.", "Внимание!");
                return;
            }
            // Загрузка окна с файлами из Google Drive
            try
            {
                ProgressBarStatus.Maximum = 100;
                ProgressBarStatus.Value = 0;
                TextBoxText.Clear();
                GoogleDriveForm formGoogleDriveFiles = new GoogleDriveForm(varGoogleDrive.getListFiles());
                formGoogleDriveFiles.ShowDialog();
                ProgressBarStatus.Value = 25;
                if (formGoogleDriveFiles.GetGoogleDriveFileCurrent() != null)
                {
                    Google.Apis.Drive.v3.Data.File varGoogleDriveFile = formGoogleDriveFiles.GetGoogleDriveFileCurrent();
                    sCurrentNameImage = varGoogleDriveFile.Name;
                    if ((System.IO.Path.GetExtension(sCurrentNameImage) != ".jpg") && (System.IO.Path.GetExtension(sCurrentNameImage) != ".JPG")
                        && (System.IO.Path.GetExtension(sCurrentNameImage) != ".jpeg") && (System.IO.Path.GetExtension(sCurrentNameImage) != ".JPEG")
                        && (System.IO.Path.GetExtension(sCurrentNameImage) != ".png") && (System.IO.Path.GetExtension(sCurrentNameImage) != ".PNG")
                        && (System.IO.Path.GetExtension(sCurrentNameImage) != ".bmp") && (System.IO.Path.GetExtension(sCurrentNameImage) != ".BMP"))
                    {
                        MessageBox.Show("Данный формат не поддерживается!", "Внимание!");
                        DeletedCurrentImage();
                        return;
                    }
                    ProgressBarStatus.Value = 50;
                    LabelImageTitle.Text = sCurrentNameImage;
                    Stream stream_SECRET_IMAGE = varGoogleDrive.downloadFileFromGoogleDrive(varGoogleDriveFile);
                    if (stream_SECRET_IMAGE == null)
                    {
                        MessageBox.Show(varGoogleDrive.sError, "Ошибка!");
                        DeletedCurrentImage();
                        return;
                    }
                    if (stream_SECRET_IMAGE == null)
                    {
                        return;
                    }
                    ProgressBarStatus.Value = 75;
                    System.Drawing.Image newImage = System.Drawing.Image.FromStream(stream_SECRET_IMAGE);
                    bitmapCurrentImage = new Bitmap(newImage);
                    ViewCurrentImage(bitmapCurrentImage);
                    ProgressBarStatus.Value = 100;
                }
                else
                {
                    DeletedCurrentImage();
                }
                ProgressBarStatus.Value = 0;
                ProgressBarStatus.Maximum = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace, "Ошибка!");
                DeletedCurrentImage();
                ProgressBarStatus.Value = 0;
                ProgressBarStatus.Maximum = 100;
            }
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Сохранить файл изображения» (локально)
        /// </summary>
        private void ButtonSaveLocalFile_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressBarStatus.Maximum = 100;
                ProgressBarStatus.Value = 0;
                if ((sCurrentNameImage == "") || (bitmapCurrentImage == null))
                {
                    MessageBox.Show("Не найдено текущее изображение, которое необходимо сохранить.", "Внимание!");
                    return;
                }
                SaveFileDialog sfdSaveCurrentImage = new SaveFileDialog();
                sfdSaveCurrentImage.Filter = "Изображения(*.bmp *.jpg *.png)|*.bmp;*jpg;*png|Все файлы(*.*)|*.*";
                sfdSaveCurrentImage.FileName = "new_" + sCurrentNameImage;

                if (sfdSaveCurrentImage.ShowDialog() == DialogResult.OK)
                {
                    bitmapCurrentImage.Save(sfdSaveCurrentImage.FileName);
                }
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message + "\n\nПодробное описание:\n" + excError.StackTrace, "Ошибка!");
                ProgressBarStatus.Value = 0;
                ProgressBarStatus.Maximum = 100;
            }
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Выполнить шифрование»
        /// </summary>
        private void ButtonEncryption_Click(object sender, EventArgs e)
        {
            ProgressBarStatus.Maximum = 100;
            ProgressBarStatus.Value = 0;
            if ((sCurrentNameImage == "") || (bitmapCurrentImage == null))
            {
                MessageBox.Show("Не найдено текущее изображение для шифрации.", "Внимание!");
                return;
            }
            if (TextBoxText.Text.Length == 0)
            {
                MessageBox.Show("Введите сообщение, которое необходимо зашифровать.", "Внимание!");
                return;
            }
            sSecretText = TextBoxText.Text;
            Encryption();
            ProgressBarStatus.Value = 0;
            ProgressBarStatus.Maximum = 100;
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Выполнить дешифрование»
        /// </summary>
        private void ButtonDecryption_Click(object sender, EventArgs e)
        {
            ProgressBarStatus.Value = 0;
            ProgressBarStatus.Maximum = 100;
            if ((sCurrentNameImage == "") || (bitmapCurrentImage == null))
            {
                MessageBox.Show("Не найдено текущее изображение для дешифрации.", "Внимание!");
                return;
            }
            sSecretText = "";
            TextBoxText.Text = "";
            Decryption();
            ProgressBarStatus.Value = 0;
            ProgressBarStatus.Maximum = 100;
        }
        /// <summary>
        /// Событие при нажатии по кнопке «Сохранить файл изображения» (Google)
        /// </summary>
        private void ButtonGoogleSaveFile_Click(object sender, EventArgs e)
        {
            ProgressBarStatus.Maximum = 100;
            ProgressBarStatus.Value = 0;
            // Проверка подключения к Google Drive
            if (!varGoogleDrive.isConnection)
            {
                MessageBox.Show("Вы не авторизованы в системе Google Drive.", "Внимание!");
                return;
            }
            // Проверка переменных, отвечающих за текущее изображение
            if ((sCurrentNameImage == "") || (bitmapCurrentImage == null))
            {
                MessageBox.Show("Не найдено текущее изображение, которое необходимо сохранить.", "Внимание!");
                return;
            }
            // Проверка временного файла
            if (!System.IO.File.Exists(sTempPath + sCurrentNameImage))
            {
                MessageBox.Show("Не найден временный файл зашифрованного изображения.", "Внимание!");
                return;
            }
            ProgressBarStatus.Value = 50;
            // Сохранение
            SaveFileGoogleDriveFrom fromSaveFileGoogleDrive = new SaveFileGoogleDriveFrom("NEW_" + sCurrentNameImage);
            if (fromSaveFileGoogleDrive.ShowDialog() == DialogResult.OK)
            {

                if (!varGoogleDrive.uploadFileToGoogleDrive(sTempPath, sCurrentNameImage, fromSaveFileGoogleDrive.GetNameFile()))
                {
                    MessageBox.Show(varGoogleDrive.sError, "Ошибка!");
                    return;
                }
            }
            ProgressBarStatus.Value = 0;
            ProgressBarStatus.Maximum = 100;
        }
    }
}
