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
    public class DepartmentController : baseController<DepartmentModels>
    {

        public DepartmentController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<DepartmentModels> logger)
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
        public IActionResult Create(DepartmentModels iProp)
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

        [Authorize("Admin")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(DepartmentModels iProp)
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
        public IActionResult Delete(DepartmentModels iProp)
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

        [Authorize("Admin")]
        [HttpPost]
        [Route("SetParent")]
        public IActionResult SetParent(DepartmentModels iProp)
        {
            try
            {
                model.SetParent(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(DepartmentModels iProp)
        {
            lData = new List<DepartmentModels>();

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
                x.parentCode
                ,
                x.desc_th
                ,
                x.desc_en
                ,
                x.groupCode
                ,
                x.buCode
                ,
                x.create_date
                ,
                x.create_by
            }).ToList();

            return Ok(vData);
        }
    }
}
