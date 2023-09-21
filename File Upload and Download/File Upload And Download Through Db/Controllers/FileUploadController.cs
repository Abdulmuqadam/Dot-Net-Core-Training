using File_Upload_And_Download_Through_Db.Interface;
using File_Upload_And_Download_Through_Db.Model;
using Microsoft.AspNetCore.Mvc;

namespace File_Upload_And_Download_Through_Db.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileRepository _fileRepo;

        public FileUploadController(IFileRepository fileRepo)
        {
            _fileRepo = fileRepo;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileData = memoryStream.ToArray();
                var fileName = file.FileName;

                var newFile = new FileEntity
                {
                    FileName = fileName,
                    FileData = fileData,
                };

                await _fileRepo.AddAsync(newFile);

                return Ok("File Uploaded Successfully");
            }
        }
    }
}
