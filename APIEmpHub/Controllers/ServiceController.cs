using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : baseController<ServiceModels>
    {
        public ServiceController(IConfiguration configuration
            , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceModels> logger)
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
        [Route("Detail")]
        public IActionResult Detail(ServiceModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.id
                    ,
                    iData.userId
                    ,
                    iData.serviceNo
                    ,
                    iData.categoryCode
                    ,
                    iData.categoryDesc
                    ,
                    iData.title
                    ,
                    iData.status
                    ,
                    iData.statusCss
                    ,
                    iData.statusDesc
                    ,
                    iData.createName
                    ,
                    iData.createDate
                    ,
                    iData.userName
                    ,
                    iData.userPosition
                    ,
                    iData.userDepartment
                    ,
                    iData.approveName
                    ,
                    iData.approveDate
                    ,
                    iData.rejectName
                    ,
                    iData.rejectDate
                    ,
                    iData.rejectDesc
                    ,
                    iData.can_cancel
                    ,
                    iData.can_approve
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cancel")]
        public IActionResult Cancel(ServiceModels iProp)
        {
            try
            {
                model.Cancel(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Reject")]
        public IActionResult Reject(ServiceModels iProp)
        {
            try
            {
                model.Reject(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Approve")]
        public IActionResult Approve(ServiceModels iProp)
        {
            try
            {
                model.Approve(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("RequestList")]
        public IActionResult RequestList(ServiceModels iProp)
        {
            try
            {
                lData = model.RequestList(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.id
                ,
                x.serviceNo
                ,
                x.categoryCode
                ,
                x.categoryDesc
                ,
                x.title
                ,
                x.status
                ,
                x.statusCss
                ,
                x.statusDesc
                ,
                x.createBy
                ,
                x.createName
                ,
                x.createDate
                ,
                x.actionDate
            }).ToList();

            return Ok(new { data = vData, total = iProp.total });
        }

        [HttpPost]
        [Route("RequestSummary")]
        public IActionResult RequestSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.RequestSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("ApproveList")]
        public IActionResult ApproveList(ServiceModels iProp)
        {
            try
            {
                lData = model.ApproveList(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.id
                ,
                x.serviceNo
                ,
                x.categoryCode
                ,
                x.categoryDesc
                ,
                x.title
                ,
                x.status
                ,
                x.statusCss
                ,
                x.statusDesc
                ,
                x.createBy
                ,
                x.createName
                ,
                x.createDate
                ,
                x.actionDate
            }).ToList();

            return Ok(new { data = vData, total = iProp.total });
        }

        [HttpPost]
        [Route("ApproveSummary")]
        public IActionResult ApproveSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.ApproveSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

    }
}
