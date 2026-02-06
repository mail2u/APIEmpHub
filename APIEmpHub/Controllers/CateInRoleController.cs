using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CateInRoleController : baseController<CateInRoleModels>
    {
        public CateInRoleController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<CateInRoleModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CateInRoleModels iProp)
        {
            this._logger.LogInformation("CateInRole_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("CateInRole_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(CateInRoleModels iProp)
        {
            this._logger.LogInformation("CateInRole_Delete [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("CateInRole_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("AllList")]
        public IActionResult AllList(CateInRoleModels iProp)
        {
            try
            {
                lData = model.AllList(iProp);

                var vData = lData.Select(x => new
                {
                    x.parentId
                    ,
                    x.cateId
                    ,
                    x.cateDesc
                    ,
                    x.description
                    ,
                    x.allow_every
                    ,
                    x.order_index
                    ,
                    x.is_authen
                    ,
                    x.lSub
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
