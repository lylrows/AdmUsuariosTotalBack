using HumanManagement.CrossCutting.Utils;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagementApi.Models
{
    public class FormFileStream
    {
        public string FullPath { get; private set; }
        private string folderPath;
        private string fileNameFolder;
        public string fileName;
        private AppSettings appSettings;
        private IFormFileCollection formFiles;
        public FormFileStream(AppSettings appSettings, 
                                string fileNameFolder,
                                IFormFileCollection formFiles)
        {
            this.appSettings = appSettings;
            this.fileNameFolder = fileNameFolder;
            this.formFiles = formFiles;
        }

        public void Save()
        {
            if (formFiles.Count > 0)
            {
                CreateFolder();
                var file = formFiles[0];
                string ext = Path.GetExtension(ContentDispositionHeaderValue
                                                .Parse(file.ContentDisposition)
                                                .FileName.Trim('"'));
                fileName = $"{Path.GetRandomFileName()}{ext}";
                var pathFileToSave = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(pathFileToSave, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                SetFullPath();
            }
        }

        public void SavePhoto()
        {
            if (formFiles.Count > 0)
            {
                CreateFolderPhoto();
                var file = formFiles[0];
                string ext = Path.GetExtension(ContentDispositionHeaderValue
                                                .Parse(file.ContentDisposition)
                                                .FileName.Trim('"'));
                fileName = $"{Path.GetRandomFileName()}{ext}";
                var pathFileToSave = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(pathFileToSave, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                SetFullPathPhoto();
            }
        }

        private void CreateFolderPhoto()
        {
            folderPath = $"{appSettings.PathSaveFile}{fileNameFolder}";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private void CreateFolder()
        {
            folderPath = $"{appSettings.PathSaveFile}";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private void SetFullPath()
        {
            FullPath = $"{appSettings.PathSaveFile}{fileName}";
        }

        private void SetFullPathPhoto()
        {
            FullPath = $"{appSettings.PathSaveFile}{fileNameFolder}{fileName}";
        }
    }
}
