using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Catalog.Service.Extensions
{
    public static class IFormFileExtenstion
    {
        public static byte[] ReadFileContentAsByteArray(this IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Copy the file content to the memory stream
                file.CopyTo(memoryStream);

                // Return the byte array representing the file content
                return memoryStream.ToArray();
            }
        }
    }
}
