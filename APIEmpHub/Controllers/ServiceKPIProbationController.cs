using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceKPIProbationController : baseController<ServiceKPIProbationModels>
    {
        public ServiceKPIProbationController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceKPIProbationModels> logger)
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
        public IActionResult Save(List<ServiceKPIProbationModels> lProp)
        {
            try
            {
                int order_index = 1;
                lProp = lProp.Select(x =>
                {
                    x.order_index = order_index++;
                    return x;
                }).ToList();

                this._logger.LogInformation("ServicKPIProbation Save : " + JsonConvert.SerializeObject(lProp));
                model.Save(lProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceKPIProbationModels iProp)
        {
            try
            {
                lData = model.Detail(iProp);

                var vData = lData.Select(x => new 
                {
                    x.refId
                    ,
                    x.performance_indicator
                    ,
                    x.target
                    ,
                    x.weight
                    ,
                    x.performance_result
                    ,
                    x.answer
                    ,
                    x.order_index
                    ,
                    x.create_date
                }).ToList();

                return Ok(new { iProp.can_edit, data = vData });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
