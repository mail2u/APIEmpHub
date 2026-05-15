using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceProcessController : baseController<ServiceProcessModels>
    {
        public ServiceProcessController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceProcessModels> logger)
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
        public IActionResult Create(ServiceProcessModels iProp)
        {
            this._logger.LogInformation("ServiceProcess_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceProcess_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(ServiceProcessModels iProp)
        {
            this._logger.LogInformation("ServiceProcess_Update [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceProcess_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ServiceProcessModels iProp)
        {
            this._logger.LogInformation("ServiceProcess_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceProcess_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(ServiceProcessModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.rn
                    ,
                    x.sysId
                    ,
                    x.name
                    ,
                    x.level
                }).ToList();

                return Ok(vData);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
