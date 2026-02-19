using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTrainingController : baseController<ServiceTrainingModels>
    {
        public ServiceTrainingController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceTrainingModels> logger)
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
        public IActionResult Save(List<ServiceTrainingModels> lProp)
        {
            try
            {
                this._logger.LogInformation("Servicetraining Save : " + JsonConvert.SerializeObject(lProp));

                foreach (ServiceTrainingModels iProp in lProp)
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
        public IActionResult Detail(ServiceTrainingModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.trainingId
                    ,
                    x.mode
                    ,
                    x.license
                    ,
                    x.organization
                    ,
                    x.issueDate
                    ,
                    x.expireDate
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
