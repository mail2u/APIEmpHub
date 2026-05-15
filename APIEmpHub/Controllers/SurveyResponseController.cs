using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyResponseController : baseController<SurveyResponseModels>
    {
        public SurveyResponseController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveyResponseModels> logger)
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
        public IActionResult Create(SurveyResponseModels iProp)
        {
            this._logger.LogInformation("SurveyResponse_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyResponse_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(SurveyResponseModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.id
                    ,
                    iData.surveyId
                    ,
                    iData.userId
                    ,
                    iData.create_date
                    ,
                    iData.device_name
                    ,
                    iData.ip_address
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SurveyResponseModels iProp)
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
                    x.userId
                    ,
                    x.create_date
                    ,
                    x.device_name
                    ,
                    x.ip_address
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
