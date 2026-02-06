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
    public class SubCategoryController : baseController<SubCategoryModels>
    {
        public SubCategoryController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<SubCategoryModels> logger)
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
        public IActionResult Create(SubCategoryModels iProp)
        {
            this._logger.LogInformation("SubCategory_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SubCategory_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(SubCategoryModels iProp)
        {
            this._logger.LogInformation("SubCategory_Update [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Update(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SubCategory_Update [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Sort")]
        public IActionResult Sort(SubCategoryModels iProp)
        {
            this._logger.LogInformation("SubCategory_Sort [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Sort(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SubCategory_Sort [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(SubCategoryModels iProp)
        {
            this._logger.LogInformation("SubCategory_Delete [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("SubCategory_Delete [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(SubCategoryModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.parentId
                    ,
                    x.subCateId
                    ,
                    x.subCategoryCode
                    ,
                    x.subCategoryDesc
                    ,
                    x.description
                    ,
                    x.allow_every
                    ,
                    x.allow_pr_po
                    ,
                    x.allow_pr_non_po
                    ,
                    x.allow_pr_non_po_adv
                    ,
                    x.order_index
                    ,
                    x.min_amount
                    ,
                    x.max_amount
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
        public IActionResult AuthenList(SubCategoryModels iProp)
        {
            try
            {
                lData = model.AuthenList(iProp);

                var vData = lData.Select(x => new
                {
                    x.parentId
                    ,
                    x.subCateId
                    ,
                    x.subCategoryCode
                    ,
                    x.subCategoryDesc
                    ,
                    x.description
                    ,
                    x.min_amount
                    ,
                    x.max_amount
                    ,
                    x.allow_pr_po
                    ,
                    x.allow_pr_non_po
                    ,
                    x.allow_pr_non_po_adv
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
