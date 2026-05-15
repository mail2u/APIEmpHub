using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : baseController<SurveyModels>
    {
        public SurveyController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SurveyModels> logger)
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
        public IActionResult Create(SurveyModels iProp)
        {
            this._logger.LogInformation("Survey_Create [Request] : " + JsonConvert.SerializeObject(iProp));

            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Survey_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(SurveyModels iProp)
        {
            this._logger.LogInformation("Survey_Update [Request] : " + JsonConvert.SerializeObject(iProp));

            try
            {
                model.Update(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Survey_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(SurveyModels iProp)
        {
            this._logger.LogInformation("Survey_Delete [Request] : " + JsonConvert.SerializeObject(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Survey_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Publish")]
        public IActionResult Publish(SurveyModels iProp)
        {
            this._logger.LogInformation("Survey_Publish [Request] : " + JsonConvert.SerializeObject(iProp));

            try
            {
                model.Publish(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Survey_Publish [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(SurveyModels iProp)
        {
            this._logger.LogInformation("Survey_Cancel [Request] : " + JsonConvert.SerializeObject(iProp));

            try
            {
                model.Cancel(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Survey_Cancel [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(SurveyModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.id
                    ,
                    iData.title
                    ,
                    iData.description
                    ,
                    iData.start_date
                    ,
                    iData.end_date
                    ,
                    iData.mode
                    ,
                    iData.status
                    ,
                    iData.create_by
                    ,
                    iData.create_date
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
        public IActionResult DataList(SurveyModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.title
                    ,
                    x.description
                    ,
                    x.start_date
                    ,
                    x.end_date
                    ,
                    x.total
                    ,
                    x.mode
                    ,
                    x.status
                    ,
                    x.create_by
                    ,
                    x.create_date
                }).ToList();

                return Ok(new { data = vData, total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Summary")]
        public IActionResult Summary(SurveyModels iProp)
        {
            try
            {
                dtData = model.Summary(iProp);

                return Ok(JsonConvert.SerializeObject(dtData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("MyList")]
        public IActionResult MyList(SurveyModels iProp)
        {
            try
            {
                lData = model.MyList(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.title
                    ,
                    x.description
                    ,
                    x.start_date
                    ,
                    x.end_date
                    ,
                    x.total
                    ,
                    x.mode
                    ,
                    x.status
                    ,
                    x.create_by
                    ,
                    x.create_date
                }).ToList();

                return Ok(new { data = vData, total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("MySummary")]
        public IActionResult MySummary(SurveyModels iProp)
        {
            try
            {
                dtData = model.MySummary(iProp);

                return Ok(JsonConvert.SerializeObject(dtData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
