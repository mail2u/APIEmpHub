using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : baseController<CategoryModels>
    {
        public CategoryController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<CategoryModels> logger)
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
        public IActionResult Create(CategoryModels iProp)
        {
            this._logger.LogInformation("Category_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Category_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(CategoryModels iProp)
        {
            this._logger.LogInformation("Category_Update [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Category_Updaet [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Sort")]
        public IActionResult Sort(CategoryModels iProp)
        {
            try
            {
                model.Sort(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(CategoryModels iProp)
        {
            this._logger.LogInformation("Category_Delete [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Category_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(CategoryModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.sysId
                    ,
                    x.cateId
                    ,
                    x.categoryCode
                    ,
                    x.categoryDesc
                    ,
                    x.description
                    ,
                    x.allow_every
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("AllList")]
        public IActionResult AllList(CateInRoleModels iProp)
        {
            try
            {
                List<CateInRoleModels> lData = model.AllList(iProp);

                var vData = lData.Select(x => new
                {
                    x.parentId
                    ,
                    x.cateId
                    ,
                    x.cateCode
                    ,
                    x.cateDesc
                    ,
                    x.description
                    ,
                    x.allow_every
                    ,
                    x.order_index
                    ,
                    x.lSub
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AuthenList")]
        public IActionResult AuthenList(CategoryModels iProp)
        {
            try
            {
                List<CateInRoleModels> lData = model.AuthenList(iProp);

                var vData = lData.Select(x => new
                {
                    x.parentId
                    ,
                    x.cateId
                    ,
                    x.cateCode
                    ,
                    x.cateDesc
                    ,
                    x.description
                    ,
                    x.order_index
                    ,
                    x.lSub
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Report")]
        public IActionResult Report(CategoryModels iProp)
        {
            try
            {
                dtData = model.Report(iProp);

                return Ok(new
                {
                    data = Newtonsoft.Json.JsonConvert.SerializeObject(dtData)
                    ,
                    iProp.total
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ReportProcess")]
        public IActionResult ReportProcess(CategoryModels iProp)
        {
            try
            {
                dtData = model.ReportProcess(iProp);

                return Ok(new
                {
                    data = Newtonsoft.Json.JsonConvert.SerializeObject(dtData)
                    ,
                    iProp.total
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("CategoryByCode")]
        public IActionResult CategoryByCode(CategoryModels iProp)
        {
            try
            {
                lData = model.CategoryByCode(iProp);

                var vData = lData.Select(x => new
                {
                    x.sysId
                    ,
                    x.cateId
                    ,
                    x.categoryCode
                    ,
                    x.categoryDesc
                    ,
                    x.subCateId
                    ,
                    x.subCategoryCode
                    ,
                    x.subCategoryDesc
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
