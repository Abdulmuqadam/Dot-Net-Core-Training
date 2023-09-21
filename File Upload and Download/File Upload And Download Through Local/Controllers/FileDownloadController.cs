using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace FileUploadAndDownloadThroughLocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        [HttpGet]
        [Route("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(_uploadFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File Not found");
            }
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var contentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();
            if (provider.TryGetContentType(fileName, out var guessedContentType))
            {
                contentType = guessedContentType;
            }
            return File(fileStream, contentType, fileName);
        }
    }
}
