using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FuncInRoleController : baseController<FuncInRoleModels>
    {
        public FuncInRoleController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<FuncInRoleModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [Authorize("Authorization")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(FuncInRoleModels iProp)
        {
            try
            {
                model.Create(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(iProp);
        }

        [Authorize("Authorization")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(FuncInRoleModels iProp)
        {
            try
            {
                model.Delete(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(iProp);
        }

        [Authorize("Authorization")]
        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(FuncInRoleModels iProp)
        {
            lData = new List<FuncInRoleModels>();

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
                x.roleId
                ,
                x.title
            }).ToList();

            return Ok(vData);
        }
    }
}
