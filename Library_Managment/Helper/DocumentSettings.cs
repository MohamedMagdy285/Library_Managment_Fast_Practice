using Microsoft.AspNetCore.Mvc;

namespace Library_Managment.PL.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            string filename = $"{Guid.NewGuid()}{file.FileName}";
            string filepath = Path.Combine(folderpath, filename);
            using var fs = new FileStream(filepath, FileMode.Create);
            file.CopyTo(fs);
            return filename;
        }
        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        public static PhysicalFileResult? DownloadFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "Files",
                folderName,
                fileName);

            if (!File.Exists(filePath))
                return null;

            return new PhysicalFileResult(filePath, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
        }
    }
}
