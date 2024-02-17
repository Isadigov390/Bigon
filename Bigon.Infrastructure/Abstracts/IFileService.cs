using Microsoft.AspNetCore.Http;

namespace Bigon.Infrastructure.Abstracts
{
    public  interface IFileService
    {
        public  Task<string> UploadAsync(IFormFile file);
        public  Task<string> ChangeFileAsync(string oldFilePath,IFormFile file);
    }
}
