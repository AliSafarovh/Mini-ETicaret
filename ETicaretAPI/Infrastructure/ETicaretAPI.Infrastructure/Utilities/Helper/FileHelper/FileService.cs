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
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                Console.WriteLine("Yanlış bir yol yazdınız");
            }
        }
        #endregion

        #region File Update
        public string Update(IFormFile formFile, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(formFile, root);
        }
        #endregion

        #region File Upload
        public string Upload(IFormFile formFile, string root)
        {
            if (formFile.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string existsion = Path.GetExtension(formFile.FileName);
                string guid = GuidHelper.GuidHelper.CreateGuid();
                string filePath = guid + existsion;

                using (FileStream fileStream = File.Create(Path.Combine(root, filePath)))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
        #endregion
    }
}
