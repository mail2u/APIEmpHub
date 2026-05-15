using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceStepTemplateController : baseController<ServiceStepTemplateModels>
    {
        public ServiceStepTemplateController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceStepTemplateModels> logger)
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
        public IActionResult Create(ServiceStepTemplateModels iProp)
        {
            this._logger.LogInformation("ServiceStepTemplate_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceStepTemplate_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(ServiceStepTemplateModels iProp)
        {
            this._logger.LogInformation("ServiceStepTemplate_Update [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceStepTemplate_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Sort")]
        public IActionResult Sort(ServiceStepTemplateModels iProp)
        {
            this._logger.LogInformation("ServiceStepTemplate_Sort [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Sort(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceStepTemplate_Sort [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ServiceStepTemplateModels iProp)
        {
            this._logger.LogInformation("ServiceStepTemplate_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceStepTemplate_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(ServiceStepTemplateModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.stepId
                    ,
                    x.cateId
                    ,
                    x.stepIndex
                    ,
                    x.status
                    ,
                    x.statusDesc
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
