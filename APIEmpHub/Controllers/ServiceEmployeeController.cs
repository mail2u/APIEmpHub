using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceEmployeeController : baseController<ServiceEmployeeModels>
    {
        public ServiceEmployeeController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceEmployeeModels> logger)
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
        public IActionResult Save(ServiceEmployeeModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceEmployee Save : " + JsonConvert.SerializeObject(iProp));
                model.Save(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(ServiceEmployeeModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceEmployee Cancel : " + JsonConvert.SerializeObject(iProp));
                model.Cancel(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceEmployeeModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.employeeId
                    ,
                    iData.employeeCode
                    ,
                    iData.employeeType
                    ,
                    iData.employeeDesc
                    , 
                    iData.email
                    ,
                    iData.ext
                    ,
                    iData.departmentCode
                    ,
                    iData.departmentDesc
                    ,
                    iData.positionCode
                    ,
                    iData.positionDesc
                    ,
                    iData.join_date
                    ,
                    iData.supervisorId
                    ,
                    iData.supervisorName
                    ,
                    iData.supervisorPosition
                    ,
                    iData.supervisorDepartment
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

        [HttpPost]
        [Route("DetailByRef")]
        public IActionResult DetailByRef(ServiceEmployeeModels iProp)
        {
            try
            {
                lData = model.DetailByRef(iProp);

                var vData = lData.Select(x=> new
                {
                    x.refId
                    ,
                    x.employeeId
                    ,
                    x.mode
                    ,
                    x.employeeCode
                    ,
                    x.employeeType
                    ,
                    x.employeeDesc
                    ,
                    x.email
                    ,
                    x.ext
                    ,
                    x.departmentCode
                    ,
                    x.departmentDesc
                    ,
                    x.positionCode
                    ,
                    x.positionDesc
                    ,
                    x.join_date
                    ,
                    x.supervisorId
                    ,
                    x.supervisorName
                    ,
                    x.supervisorPosition
                    ,
                    x.supervisorDepartment
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
