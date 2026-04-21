using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.RegularExpressions;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : baseController<UserModels>
    {
        public UserController(IConfiguration configuration
            , IWebHostEnvironment hostingEnvironment
            , ILogger<UserModels> logger)
        {
            this._configuration = configuration;
            //model.connectionString = this._configuration.GetConnectionString("Connection");
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserModels iProp)
        {
            try
            {
                this._logger.LogInformation("User Register : " + JsonConvert.SerializeObject(iProp));
                model.Register(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = new
            {
                iProp.userId
                ,
                iProp.username
            };

            return Ok(vData);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserModels iProp)
        {
            try
            {
                model.Login(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = new
            {
                iProp.userId
                ,
                iProp.username
                ,
                iProp.firstname_th
                ,
                iProp.lastname_th
                ,
                iProp.positionDesc
                ,
                iProp.departmentDesc
                ,
                iProp.role
            };

            return Ok(vData);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserModels iProp)
        {
            try
            {
                this._logger.LogInformation("User Create : " + JsonConvert.SerializeObject(iProp));
                model.Create(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(UserModels iProp)
        {
            try
            {
                this._logger.LogInformation("User Delete : " + JsonConvert.SerializeObject(iProp));
                model.Delete(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ProfileSummary")]
        public IActionResult ProfileSummary(UserModels iProp)
        {
            try
            {
                dtData = model.ProfileSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(UserModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x=> new
                {
                    x.userId
                    ,
                    x.username
                    ,
                    x.firstname_en
                    ,
                    x.lastname_en
                    ,
                    x.firstname_th
                    ,
                    x.lastname_th
                    ,
                    x.nickname
                    ,
                    x.email
                    ,
                    x.departmentCode
                    ,
                    x.departmentDesc
                    ,
                    x.positionCode
                    ,
                    x.positionDesc
                    ,
                    x.employeeType
                }).ToList();

                return Ok(new { data = vData, total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserSummary")]
        public IActionResult UserSummary(UserModels iProp)
        {
            try
            {
                dtData = model.UserSummary(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(dtData));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("FullList")]
        public IActionResult FullList(UserModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.userId
                    ,
                    x.username
                    ,
                    x.firstname_en
                    ,
                    x.lastname_en
                    ,
                    x.firstname_th
                    ,
                    x.lastname_th
                    ,
                    x.nickname
                    ,
                    x.email
                    ,
                    x.departmentCode
                    ,
                    x.departmentDesc
                    ,
                    x.positionCode
                    ,
                    x.positionDesc
                    ,
                    x.employeeType
                }).ToList();

                return Ok(new { data = vData, total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserAddress")]
        public IActionResult UserAddress(UserModels iProp)
        {
            try
            {
                ServiceAddressModels iData = model.UserAddress(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.addressId
                    ,
                    iData.registered_home
                    ,
                    iData.registered_road
                    ,
                    iData.registered_subDistrictCode
                    ,
                    iData.registered_subDistrictName
                    ,
                    iData.registered_districtCode
                    ,
                    iData.registered_districtName
                    ,
                    iData.registered_provinceCode
                    ,
                    iData.registered_provinceName
                    ,
                    iData.registered_postcode
                    ,
                    iData.card_home
                    ,
                    iData.card_road
                    ,
                    iData.card_subDistrictCode
                    ,
                    iData.card_subDistrictName
                    ,
                    iData.card_districtCode
                    ,
                    iData.card_districtName
                    ,
                    iData.card_provinceCode
                    ,
                    iData.card_provinceName
                    ,
                    iData.card_postcode
                    ,
                    iData.live_home
                    ,
                    iData.live_road
                    ,
                    iData.live_subDistrictCode
                    ,
                    iData.live_subDistrictName
                    ,
                    iData.live_districtCode
                    ,
                    iData.live_districtName
                    ,
                    iData.live_provinceCode
                    ,
                    iData.live_provinceName
                    ,
                    iData.live_postcode
                    ,
                    iData.status
                };

                return Ok(new { data = vData, iProp.can_edit, iProp.can_view });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserEducation")]
        public IActionResult UserEducation(UserModels iProp)
        {
            try
            {
                List<ServiceEducationModels> lData = model.UserEducation(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.educationId
                    ,
                    x.levelCode
                    ,
                    x.levelName
                    ,
                    x.institution
                    ,
                    x.year
                    ,
                    x.description
                    ,
                    x.status
                    ,
                    x.mode
                }).ToList();

                return Ok(new { data = vData, iProp.can_edit, iProp.can_view });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserEmployee")]
        public IActionResult UserEmployee(UserModels iProp)
        {
            try
            {
                ServiceEmployeeModels iData = model.UserEmployee(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.processType
                    ,
                    iData.processReason
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
                    iData.phone_office
                    ,
                    iData.departmentCode
                    ,
                    iData.departmentDesc
                    ,
                    iData.positionCode
                    ,
                    iData.positionDesc
                    ,
                    iData.levelCode
                    ,
                    iData.levelDesc
                    ,
                    iData.grade
                    ,
                    iData.join_date
                    ,
                    iData.probration_end_date
                    ,
                    iData.probration_day
                    ,
                    iData.supervisorId
                    ,
                    iData.supervisorName
                    ,
                    iData.supervisorPosition
                    ,
                    iData.supervisorDepartment
                    ,
                    iData.location
                    ,
                    iData.sso
                    ,
                    iData.workMode
                    ,
                    iData.workModeDesc
                    ,
                    iData.workTime
                    ,
                    iData.workTimeDesc
                    ,
                    iData.otMode
                    ,
                    iData.otModeDesc
                    ,
                    iData.status
                };

                return Ok(new { data = vData, iProp.can_edit, iProp.can_view });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserJobExperience")]
        public IActionResult UserJobExperience(UserModels iProp)
        {
            try
            {
                List<ServiceJobExperienceModels> lData = model.UserJobExperience(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.jobId
                    ,
                    x.company
                    ,
                    x.position
                    ,
                    x.fromDate
                    ,
                    x.endDate
                    ,
                    x.description
                    ,
                    x.status
                    ,
                    x.mode
                }).ToList();

                return Ok(new { data = vData, iProp.can_edit, iProp.can_view });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserPersonal")]
        public IActionResult UserPersonal(UserModels iProp)
        {
            try
            {
                ServicePersonalModels iData = model.UserPersonal(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.personalId
                    ,
                    iData.firstname_th
                    ,
                    iData.lastname_th
                    ,
                    iData.firstname_en
                    ,
                    iData.lastname_en
                    ,
                    iData.nickname
                    ,
                    iData.sex
                    ,
                    iData.birth_date
                    ,
                    iData.maritalStatus
                    ,
                    iData.email
                    ,
                    iData.phoneNo
                    ,
                    iData.status
                };

                return Ok(new { data = iData, iProp.can_edit, iProp.can_view });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserTraining")]
        public IActionResult UserTraining(UserModels iProp)
        {
            try
            {
                List<ServiceTrainingModels> lData = model.UserTraining(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.trainingId
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
                    ,
                    x.mode
                }).ToList();

                return Ok(new { data = vData, iProp.can_edit, iProp.can_view });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserSub")]
        public IActionResult UserSub(UserModels iProp)
        {
            try
            {
                List<ServiceEmployeeModels> lData = model.UserSub(iProp);

                var vData = lData.Select(x => new
                {
                    x.userId
                    ,
                    x.employeeCode
                    ,
                    x.employeeName
                    ,
                    x.departmentDesc
                    ,
                    x.positionDesc
                    ,
                    x.level
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserSup")]
        public IActionResult UserSup(UserModels iProp)
        {
            try
            {
                List<ServiceEmployeeModels> lData = model.UserSup(iProp);

                var vData = lData.Select(x => new
                {
                    x.userId
                    ,
                    x.employeeCode
                    ,
                    x.employeeName
                    ,
                    x.departmentDesc
                    ,
                    x.positionDesc
                    ,
                    x.level
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
