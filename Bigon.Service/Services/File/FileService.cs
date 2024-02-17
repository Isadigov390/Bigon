using Bigon.Infrastructure.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Bigon.Application.Services.File
{
    public class FileService : IFileService
    {
        private readonly IHostEnvironment env;

        public FileService(IHostEnvironment env)
        {
            this.env = env;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {

            string extension = Path.GetExtension(file.FileName);
            string randomFileName = $"{Guid.NewGuid()}{extension}";
            string fullName = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", randomFileName);

            using (var fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }
            return randomFileName;
        }


        public Task<string> ChangeFileAsync(string oldFileName, IFormFile file)
        {
            string oldFilePath= Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", oldFileName);

            if (System.IO.File.Exists(oldFilePath))
            {
                string archiveFilePath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", $"archive-{oldFileName}");
                System.IO.File.Move(oldFilePath, archiveFilePath);
            }   
            return UploadAsync(file);
        }


      
    }
}
