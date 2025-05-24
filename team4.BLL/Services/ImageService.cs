using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace team4.BLL.Services
{
    public class ImageService
    {
        private readonly string _imageFolderPath;

        public ImageService(IWebHostEnvironment env)
        {
            _imageFolderPath = Path.Combine(env.WebRootPath, "images");

            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                throw new ArgumentException("File not provided or it is empty.");

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);

            var filePath = Path.Combine(_imageFolderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return uniqueFileName;
        }
    }
}
