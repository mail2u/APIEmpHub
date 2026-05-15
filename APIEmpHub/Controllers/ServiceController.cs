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
                    iData.subCategoryCode
                    ,
                    iData.subCategoryDesc
                    ,
                    iData.title
                    ,
                    iData.status
                    ,
                    iData.statusCss
                    ,
                    iData.statusDesc
                    ,
                    iData.userName
                    ,
                    iData.userPosition
                    ,
                    iData.userDepartment
                    ,
                    iData.createName
                    ,
                    iData.createPosition
                    ,
                    iData.createDepartment
                    ,
                    iData.createDate
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
                    ,
                    iData.can_work
                    ,
                    iData.can_previous
                    ,
                    iData.can_edit
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ServiceModels iProp)
        {
            try
            {
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Request")]
        public IActionResult Request(ServiceModels iProp)
        {
            try
            {
                model.Request(iProp);

                return Ok(iProp);
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
        [Route("Work")]
        public IActionResult Work(ServiceModels iProp)
        {
            try
            {
                model.Work(iProp);
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
                x.subCategoryCode
                ,
                x.subCategoryDesc
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
                x.subCategoryCode
                ,
                x.subCategoryDesc
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

        [HttpPost]
        [Route("WorkList")]
        public IActionResult WorkList(ServiceModels iProp)
        {
            try
            {
                lData = model.WorkList(iProp);
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
                x.subCategoryCode
                ,
                x.subCategoryDesc
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
        [Route("WorkSummary")]
        public IActionResult WorkSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.WorkSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("InquireList")]
        public IActionResult InquireList(ServiceModels iProp)
        {
            try
            {
                lData = model.InquireList(iProp);
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
                x.subCategoryCode
                ,
                x.subCategoryDesc
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
        [Route("InquireSummary")]
        public IActionResult InquireSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.InquireSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        #region Dashboard
        [HttpPost]
        [Route("DashboardCategorySummary")]
        public IActionResult DashboardCategorySummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardCategorySummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserCategorySummary")]
        public IActionResult DashboardUserCategorySummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserCategorySummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardCategoryWait")]
        public IActionResult DashboardCategoryWaity()
        {
            try
            {
                dtData = model.DashboardCategoryWait();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardSubCategorySummary")]
        public IActionResult DashboardSubCategorySummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardSubCategorySummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserSubCategorySummary")]
        public IActionResult DashboardUserSubCategorySummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserSubCategorySummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardDepartmentSummary")]
        public IActionResult DashboardDepartmentSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardDepartmentSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserDepartmentSummary")]
        public IActionResult DashboardUserDepartmentSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserDepartmentSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardDepartmentWait")]
        public IActionResult DashboardDepartmentWait()
        {
            try
            {
                dtData = model.DashboardDepartmentWait();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardStatusToday")]
        public IActionResult DashboardStatusToday()
        {
            try
            {
                dtData = model.DashboardStatusToday();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardStatusSummary")]
        public IActionResult DashboardStatusSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardStatusSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserStatusSummary")]
        public IActionResult DashboardUserStatusSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserStatusSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardStatusCurrent")]
        public IActionResult DashboardStatusCurrent()
        {
            try
            {
                dtData = model.DashboardStatusCurrent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardYearSummary")]
        public IActionResult DashboardYearSummary()
        {
            try
            {
                dtData = model.DashboardYearSummary();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserYearSummary")]
        public IActionResult DashboardUserYearSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserYearSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardMonthSummary")]
        public IActionResult DashboardMonthSummary()
        {
            try
            {
                dtData = model.DashboardMonthSummary();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardDaySummary")]
        public IActionResult DashboardDaySummary()
        {
            try
            {
                dtData = model.DashboardDaySummary();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardWorkMonthSummary")]
        public IActionResult DashboardWorkMonthSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardWorkMonthSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardWorkYearSummary")]
        public IActionResult DashboardWorkYearSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardWorkYearSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardWorkSummary")]
        public IActionResult DashboardWorkSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardWorkSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardApproveMonthSummary")]
        public IActionResult DashboardApproveMonthSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardApproveMonthSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserRequestWaitApproveSummary")]
        public IActionResult DashboardUserRequestWaitApproveSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserRequestWaitApproveSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardUserRequestWaitWorkSummary")]
        public IActionResult DashboardUserRequestWaitWorkSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardUserRequestWaitWorkSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardApproveYearSummary")]
        public IActionResult DashboardApproveYearSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardApproveYearSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardApproveSummary")]
        public IActionResult DashboardApproveSummary(ServiceModels iProp)
        {
            try
            {
                dtData = model.DashboardApproveSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DashboardWorkSLA")]
        public IActionResult DashboardWorkSLA(ServiceModels iProp)
        {
            try
            {
                dsData = model.DashboardWorkSLA(iProp);

                return Ok(JsonConvert.SerializeObject(dsData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DashboardApproveSLA")]
        public IActionResult DashboardApproveSLA(ServiceModels iProp)
        {
            try
            {
                dsData = model.DashboardApproveSLA(iProp);

                return Ok(JsonConvert.SerializeObject(dsData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DashboardRequestNoClose")]
        public IActionResult DashboardRequestNoClose(ServiceModels iProp)
        {
            try
            {
                dsData = model.DashboardRequestNoClose(iProp);

                return Ok(JsonConvert.SerializeObject(dsData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

    }
}
