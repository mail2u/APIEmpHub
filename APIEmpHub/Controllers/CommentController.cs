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
    public class CommentController : baseController<CommentModels>
    {
        public CommentController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<CommentModels> logger)
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
        public IActionResult Create(CommentModels iProp)
        {
            try
            {
                model.Create(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(iProp);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(CommentModels iProp)
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
        public IActionResult DataList(CommentModels iProp)
        {
            lData = new List<CommentModels>();

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
                x.refId
                ,
                x.mode
                ,
                x.detail
                ,
                x.create_by
                ,
                x.create_department
                ,
                x.create_date
                ,
                x.can_delete
            }).ToList();

            return Ok(new { data = vData, total = lData.Count() });
        }
    }
}
