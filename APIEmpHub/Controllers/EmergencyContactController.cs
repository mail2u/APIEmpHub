using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmergencyContactController : baseController<EmergencyContactModels>
    {
        public EmergencyContactController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<EmergencyContactModels> logger)
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
        public IActionResult Create(EmergencyContactModels iProp)
        {
            this._logger.LogInformation("EmergencyContact_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("EmergencyContact_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(EmergencyContactModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.refId
                    ,
                    x.fullname
                    ,
                    x.relation
                    ,
                    x.phoneNo
                    ,
                    x.address
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
