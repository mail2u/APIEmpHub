using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceStepController : baseController<ServiceStepModels>
    {
        public ServiceStepController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceStepModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(ServiceStepModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.stepIndex
                    ,
                    x.status
                    ,
                    x.statusDesc
                    ,
                    x.actionBy
                    ,
                    x.actionName
                    ,
                    x.actionDate
                    ,
                    x.position
                    ,
                    x.department
                    ,
                    x.description
                    ,
                    x.is_action
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ActionList")]
        public IActionResult ActionList(ServiceStepModels iProp)
        {
            try
            {
                lData = model.ActionList(iProp);

                var vData = lData.Select(x => new
                {
                    x.actionBy
                    ,
                    x.actionName
                    ,
                    x.position
                    ,
                    x.department
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("WorkList")]
        public IActionResult WorkList(ServiceStepModels iProp)
        {
            try
            {
                lData = model.WorkList(iProp);

                var vData = lData.Select(x => new
                {
                    x.stepId
                    ,
                    x.stepIndex
                    ,
                    x.refId
                    ,
                    x.actionBy
                    ,
                    x.actionName
                    ,
                    x.actionDate
                    ,
                    x.position
                    ,
                    x.department
                    ,
                    x.can_delete
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("WorkDelete")]
        public IActionResult WorkDelete(ServiceStepModels iProp)
        {
            try
            {
                model.WorkDelete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
