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
    public class SurveyQuestionController : baseController<SurveyQuestionModels>
    {
        public SurveyQuestionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveyQuestionModels> logger)
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
        public IActionResult Create(SurveyQuestionModels iProp)
        {
            this._logger.LogInformation("SurveyQuestion_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyQuestion_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(SurveyQuestionModels iProp)
        {
            this._logger.LogInformation("SurveyQuestion_Update [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyQuestion_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Reorder")]
        public IActionResult Reorder(SurveyQuestionModels iProp)
        {
            this._logger.LogInformation("SurveyQuestion_Reorder [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Reorder(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyQuestion_Reorder [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(SurveyQuestionModels iProp)
        {
            this._logger.LogInformation("SurveyQuestion_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyQuestion_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SurveyQuestionModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.sectionId
                    ,
                    x.title
                    ,
                    x.description
                    ,
                    x.type
                    ,
                    x.is_required
                    ,
                    x.order_index
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
