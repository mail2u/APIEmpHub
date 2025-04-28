using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionController : baseController<FunctionModels>
    {
        public FunctionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<FunctionModels> logger)
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
        public IActionResult DataList(FunctionModels iProp)
        {
            lData = new List<FunctionModels>();

            try
            {
                lData = model.DataList(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.funcId
                ,
                x.funcCode
                ,
                x.title
                ,
                x.detail
            }).ToList();

            return Ok(vData);
        }
    }
}
