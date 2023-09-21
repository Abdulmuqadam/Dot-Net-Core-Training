using Microsoft.AspNetCore.Mvc;

namespace FileUploadAndDownloadThroughLocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile()
        {
            var files = Request.Form.Files;
            if (files == null || files.Count == 0)
            {
                return BadRequest("No File Uploaded.");
            }
            foreach (var file in files)
            {
                if (file.Length == 0)                
                    continue;        
                var filePath = Path.Combine(_uploadFolder, file.Name);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok("File Uploaded Successfully.");
        }
    }
}
