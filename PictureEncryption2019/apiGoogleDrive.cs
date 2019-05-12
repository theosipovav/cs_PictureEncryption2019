using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using Google.Apis.Drive.v3.Data;
using System.Net;
using System.Windows.Forms;
using System.Reflection;

namespace PictureEncryption2019
{
    class apiGoogleDrive
    {
        /* Общие переменные для класса */
        public bool isError;                                                // Флаг наличия ошибки
        public bool isConnection;                                           // Флаг наличия соединения
        public string sError;                                               // Текст ошибки
        private string sPathDirApp;                                         // Путь к временной папке пользователя
        /* Переменне для API Google Drive */
        private string[] Scopes = { DriveService.Scope.Drive };             // Скопы для подключения к Google Drive
        private string ApplicationName = "PictureEncryption2019";           // Имя проекта, создаваемого при получение <client_id.json>
        private UserCredential googleUserCredential;                        // Класс для интегрированной аутентификации Google Drive на ПК
        //private string sPathClientIdJSON;                                   // Созданный файл <client_id.json> для подключения к Google Drive
        private DriveService varDriveService;                               // Класс API функций Google Drive
        /// <summary>
        /// Конструктор класса <apiGoogleDrive>
        /// </summary>
        public apiGoogleDrive()
        {
            isError = false;
            sError = null;
            sPathDirApp = Path.GetTempPath();
            //sPathClientIdJSON = Environment.CurrentDirectory + @"\Resources\client_id.json";
            if (checkConection())
            {
                isConnection = true;
                ConnectionGoogleDrive();
            }
        }
        /// <summary>
        /// Проверка на наличие раннее созданного токена для Google Drive API
        /// </summary>
        private bool checkConection()
        {
            try
            {
                return System.IO.File.Exists(sPathDirApp + "Google.Apis.Auth.OAuth2.Responses.TokenResponse-user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace, "Ошибка!");
                return false;
            }
        }
        /// <summary>
        /// Попытка выполнить соединение с Google Drive API
        /// </summary>
        /// <returns></returns>
        public bool ConnectionGoogleDrive()
        {
            try
            {
                googleUserCredential = GetCredentials();
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = googleUserCredential,
                    ApplicationName = ApplicationName,
                });
                varDriveService = service;
                isConnection = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace;
                isError = true;
                return false;
            }
            return true;
        }
        /// <summary>
        /// Получение токена Google Drive API для текущего пользователя
        /// </summary>
        private UserCredential GetCredentials()
        {
            UserCredential credential;
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (StreamReader stream = new StreamReader(assembly.GetManifestResourceStream("PictureEncryption2019.Resources.client_id.json")))
            {
                ClientSecrets varClientSecrets = GoogleClientSecrets.Load(stream.BaseStream).Secrets;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(varClientSecrets, Scopes, "user", CancellationToken.None, new FileDataStore(sPathDirApp, true)).Result;
            }
            return credential;
        }
        /// <summary>
        /// Получает коллекцию файлов
        /// </summary>
        public List<Google.Apis.Drive.v3.Data.File> getListFiles()
        {
            List<Google.Apis.Drive.v3.Data.File> varGoogleDriveFiles_Return = new List<Google.Apis.Drive.v3.Data.File>();
            IList<Google.Apis.Drive.v3.Data.File> varGoogleDriveFiles;
            try
            {
                FilesResource.ListRequest listRequest = varDriveService.Files.List();
                varGoogleDriveFiles = listRequest.Execute().Files;

                varGoogleDriveFiles_Return.AddRange(varGoogleDriveFiles);
                return varGoogleDriveFiles_Return;
            }
            catch (Exception excError)
            {
                MessageBox.Show(excError.Message, "Ошибка!");
                return null;

            }
        }
        /// <summary>
        /// Получает имя присоедененного пользователя
        /// </summary>
        public string getUserName()
        {
            try
            {
                var requestDriveService = varDriveService.About.Get();
                requestDriveService.Fields = "user";
                About aboutGoogleDrive = requestDriveService.Execute();
                string sUserName = aboutGoogleDrive.User.DisplayName;
                return sUserName;
            }
            catch (Exception ex)
            {
                sError = ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace;
                isError = true;
                return null;
            }

        }
        /// <summary>
        /// Удаление текущего токена (Google Drive API) пользователя 
        /// </summary>
        public bool Disconnect(string sPathTempDirApp)
        {
            try
            {
                string sPathTokenGoogleDrive = sPathTempDirApp + "Google.Apis.Auth.OAuth2.Responses.TokenResponse-user";
                if (System.IO.File.Exists(sPathTokenGoogleDrive))
                {
                    System.IO.File.Delete(sPathTokenGoogleDrive);
                }
                isConnection = false;
                isError = false;
                sError = null;
                googleUserCredential = null;
                varDriveService = null;
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace;
                isError = true;
                return false;
            }
        }
        /// <summary>
        /// Получить Bitmap скаенной картики из Google Drive
        /// </summary>
        public Bitmap getBitmapImage(Google.Apis.Drive.v3.Data.File varGoogleDriveFile)
        {
            Bitmap bitmapResBitmap = null;
            try
            {
                var requestDriveService = varDriveService.Files.Get(varGoogleDriveFile.Id);
                var stream = new System.IO.MemoryStream();
                requestDriveService.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case Google.Apis.Download.DownloadStatus.Downloading:
                            {
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Completed:
                            {
                                Stream myStream = stream;
                                System.Drawing.Image image = System.Drawing.Image.FromStream(myStream);

                                bitmapResBitmap = new Bitmap(image);
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Failed:
                            {
                                break;
                            }
                    }
                };
                requestDriveService.Download(stream);
                return bitmapResBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace, "Ошибка!");
                return null;
            }
        }
        /// <summary>
        /// Скачивание файла в Google Drive
        /// </summary>
        public Stream downloadFileFromGoogleDrive(Google.Apis.Drive.v3.Data.File varGoogleDriveFile)
        {
            Stream streamReturn = null;
            try
            {
                var requestDriveService = varDriveService.Files.Get(varGoogleDriveFile.Id);
                var stream = new System.IO.MemoryStream();
                requestDriveService.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case Google.Apis.Download.DownloadStatus.Downloading:
                            {
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Completed:
                            {
                                streamReturn = stream;
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Failed:
                            {
                                MessageBox.Show("Не удалось скачать файл из Google Drive", "Внимание!");
                                break;
                            }
                    }
                };
                requestDriveService.Download(stream);
                return streamReturn;
            }
            catch (Exception ex)
            {
                sError = ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace;
                isError = true;
                return null;
            }
        }
        /// <summary>
        /// Загрузка файла в Google Drive
        /// </summary>
        public bool uploadFileToGoogleDrive(string sPathDirAppTemp, string sCurrentNameImage, string sNewNameFile)
        {
            try
            {
                var varGoogleFile = new Google.Apis.Drive.v3.Data.File();
                varGoogleFile.Name = sNewNameFile;
                FilesResource.CreateMediaUpload req;
                using (var stream = new FileStream(sPathDirAppTemp + "\\" + sCurrentNameImage, FileMode.Open))
                {
                    req = varDriveService.Files.Create(varGoogleFile, stream, "");
                    req.Upload();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message + "\n\nПодробное описание:\n" + ex.StackTrace;
                isError = true;
                return false;
            }
            return true;
        }
    }
}