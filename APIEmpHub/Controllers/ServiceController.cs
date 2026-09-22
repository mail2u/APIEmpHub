using APIEmpHub.Extension;
using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : baseController<ServiceModels>
    {
        public WebAPIModels _webAPI = new WebAPIModels();
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
            this._webAPI = this._configuration.GetSection("WebAPI").Get<WebAPIModels>();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
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
                    iData.can_assign
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
                iProp.createBy = User.UserId();
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
        public async Task<IActionResult> Request(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.Request(iProp);
                model.ApproveMail(iProp);

                await SendMail(iProp);

                model.MailResponse(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RequestResend")]
        public IActionResult RequestResend(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.RequestResend(iProp);

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
                iProp.userBy = User.UserId();
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
        public async Task<IActionResult> Reject(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.Reject(iProp);

                //model.RejectMail(iProp);

                //await SendMail(iProp);

                //model.MailResponse(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Approve")]
        public async Task<IActionResult> Approve(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.Approve(iProp);

                if(iProp.status.ToLower() == "complete")
                {
                    model.CompleteMail(iProp);

                    //if(iProp.subCategoryCode.ToLower() == "form_employee_data")
                    //{
                    //    await SendMailEmployeeData(iProp);
                    //}
                }
                else
                {
                    model.ApproveMail(iProp);
                }

                await SendMail(iProp);
                model.MailResponse(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Assign")]
        public IActionResult Assign(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.Assign(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Work")]
        public async Task<IActionResult> Work(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.Work(iProp);

                if (iProp.status.ToLower() == "complete")
                {
                    model.CompleteMail(iProp);

                    await SendMail(iProp);
                    model.MailResponse(iProp);

                    if (iProp.subCategoryCode.ToLower() == "form_employee_data")
                    {
                        await SendMailEmployeeData(iProp);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Previous")]
        public IActionResult Previous(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                model.Previous(iProp);
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
                iProp.userBy = User.UserId();
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
                iProp.userBy = User.UserId();
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
                iProp.userBy = User.UserId();
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
                iProp.userBy = User.UserId();
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
                iProp.userBy = User.UserId();
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
                iProp.userBy = User.UserId();
                dtData = model.WorkSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("OnBehalfList")]
        public IActionResult OnBehalfList(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                lData = model.OnBehalfList(iProp);
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
                x.statusDesc
                ,
                x.userId
                ,
                x.userName
                ,
                x.employeeCode
                ,
                x.userDepartment
                ,
                x.userSection
                ,
                x.createDate
            });

            return Ok(JsonConvert.SerializeObject(new { data = vData, total = iProp.total }));
        }

        [HttpPost]
        [Route("OnBehalfSummary")]
        public IActionResult OnBehalfSummary(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
                dtData = model.OnBehalfSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("CreateBulk")]
        public IActionResult CreateBulk(ServiceModels iProp)
        {
            try
            {
                /* ผู้สร้างต้องมาจาก token เสมอ ห้ามเชื่อค่าที่หน้าจอส่งมา */
                iProp.createBy = User.UserId();
                model.CreateBulk(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(new
            {
                total_created = iProp.total_created,
                total_skip = iProp.total_skip,
                /* หน้าจอต้องได้ batchId กลับไป เพื่อให้ toast มีปุ่มเรียกกลับทั้งชุด */
                batchId = iProp.batchId
            }));
        }

        [HttpPost]
        [Route("CancelBatch")]
        public IActionResult CancelBatch(ServiceModels iProp)
        {
            try
            {
                /* บังคับจาก token ห้ามเชื่อค่าที่หน้าจอส่งมา
                   ไม่งั้นจะยกเลิกชุดของ HR คนอื่นได้ */
                iProp.userBy = User.UserId();
                model.CancelBatch(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(new
            {
                total_cancel = iProp.total_cancel,
                total_expired = iProp.total_expired,
                total_filled = iProp.total_filled
            }));
        }

        [HttpPost]
        [Route("InquireList")]
        public IActionResult InquireList(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
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
        [Route("RequiredDocumentList")]
        public IActionResult RequiredDocumentList(ServiceModels iProp)
        {
            try
            {
                lData = model.RequiredDocumentList(iProp);
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
                x.statusDesc
                ,
                x.createBy
                ,
                x.createName
                ,
                x.createDate
                ,
                x.actionDate
                ,
                x.orderDate1
                ,
                x.orderDate2
            }).ToList();

            return Ok(new { data = vData });
        }

        [HttpPost]
        [Route("InquireSummary")]
        public IActionResult InquireSummary(ServiceModels iProp)
        {
            try
            {
                iProp.userBy = User.UserId();
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


        #region SendMail
        private async Task SendMail(ServiceModels iProp)
        {
            if (String.IsNullOrEmpty(iProp.mailId)) { return; }

            using (var httpClient = new HttpClient())
            {
                var dataRequest = new
                {
                    id = iProp.mailId
                };

                StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dataRequest), Encoding.UTF8, "application/json");

                try
                {
                    using (var response = await httpClient.PostAsync(this._webAPI.APIWebDriverX + "/webhook/CoreHRSendMail", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            this._logger.LogInformation("Service_SendMail [Success] : " + apiResponse);
                            iProp.is_send = 1;
                        }
                        else
                        {
                            this._logger.LogInformation("Service_SendMail [Fail] : " + apiResponse);
                            iProp.is_send = 0;
                            iProp.ErrorMessage = apiResponse;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogInformation("Service_SendMail [Error] : " + ex.Message);

                    throw new Exception(ex.Message);
                }
            }
        }


        private async Task SendMailEmployeeData(ServiceModels iProp)
        {
            if (String.IsNullOrEmpty(iProp.id)) { return; }

            using (var httpClient = new HttpClient())
            {
                var dataRequest = new
                {
                    id = iProp.id
                };

                StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dataRequest), Encoding.UTF8, "application/json");

                try
                {
                    using (var response = await httpClient.PostAsync(this._webAPI.APIWebDriverX + "/webhook/CoreHRSendMailEmployeeData", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            this._logger.LogInformation("Service_SendMailEmployeeData [Success] : " + apiResponse);
                        }
                        else
                        {
                            this._logger.LogInformation("Service_SendMailEmployeeData [Fail] : " + apiResponse);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogInformation("Service_SendMailEmployeeData [Error] : " + ex.Message);

                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion
    }
}
