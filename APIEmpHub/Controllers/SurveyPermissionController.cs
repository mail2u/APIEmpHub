using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyPermissionController : baseController<SurveyPermissionModels>
    {
        public SurveyPermissionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveyPermissionModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(List<SurveyPermissionModels> lProp)
        {
            this._logger.LogInformation("SurveyPermission_Create [Request] : " + HelperConvert.ConvertToSerialize(lProp));

            try
            {
                foreach(var iProp in lProp)
                {
                    if (String.IsNullOrEmpty(iProp.id))
                    {
                        model.Create(iProp);
                    }
                    else if(iProp.is_active == 0)
                    {
                        model.Delete(iProp);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyPermission_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(SurveyPermissionModels iProp)
        {
            this._logger.LogInformation("SurveyPermission_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyPermission_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SurveyPermissionModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.surveyId
                    ,
                    x.permission_type
                    ,
                    x.refId
                    ,
                    x.description
                    ,
                    x.is_active
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
