using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTraningController : baseController<ServiceTraningModels>
    {
        public ServiceTraningController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceTraningModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(ServiceTraningModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceTraning Save : " + JsonConvert.SerializeObject(iProp));
                model.Save(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Clone")]
        public IActionResult Clone(ServiceTraningModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceTraning Clone : " + JsonConvert.SerializeObject(iProp));
                model.Clone(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(ServiceTraningModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceTraning Cancel : " + JsonConvert.SerializeObject(iProp));
                model.Cancel(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(ServiceTraningModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceTraning Delete : " + JsonConvert.SerializeObject(iProp));
                model.Delete(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceTraningModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.traningId
                    ,
                    x.mode
                    ,
                    x.license
                    ,
                    x.organization
                    ,
                    x.issueDate
                    ,
                    x.expireDate
                    ,
                    x.description
                    ,
                    x.status
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DetailByRef")]
        public IActionResult DetailByRef(ServiceTraningModels iProp)
        {
            try
            {
                lData = model.DataListByRef(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.traningId
                    ,
                    x.mode
                    ,
                    x.license
                    ,
                    x.organization
                    ,
                    x.issueDate
                    ,
                    x.expireDate
                    ,
                    x.description
                    ,
                    x.status
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
