using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyChoiceController : baseController<SurveyChoiceModels>
    {
        public SurveyChoiceController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveyChoiceModels> logger)
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
        public IActionResult Create(SurveyChoiceModels iProp)
        {
            this._logger.LogInformation("SurveyChoice_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyChoice_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(SurveyChoiceModels iProp)
        {
            this._logger.LogInformation("SurveyChoice_Update [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyChoice_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Reorder")]
        public IActionResult Reorder(SurveyChoiceModels iProp)
        {
            this._logger.LogInformation("SurveyChoice_Reorder [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Reorder(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyChoice_Reorder [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(SurveyChoiceModels iProp)
        {
            this._logger.LogInformation("SurveyChoice_Delete [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SurveyChoice_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SurveyChoiceModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.questionId
                    ,
                    x.text
                    ,
                    x.value
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
