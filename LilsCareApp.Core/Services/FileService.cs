using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace LilsCareApp.Core.Services
{
    public class FileService : IFileService
    {

        // Delete a file from the server at wwwroot/files
        public void DeleteFile(string filePath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + filePath);
            try
            {
                // Check if the file exists
                if (File.Exists(fullPath))
                {
                    // Delete the file
                    File.Delete(fullPath);
                    Console.WriteLine($"File {fullPath} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"File {fullPath} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Save a file to the server at wwwroot/files
        // Return the file path
        public async Task<string?> SaveFile(IFormFile files)
        {
            // Generate a unique filename using the current date and time
            string fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Path.GetFileName(files.FileName)}";
            var filePath = Path.Combine("files", fileName);
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

            // Save the file to the server
            using (var stream = new FileStream(uploadDirectory, FileMode.Create))
            {
                await files.CopyToAsync(stream);
            }

            return "\\" + filePath;
        }
    }
}
