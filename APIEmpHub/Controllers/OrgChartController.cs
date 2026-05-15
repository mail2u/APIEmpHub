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
                this._logger.LogInformation("OrgChart_Create : " + JsonConvert.SerializeObject(iProp));
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
                this._logger.LogInformation("OrgChart_Delete : " + JsonConvert.SerializeObject(iProp));
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
                this._logger.LogInformation("OrgChart_Update : " + JsonConvert.SerializeObject(iProp));
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Lock")]
        public IActionResult Lock(OrgChartModels iProp)
        {
            try
            {
                model.Lock(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("UpdatePosition")]
        public IActionResult UpdatePosition(OrgChartModels iProp)
        {
            try
            {
                this._logger.LogInformation("OrgChart_UpdatePosition : " + JsonConvert.SerializeObject(iProp));
                model.UpdatePosition(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateParent")]
        public IActionResult UpdateParent(OrgChartModels iProp)
        {
            try
            {
                this._logger.LogInformation("OrgChart_UpdateParent : " + JsonConvert.SerializeObject(iProp));
                model.UpdateParent(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(OrgChartModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.chartId
                    ,
                    x.mode
                    ,
                    x.id
                    ,
                    x.parentId
                    ,
                    x.title
                    ,
                    x.name
                    ,
                    x.description
                    ,
                    x.position
                    ,
                    x.department
                    ,
                    x.type
                    ,
                    x.levelOffset
                    ,
                    x.pos_x
                    ,
                    x.pos_y
                    ,
                    x.pos_w
                    ,
                    x.pos_h
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
                    x.link
                    ,
                    x.is_lock
                }).ToList();

                return Ok(new { data = vData, total = lData.Count() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost]
        //[Route("Company")]
        //public IActionResult Company(OrgChartModels iProp)
        //{
        //    try
        //    {
        //        lData = model.Company(iProp);

        //        var vData = lData.Select(x => new
        //        {
        //            x.id
        //            ,
        //            x.parentId
        //            ,
        //            x.title
        //            ,
        //            x.name
        //            ,
        //            x.levelOffset
        //            ,
        //            x.pos_x
        //            ,
        //            x.pos_y
        //        }).ToList();

        //        return Ok(new { data = vData, total = lData.Count() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPost]
        [Route("Team")]
        public IActionResult Team(OrgChartModels iProp)
        {
            try
            {
                lData = model.Team(iProp);

                var vData = lData.Select(x => new
                {
                    x.id
                    ,
                    x.parentId
                    ,
                    x.title
                    ,
                    x.name
                    ,
                    x.position
                    ,
                    x.department
                    ,
                    x.type
                    ,
                    x.levelOffset
                    ,
                    x.pos_x
                    ,
                    x.pos_y
                    ,
                    x.pos_w
                    ,
                    x.pos_h
                }).ToList();

                return Ok(new { data = vData, total = lData.Count() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("TeamMy")]
        public IActionResult TeamMy(OrgChartModels iProp)
        {
            try
            {
                iData = model.TeamMy(iProp);

                var vData = new
                {
                    iData.teamId
                    ,
                    iData.teamName
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("TeamMember")]
        public IActionResult TeamMember(OrgChartModels iProp)
        {
            try
            {
                lData = model.TeamMember(iProp);

                var vData = lData.Select(x => new
                {
                    x.empId
                    ,
                    x.name
                    ,
                    x.position
                    ,
                    x.hasChildTeam
                });

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("EmployeeTeam")]
        public IActionResult EmployeeTeam(OrgChartModels iProp)
        {
            try
            {
                lData = model.EmployeeTeam(iProp);

                var vData = lData.Select(x => new
                {
                    x.teamId
                    ,
                    x.teamName
                    ,
                    x.hasChildTeam
                });

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
