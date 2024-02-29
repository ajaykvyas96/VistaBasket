//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.AspNetCore.Hosting;
//using System.Text;
//using System.Threading.Tasks;
//using VistaBasket.Catalog.Entities.Entities.Enum;
//using VistaBasket.Catalog.Service.Interface;

//namespace VistaBasket.Catalog.Service.Service
//{
//    public class FileUploadService : IFileUploadService
//    {
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        public UploadService(IWebHostEnvironment webHostEnvironment)
//        {
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public async Task<string> UploadFile(FilePathEnum fileLocation, IFormFile file, List<string> supportedTypes = null)
//        {
//            if (file.Length > 0)
//            {
//                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

//                string imageDir = AccessPathOnCategory(fileLocation);
//                if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
//                {
//                    _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
//                }

//                if (CheckFileExtension(extension, supportedTypes))
//                {
//                    string pathBuilt = Path.Combine(_webHostEnvironment.WebRootPath, imageDir);
//                    if (!Directory.Exists(pathBuilt))
//                    {
//                        Directory.CreateDirectory(pathBuilt);
//                    }

//                    string fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.
//                    imageDir += fileName;
//                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, imageDir);

//                    using (var stream = new FileStream(serverFolder, FileMode.Create))
//                    {
//                        await file.CopyToAsync(stream);
//                    }

//                    return fileName;
//                }
//                throw new Exception("Invalid file format.");
//            }
//            throw new Exception("Invalid file.");

//        }
//        private bool CheckFileExtension(string fileExt, List<string> supportedTypes)
//        {
//            if (supportedTypes != null && !supportedTypes.Contains(fileExt.ToLower()))
//            {
//                return false;
//            }
//            return true;
//        }

//        public async Task<bool> DeleteFile(FilePathEnum accessCat, string filePath)
//        {
//            if (!string.IsNullOrEmpty(filePath))
//            {
//                if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
//                {
//                    _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
//                }
//                string fileName = filePath.Split('/')[filePath.Split('/').Length - 1];

//                string imageDir = AccessPathOnCategory(accessCat);
//                imageDir += fileName;
//                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, imageDir);

//                if (System.IO.File.Exists(serverFolder))
//                {
//                    System.IO.File.Delete(serverFolder);
//                    return true;
//                }

//                return true;
//            }

//            throw new ArgumentException("File path cannot be empty.", nameof(filePath));
//        }

//        public async Task<string> GetFileUrl(FilePathEnum fileLocation, string fileName)
//        {
//            string fileDir = AccessPathOnCategory(fileLocation);
//            var path = fileDir + fileName;
//            return path;
//        }

//        private string AccessPathOnCategory(FilePathEnum accessCat)
//        {
//            switch (accessCat)
//            {
//                case FilePathEnum.Association:
//                    return "upload/association/";
//                case FilePathEnum.Beneficiary:
//                    return "upload/beneficiary/";
//                case FilePathEnum.projectManagement:
//                    return "upload/projectManagement/";
//                case FilePathEnum.FeatureImage:
//                    return "upload/";
//                default:
//                    return "upload/";

//            }

//        }
//    }
//}
