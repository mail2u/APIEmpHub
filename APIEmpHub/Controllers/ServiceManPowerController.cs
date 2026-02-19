using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceManPowerController : baseController<ServiceManPowerModels>
    {
        public ServiceManPowerController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceManPowerModels> logger)
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
        public IActionResult Save(ServiceManPowerModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServicManPower Save : " + JsonConvert.SerializeObject(iProp));
                model.Save(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceManPowerModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.position
                    ,
                    iData.department
                    ,
                    iData.required_date
                    ,
                    iData.num_employee
                    ,
                    iData.type_employment
                    ,
                    iData.type_employment_desc
                    ,
                    iData.type_requirement
                    ,
                    iData.type_reason
                    ,
                    iData.type_reason_additional_hire_desc
                    ,
                    iData.type_reason_replacement_desc
                    ,
                    iData.description_work
                    ,
                    iData.sex
                    ,
                    iData.age
                    ,
                    iData.education
                    ,
                    iData.major
                    ,
                    iData.knowledge
                    ,
                    iData.skill_language
                    ,
                    iData.skill_language_desc
                    ,
                    iData.skill_computer
                    ,
                    iData.skill_computer_desc
                    ,
                    iData.skill_other
                    ,
                    iData.skill_other_desc
                    ,
                    iData.type_experience
                    ,
                    iData.type_experience_yes_desc
                    ,
                    iData.type_experience_other_desc
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
