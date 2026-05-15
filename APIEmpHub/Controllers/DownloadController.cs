using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DownloadController : baseController<DownloadModels>
    {
        public DownloadController(IConfiguration configuration
            , IWebHostEnvironment hostingEnvironment
            , ILogger<DownloadModels> logger)
        {
            this._configuration = configuration;
            //model.connectionString = this._configuration.GetConnectionString("Connection");
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("FormStorage")]
        public async Task<IActionResult> FormStorage(DownloadModels iProp)
        {
            try
            {
                model.GetFilePath(iProp);

                var filePath = Path.Combine(
                model.webRoot,
                "storage",
                "documents",
                iProp.filename);

                if (!System.IO.File.Exists(filePath))
                    return NotFound();

                // save log

                var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

                return File(
                    bytes,
                    "application/pdf",
                    iProp.filename);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
