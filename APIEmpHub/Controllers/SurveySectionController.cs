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
    public class SurveySectionController : baseController<SurveySectionModels>
    {
        public SurveySectionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveySectionModels> logger)
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
        public IActionResult Create(SurveySectionModels iProp)
        {
            this._logger.LogInformation("SurveySection_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveySection_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(SurveySectionModels iProp)
        {
            this._logger.LogInformation("SurveySection_Update [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveySection_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Reorder")]
        public IActionResult Reorder(SurveySectionModels iProp)
        {
            this._logger.LogInformation("SurveySection_Reorder [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Reorder(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveySection_Reorder [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(SurveySectionModels iProp)
        {
            this._logger.LogInformation("SurveySection_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveySection_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SurveySectionModels iProp)
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
                    x.title
                    ,
                    x.description
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
