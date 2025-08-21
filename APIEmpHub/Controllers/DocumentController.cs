using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : baseController<DocumentModels>
    {
        public DocumentController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<DocumentModels> logger)
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
        public IActionResult Create(DocumentModels iProp)
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
        [Route("Update")]
        public IActionResult Update(DocumentModels iProp)
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
        public IActionResult Delete(DocumentModels iProp)
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
        public IActionResult DataList(DocumentModels iProp)
        {
            lData = new List<DocumentModels>();

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
                x.docId
                ,
                x.title
                ,
                x.cover
                ,
                x.detail
            }).ToList();

            return Ok(vData);
        }
    }
}
