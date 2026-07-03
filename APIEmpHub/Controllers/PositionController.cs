using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : baseController<PositionModels>
    {

        public PositionController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<PositionModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [Authorize("Setting")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(PositionModels iProp)
        {
            try
            {
                model.Create(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [Authorize("Setting")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(PositionModels iProp)
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

        [Authorize("Setting")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(PositionModels iProp)
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
        public IActionResult DataList(PositionModels iProp)
        {
            lData = new List<PositionModels>();

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
                x.rn
                ,
                x.code
                ,
                x.desc_th
                ,
                x.desc_en
                ,
                x.shortCode
                ,
                x.levelCode
                ,
                x.create_date
                ,
                x.create_by
            }).ToList();

            return Ok(vData);
        }
    }
}
