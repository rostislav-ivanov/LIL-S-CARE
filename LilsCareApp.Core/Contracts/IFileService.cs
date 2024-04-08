using Microsoft.AspNetCore.Http;

namespace LilsCareApp.Core.Contracts
{
    public interface IFileService
    {
        public void DeleteFile(string filePath);
        Task<string?> SaveFile(IFormFile files);
    }
}
