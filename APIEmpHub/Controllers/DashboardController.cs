using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : baseController<DashboardModels>
    {
        public DashboardController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<DashboardModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList()
        {
            try
            {
                dsData = model.DataList();

                return Ok(JsonConvert.SerializeObject(dsData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
