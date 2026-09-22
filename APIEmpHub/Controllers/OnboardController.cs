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
    public class OnboardController : baseController<OnboardModels>
    {
        public OnboardController(IConfiguration configuration
            , IWebHostEnvironment hostingEnvironment
            , ILogger<OnboardModels> logger)
        {
            this._configuration = configuration;
            //model.connectionString = this._configuration.GetConnectionString("Connection");
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(OnboardModels iProp)
        {
            try
            {
                this._logger.LogInformation("Onboard Create : " + JsonConvert.SerializeObject(iProp));
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ExistsByIDCard")]
        public IActionResult ExistsByIDCard(OnboardModels iProp)
        {
            try
            {
                this._logger.LogInformation("Onboard ExistsByIDCard : " + JsonConvert.SerializeObject(iProp));
                lData = model.ExistsByIDCard(iProp);

                return Ok(lData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(OnboardModels iProp)
        {
            try
            {
                this._logger.LogInformation("Onboard Delete : " + JsonConvert.SerializeObject(iProp));
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(OnboardModels iProp)
        {
            try
            {
                this._logger.LogInformation("Onboard Cancel : " + JsonConvert.SerializeObject(iProp));
                model.Cancel(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Send")]
        public IActionResult Send(OnboardModels iProp)
        {
            try
            {
                this._logger.LogInformation("Onboard Send : " + JsonConvert.SerializeObject(iProp));
                model.Send(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Summary")]
        public IActionResult Summary(OnboardModels iProp)
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
        [Route("Detail")]
        public IActionResult Detail(OnboardModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.userId
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
        public IActionResult DataList(OnboardModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.userId
                    ,
                    x.employeeCode
                    ,
                    x.prefix_th
                    ,
                    x.firstname_th
                    ,
                    x.lastname_th
                    ,
                    x.prefix_en
                    ,
                    x.firstname_en
                    ,
                    x.lastname_en
                    ,
                    x.nickname
                    ,
                    x.employeeType
                    ,
                    x.position
                    ,
                    x.department
                    ,
                    x.division
                    ,
                    x.function
                    ,
                    x.join_date
                    ,
                    x.email
                    ,
                    x.ext
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

    }
}
