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
    public class ChartController : baseController<ChartModels>
    {
        public ChartController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ChartModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ChartModels iProp)
        {
            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(ChartModels iProp)
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

        [Authorize("Admin")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ChartModels iProp)
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
        public IActionResult DataList(ChartModels iProp)
        {
            lData = new List<ChartModels>();

            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.chartId
                    ,
                    x.title
                    ,
                    x.description
                    ,
                    x.color
                    ,
                    x.font_size
                    ,
                    x.font_bold
                    ,
                    x.sub_color
                    ,
                    x.sub_font_size
                    ,
                    x.sub_font_bold
                    ,
                    x.bg
                    ,
                    x.stroke
                    ,
                    x.stroke_width
                    ,
                    x.status
                    ,
                    x.create_by
                    ,
                    x.create_date
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ChartModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.chartId
                    ,
                    iData.title
                    ,
                    iData.description
                    ,
                    iData.color
                    ,
                    iData.font_size
                    ,
                    iData.font_bold
                    ,
                    iData.sub_color
                    ,
                    iData.sub_font_size
                    ,
                    iData.sub_font_bold
                    ,
                    iData.bg
                    ,
                    iData.stroke
                    ,
                    iData.stroke_width
                    ,
                    iData.status
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
