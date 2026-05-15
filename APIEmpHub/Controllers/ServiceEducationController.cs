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
    public class ServiceEducationController : baseController<ServiceEducationModels>
    {
        public ServiceEducationController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceEducationModels> logger)
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
        public IActionResult Save(List<ServiceEducationModels> lProp)
        {
            try
            {
                this._logger.LogInformation("ServiceEducation Save : " + JsonConvert.SerializeObject(lProp));

                foreach (ServiceEducationModels iProp in lProp)
                {
                    model.Save(iProp);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceEducationModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.educationId
                    ,
                    x.mode
                    ,
                    x.institution
                    ,
                    x.degreeCode
                    ,
                    x.degreeName
                    ,
                    x.programCode
                    ,
                    x.programName
                    ,
                    x.major
                    ,
                    x.year
                    ,
                    x.grade
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
