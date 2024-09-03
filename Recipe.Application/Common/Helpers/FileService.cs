namespace Recipe.Application.Common.Helpers
{
    public static class FileService
    {
        private static string _path;

        public static void Initialize(string path)
        {
            _path = path;
        }
        public static async Task<string> SaveImageAsync(byte[] imageData, string fileName, string folder = "uploads")
        {
            var uploadsFolder = Path.Combine(_path,"images", folder);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, fileName);
            await File.WriteAllBytesAsync(filePath, imageData);
            return Path.Combine($"/images/{folder}", fileName); 
        }
        public static async Task<bool> DeleteImageAsync(string fileName, string folder = "uploads")
        {
            var uploadsFolder = Path.Combine(_path, "images", folder);
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting file: {ex.Message}");
                    return await Task.FromResult(false);
                }
            }
            else
            {
                // File does not exist
                return await Task.FromResult(false);
            }
        }

    }

}
