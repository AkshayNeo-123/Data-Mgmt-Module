using DataMgmtModule.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;
        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost("FileUpload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var fileName = await _fileService.UploadAsync(file);
                return Ok(new
                {
                    message = "Uploaded",
                    fileName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpGet("FileDownload")]
        public async Task<IActionResult> DownloadFile([FromQuery] string url)
        {
            try
            {
                string fileName = Path.GetFileName(url);
                var fileBytes = await _fileService.DownloadAsync(fileName);
                return File(fileBytes, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    error = ex.Message
                });
            }
        }
    }
}
