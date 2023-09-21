using File_Upload_And_Download_Through_Db.Interface;
using Microsoft.AspNetCore.Mvc;

namespace File_Upload_And_Download_Through_Db.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileDownloadController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var fileEntities = await _fileRepository.GetAllAsync();

            if (fileEntities == null || fileEntities.Count == 0)
            {
                return NotFound();
            }
            var fileList = fileEntities.Select(file => new
            {
                FileId = file.Id,
                filename = file.FileName,
            }).ToList();
            return Ok(fileList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownLoadFile(int id)
        {
            var fileEntity = await _fileRepository.GetByIdAsync(id);

            if (fileEntity == null)
            {
                return BadRequest("File not found");
            }
            return File(fileEntity.FileData, "application/octet-stream", fileEntity.FileName);
        }
    }
}
