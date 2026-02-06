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
    public class ServiceStepTemplateActionController : baseController<ServiceStepTemplateActionModels>
    {
        public ServiceStepTemplateActionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceStepTemplateActionModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ServiceStepTemplateActionModels iProp)
        {
            this._logger.LogInformation("ServiceStepTemplateAction_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceStepTemplateAction_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ServiceStepTemplateActionModels iProp)
        {
            this._logger.LogInformation("ServiceStepTemplateAction_Delete [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceStepTemplateAction_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(ServiceStepTemplateActionModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.rn
                    ,
                    x.stepId
                    ,
                    x.actionBy
                    ,
                    x.actionName
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
