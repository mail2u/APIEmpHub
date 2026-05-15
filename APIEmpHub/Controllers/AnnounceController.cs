using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnnounceController : baseController<AnnounceModels>
    {
        public AnnounceController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<AnnounceModels> logger)
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
        public IActionResult Create(AnnounceModels iProp)
        {
            this._logger.LogInformation("Announce_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                model.Create(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Announce_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }

            return Ok(iProp);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(AnnounceModels iProp)
        {
            try
            {
                model.Update(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(AnnounceModels iProp)
        {
            try
            {
                model.Delete(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(AnnounceModels iProp)
        {
            lData = new List<AnnounceModels>();

            try
            {
                lData = model.DataList(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.id
                ,
                x.coverId
                ,
                x.title
                ,
                x.detail
                ,
                x.is_active
                ,
                x.update_date
            }).ToList();

            return Ok(vData);
        }
    }
}
