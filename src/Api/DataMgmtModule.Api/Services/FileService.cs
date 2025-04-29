namespace DataMgmtModule.Api.Services
{
    public class FileService
    {
        private readonly string _defaultPath;
        public FileService()
        {
            _defaultPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        }
        public async Task<string> UploadAsync(IFormFile file, string? customPath = null)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Invalid File");

            // Clean the file name
            var cleanedFileName = CleanFileName(file.FileName);

            // Get file extension (in lowercase)
            var extension = Path.GetExtension(cleanedFileName).ToLower();

            // Allow only PDF files
            if (extension != ".pdf")
                throw new Exception("Only PDF files are allowed.");

            // Determine the subfolder based on file extension

            var subFolder = "PDFs";
            //string subFolder = extension switch
            //{
            //    ".pdf" => "PDFs",
            //    ".jpg" or ".jpeg" or ".png" => "Images",
            //    ".mp4" or ".avi" or ".mov" or ".wmv" or ".mkv" or ".webm" => "Videos",
            //    ".mp3" or ".wav" or ".aiff" => "Audios",
            //    _ => "Others"
            //};

            // Combine root path with subfolder
            var targetPath = Path.Combine(customPath ?? _defaultPath, subFolder);

            // Create directory if it doesn't exist
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            // Full file path with the cleaned file name
            var fullPath = Path.Combine(targetPath, cleanedFileName);

            // Save the file to disk
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative path
            //return Path.Combine(subFolder, cleanedFileName);
            return Path.Combine("Uploads", subFolder, cleanedFileName).Replace("\\", "/");
        }

        private string CleanFileName(string originalFileName)
        {
            // Trim leading/trailing spaces
            var trimmedName = originalFileName.Trim();

            // Replace spaces with underscores
            var noSpaces = trimmedName.Replace(" ", "_");

            // Remove invalid characters (keep letters, digits, -, _, and .)
            var cleaned = string.Concat(noSpaces.Where(c => char.IsLetterOrDigit(c) || c == '-' || c == '_' || c == '.'));

            // Split the cleaned name into file name and extension
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(cleaned);
            var extension = Path.GetExtension(cleaned);

            // Append timestamp to ensure uniqueness
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var finalName = $"{fileNameWithoutExtension}_{timestamp}{extension}";

            return finalName;
        }


        public async Task<byte[]> DownloadAsync(string fileName, string? customPath = null)
        {
            var rootPath = customPath ?? _defaultPath;

            // Search in all subdirectories for the file
            var allFiles = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
            var matchedFile = allFiles.FirstOrDefault(f => Path.GetFileName(f).Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (matchedFile == null)
                throw new FileNotFoundException("File Not Found");

            return await File.ReadAllBytesAsync(matchedFile);
        }
    }
}
