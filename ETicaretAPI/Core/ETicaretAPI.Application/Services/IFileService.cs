using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services
{
    public  interface IFileService
    {
        Task<List<string>> UploadAsync(IFormFileCollection files, string path);
        void Delete(string filePath);
        Task<string> UpdateAsync(IFormFile formFile, string filePath, string root);

    }
}
