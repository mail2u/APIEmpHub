using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicePersonalController : baseController<ServicePersonalModels>
    {
        public ServicePersonalController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServicePersonalModels> logger)
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
        public IActionResult Save(ServicePersonalModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServicePersonal Save : " + JsonConvert.SerializeObject(iProp));
                model.Save(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(ServicePersonalModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServicePersonal Cancel : " + JsonConvert.SerializeObject(iProp));
                model.Cancel(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServicePersonalModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.personalId
                    ,
                    iData.firstname_th
                    ,
                    iData.lastname_th
                    ,
                    iData.firstname_en
                    ,
                    iData.lastname_en
                    ,
                    iData.nickname
                    ,
                    iData.sex
                    ,
                    iData.birth_date
                    ,
                    iData.maritalStatus
                    ,
                    iData.email
                    ,
                    iData.phoneNo
                    ,
                    iData.status
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DetailByRef")]
        public IActionResult DetailByRef(ServicePersonalModels iProp)
        {
            try
            {
                iData = model.DetailByRef(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.personalId
                    ,
                    iData.firstname_th
                    ,
                    iData.lastname_th
                    ,
                    iData.firstname_en
                    ,
                    iData.lastname_en
                    ,
                    iData.nickname
                    ,
                    iData.sex
                    ,
                    iData.birth_date
                    ,
                    iData.maritalStatus
                    ,
                    iData.email
                    ,
                    iData.phoneNo
                    ,
                    iData.status
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
