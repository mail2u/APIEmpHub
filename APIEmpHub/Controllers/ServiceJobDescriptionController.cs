using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceJobDescriptionController : baseController<ServiceJobDescriptionModels>
    {
        public ServiceJobDescriptionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceJobDescriptionModels> logger)
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
        public IActionResult Save(ServiceJobDescriptionModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServicJobDescription Save : " + JsonConvert.SerializeObject(iProp));
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
        public IActionResult Detail(ServiceJobDescriptionModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.positionName
                    ,
                    iData.jobFunction
                    ,
                    iData.departmentName
                    ,
                    iData.sectionName
                    ,
                    iData.position_description
                    ,
                    iData.major_description
                    ,
                    iData.education
                    ,
                    iData.experience
                    ,
                    iData.functional_competencies
                    ,
                    iData.leadership_competencies
                    ,
                    iData.financial
                    ,
                    iData.customer_and_market
                    ,
                    iData.process
                    ,
                    iData.people_development
                    ,
                    iData.internal_description
                    ,
                    iData.internal_contact_description
                    ,
                    iData.external_description
                    ,
                    iData.external_contact_description
                };

                return Ok(new { iProp.can_edit, data = vData });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
