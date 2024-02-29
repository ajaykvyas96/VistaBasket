using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Entities.Entities.Enum;

namespace VistaBasket.Catalog.Service.Interface
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(FilePathEnum fileLocation, IFormFile file, List<string> supportedTypes = null);
        Task<bool> DeleteFile(FilePathEnum fileLocation, string filePath);
        Task<string> GetFileUrl(FilePathEnum fileLocation, string fileName);
    }
}
