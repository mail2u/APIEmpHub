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
    public class ServiceJobExperienceController : baseController<ServiceJobExperienceModels>
    {
        public ServiceJobExperienceController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceJobExperienceModels> logger)
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
        public IActionResult Save(ServiceJobExperienceModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceJobExperience Save : " + JsonConvert.SerializeObject(iProp));
                model.Save(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Clone")]
        public IActionResult Clone(ServiceJobExperienceModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceJobExperience Clone : " + JsonConvert.SerializeObject(iProp));
                model.Clone(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(ServiceJobExperienceModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceJobExperience Cancel : " + JsonConvert.SerializeObject(iProp));
                model.Cancel(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ServiceJobExperienceModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceJobExperience Delete : " + JsonConvert.SerializeObject(iProp));
                model.Delete(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceJobExperienceModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.jobId
                    ,
                    x.mode
                    ,
                    x.company
                    ,
                    x.position
                    ,
                    x.fromDate
                    ,
                    x.endDate
                    ,
                    x.description
                    ,
                    x.status
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DetailByRef")]
        public IActionResult DetailByRef(ServiceJobExperienceModels iProp)
        {
            try
            {
                lData = model.DataListByRef(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.jobId
                    ,
                    x.mode
                    ,
                    x.company
                    ,
                    x.position
                    ,
                    x.fromDate
                    ,
                    x.endDate
                    ,
                    x.description
                    ,
                    x.status
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
