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
    public class ServiceRelationController : baseController<ServiceRelationModels>
    {
        public ServiceRelationController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceRelationModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [Authorize("HRService")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ServiceRelationModels iProp)
        {
            this._logger.LogInformation("ServiceRelation_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceRelation_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("HRService")]
        [HttpPost]
        [Route("Replace")]
        public IActionResult Replace(ServiceRelationModels iProp)
        {
            this._logger.LogInformation("ServiceRelation_Replace [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Replace(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceRelation_Replace [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("HRService")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ServiceRelationModels iProp)
        {
            this._logger.LogInformation("ServiceRelation_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("ServiceRelation_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("HRService")]
        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(ServiceRelationModels iProp)
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
                    x.userId
                    ,
                    x.fullname
                    ,
                    x.status
                    ,
                    x.condition1
                }).ToList();

                return Ok(vData);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Report")]
        public IActionResult Report()
        {
            try
            {
                dtData = model.Report();

                return Ok(new
                {
                    data = Newtonsoft.Json.JsonConvert.SerializeObject(dtData)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
