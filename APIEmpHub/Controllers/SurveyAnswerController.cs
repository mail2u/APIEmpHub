using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyAnswerController : baseController<SurveyAnswerModels>
    {
        public SurveyAnswerController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveyAnswerModels> logger)
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
        public IActionResult Create(List<SurveyAnswerModels> lProp)
        {
            this._logger.LogInformation("SurveyAnswer_Create [Request] : " + HelperConvert.ConvertToSerialize(lProp));

            try
            {
                foreach (var iProp in lProp)
                {
                    model.Create(iProp);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyAnswer_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SurveyAnswerModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.responseId
                    ,
                    x.questionId
                    ,
                    x.choiceId
                    ,
                    x.choiceText
                    ,
                    x.answerText
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataListBySurvey")]
        public IActionResult DataListBySurvey(SurveyAnswerModels iProp)
        {
            try
            {
                lData = model.DataListBySurvey(iProp);

                var vData = lData.Select(x => new
                {
                    x.questionId
                    ,
                    x.choiceId
                    ,
                    x.answerText
                    ,
                    x.total
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
