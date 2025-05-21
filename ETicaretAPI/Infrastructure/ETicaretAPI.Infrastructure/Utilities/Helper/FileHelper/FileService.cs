using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Utilities.Helper.FileHelper
{
    public class FileServiceHelper : IFileService
    {
        #region FileDelete
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true; // Fayl uğurla silindi
            }

            return false; // Fayl tapılmadı
        }


        #endregion

        #region GetImageByProductID
        public async Task<List<string>> GetFileByProductIdAsync(string productId)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products", productId);

            if (!Directory.Exists(path))
            {
                return new List<string>(); // Yəni: Fayl yoxdur → boş siyahı döndər
            }

            var files = Directory.GetFiles(path);
            var fileNames = files.Select(file => Path.GetFileName(file)).ToList();

            return await Task.FromResult(fileNames);
        }
        #endregion

        #region File Update
        public async Task<string> UpdateAsync(IFormFile formFile, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // formFile-i IFormFileCollection tipinə çevirmək
            IFormFileCollection fileCollection = new FormFileCollection { formFile };

            List<string> uploadedFiles = await UploadAsync(fileCollection, root);

            return uploadedFiles.FirstOrDefault(); // tək fayl üçün
        }

        #endregion

        #region File Upload
        public async Task<List<string>> UploadAsync(IFormFileCollection files, string path)
        {
            List<string> uploadedFileNames = new();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string extension = Path.GetExtension(formFile.FileName);
                    string guid = GuidHelper.GuidHelper.CreateGuid();
                    string fileName = guid + extension;
                    string fullPath = Path.Combine(path, fileName);

                    using FileStream fileStream = File.Create(fullPath);
                    await formFile.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();

                    uploadedFileNames.Add(fileName);
                }
            }

            return uploadedFileNames;
        }
        #endregion
    }
}
