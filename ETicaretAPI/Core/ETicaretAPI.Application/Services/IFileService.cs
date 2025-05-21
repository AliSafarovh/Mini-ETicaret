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
        bool Delete(string filePath);
        //Task<string> UpdateAsync(IFormFile formFile, string filePath, string root);
        Task<List<string>> GetFileByProductIdAsync(string productId);
    }
}
