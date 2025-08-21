using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrgChartController : baseController<OrgChartModels>
    {
        public OrgChartController(IConfiguration configuration
            , IWebHostEnvironment hostingEnvironment
            , ILogger<OrgChartModels> logger)
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
        public IActionResult Create(OrgChartModels iProp)
        {
            try
            {
                this._logger.LogInformation("OrgChart Create : " + JsonConvert.SerializeObject(iProp));
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(OrgChartModels iProp)
        {
            try
            {
                this._logger.LogInformation("OrgChart Delete : " + JsonConvert.SerializeObject(iProp));
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(OrgChartModels iProp)
        {
            try
            {
                this._logger.LogInformation("OrgChart Update : " + JsonConvert.SerializeObject(iProp));
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList()
        {
            try
            {
                lData = model.DataList(new OrgChartModels());

                var vData = lData.Select(x => new
                {
                    x.chartId
                    ,
                    x.id
                    ,
                    x.parentId
                    ,
                    x.title
                    ,
                    x.name
                    ,
                    x.levelOffset
                }).ToList();

                return Ok(new { data = vData, total = lData.Count() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
