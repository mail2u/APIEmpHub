using APIEmpHub.Extension;
using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : baseController<FormModels>
    {
        public FormController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<FormModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        #region FormNewCard
        [HttpPost]
        [Route("FormNewCardCreate")]
        public IActionResult FormNewCardCreate(FormNewCardModels iProp)
        {
            this._logger.LogInformation("FormNewCard_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormNewCardCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormNewCard_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormNewCardDetail")]
        public IActionResult FormNewCardDetail(FormNewCardModels iProp)
        {
            try
            {
                FormNewCardModels iData = model.FormNewCardDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.cause
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormParkingSticker
        [HttpPost]
        [Route("FormParkingStickerCreate")]
        public IActionResult FormParkingStickerCreate(FormParkingStickerModels iProp)
        {
            this._logger.LogInformation("FormParkingSticker_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormParkingStickerCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormParkingSticker_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormParkingStickerDetail")]
        public IActionResult FormParkingStickerDetail(FormParkingStickerModels iProp)
        {
            try
            {
                FormParkingStickerModels iData = model.FormParkingStickerDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.cause
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormBuyUniform
        [HttpPost]
        [Route("FormBuyUniformCreate")]
        public IActionResult FormBuyUniformCreate(FormBuyUniformModels iProp)
        {
            this._logger.LogInformation("FormBuyUniform_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormBuyUniformCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormBuyUniform_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormBuyUniformDetail")]
        public IActionResult FormBuyUniformDetail(FormBuyUniformModels iProp)
        {
            try
            {
                FormBuyUniformModels iData = model.FormBuyUniformDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.style
                    ,
                    iData.quantity
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormResetPassword
        [HttpPost]
        [Route("FormResetPasswordCreate")]
        public IActionResult FormResetPasswordCreate(FormResetPasswordModels iProp)
        {
            this._logger.LogInformation("FormResetPassword_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormResetPasswordCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormResetPassword_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormResetPasswordDetail")]
        public IActionResult FormResetPasswordDetail(FormResetPasswordModels iProp)
        {
            try
            {
                FormResetPasswordModels iData = model.FormResetPasswordDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.system
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormSalaryCertificate
        [HttpPost]
        [Route("FormSalaryCertificateCreate")]
        public IActionResult FormSalaryCertificateCreate(FormSalaryCertificateModels iProp)
        {
            this._logger.LogInformation("FormSalaryCertificate_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormSalaryCertificateCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormSalaryCertificate_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormSalaryCertificateDetail")]
        public IActionResult FormSalaryCertificateDetail(FormSalaryCertificateModels iProp)
        {
            try
            {
                FormSalaryCertificateModels iData = model.FormSalaryCertificateDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.lang_th
                    ,
                    iData.lang_en
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormEmployeeCertificate
        [HttpPost]
        [Route("FormEmployeeCertificateCreate")]
        public IActionResult FormEmployeeCertificateCreate(FormEmployeeCertificateModels iProp)
        {
            this._logger.LogInformation("FormEmployeeCertificate_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormEmployeeCertificateCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormEmployeeCertificate_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormEmployeeCertificateDetail")]
        public IActionResult FormEmployeeCertificateDetail(FormEmployeeCertificateModels iProp)
        {
            try
            {
                FormEmployeeCertificateModels iData = model.FormEmployeeCertificateDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.lang_th
                    ,
                    iData.lang_en
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormRequestTraining
        [HttpPost]
        [Route("FormRequestTrainingCreate")]
        public IActionResult FormRequestTrainingCreate(FormRequestTrainingModels iProp)
        {
            this._logger.LogInformation("FormRequestTraining_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormRequestTrainingCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormRequestTraining_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormRequestTrainingDetail")]
        public IActionResult FormRequestTrainingDetail(FormRequestTrainingModels iProp)
        {
            try
            {
                FormRequestTrainingModels iData = model.FormRequestTrainingDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.userId
                    ,
                    iData.license
                    ,
                    iData.objectives
                    ,
                    iData.organization
                    ,
                    iData.location
                    ,
                    iData.dt
                    ,
                    iData.price
                    ,
                    iData.net
                    ,
                    iData.option1
                    ,
                    iData.option2
                    ,
                    iData.option3
                    ,
                    iData.option4
                    ,
                    iData.option4_desc
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormManpower
        [HttpPost]
        [Route("FormManpowerCreate")]
        public IActionResult FormManpowerCreate(FormManpowerModels iProp)
        {
            this._logger.LogInformation("FormManpower_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormManpowerCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormManpower_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormManpowerDetail")]
        public IActionResult FormManpowerDetail(FormManpowerModels iProp)
        {
            try
            {
                FormManpowerModels iData = model.FormManpowerDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.position
                    ,
                    iData.department
                    ,
                    iData.required_date
                    ,
                    iData.num_employee
                    ,
                    iData.type_employment
                    ,
                    iData.type_employment_desc
                    ,
                    iData.type_requirement
                    ,
                    iData.type_reason
                    ,
                    iData.type_reason_additional_hire_desc
                    ,
                    iData.type_reason_replacement_desc
                    ,
                    iData.description_work
                    ,
                    iData.sex
                    ,
                    iData.age
                    ,
                    iData.education
                    ,
                    iData.major
                    ,
                    iData.knowledge
                    ,
                    iData.skill_language
                    ,
                    iData.skill_language_desc
                    ,
                    iData.skill_computer
                    ,
                    iData.skill_computer_desc
                    ,
                    iData.skill_other
                    ,
                    iData.skill_other_desc
                    ,
                    iData.type_experience
                    ,
                    iData.type_experience_yes_desc
                    ,
                    iData.type_experience_other_desc
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormBenefitFund
        [HttpPost]
        [Route("FormBenefitFundCreate")]
        public IActionResult FormBenefitFundCreate(FormBenefitFundModels iProp)
        {
            this._logger.LogInformation("FormBenefitFund_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormBenefitFundCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormBenefitFund_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormBenefitFundDetail")]
        public IActionResult FormBenefitFundDetail(FormBenefitFundModels iProp)
        {
            try
            {
                FormBenefitFundModels iData = model.FormBenefitFundDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.idcard
                    ,
                    iData.mode
                    ,
                    iData.total
                    ,
                    iData.benefitname1
                    ,
                    iData.benefitrelation1
                    ,
                    iData.benefitpercent1
                    ,
                    iData.benefitname2
                    ,
                    iData.benefitrelation2
                    ,
                    iData.benefitpercent2
                    ,
                    iData.benefitname3
                    ,
                    iData.benefitrelation3
                    ,
                    iData.benefitpercent3
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormBenefitInsurance
        [HttpPost]
        [Route("FormBenefitInsuranceCreate")]
        public IActionResult FormBenefitInsuranceCreate(FormBenefitInsuranceModels iProp)
        {
            this._logger.LogInformation("FormBenefitInsurance_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormBenefitInsuranceCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormBenefitInsurance_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormBenefitInsuranceDetail")]
        public IActionResult FormBenefitInsuranceDetail(FormBenefitInsuranceModels iProp)
        {
            try
            {
                FormBenefitInsuranceModels iData = model.FormBenefitInsuranceDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.employeeCode
                    ,
                    iData.policyNo
                    ,
                    iData.fullname
                    ,
                    iData.birth_date
                    ,
                    iData.join_date
                    ,
                    iData.position
                    ,
                    iData.benefitname1
                    ,
                    iData.benefitage1
                    ,
                    iData.benefitrelation1
                    ,
                    iData.benefitpercent1
                    ,
                    iData.benefitname2
                    ,
                    iData.benefitage2
                    ,
                    iData.benefitrelation2
                    ,
                    iData.benefitpercent2
                    ,
                    iData.benefitname3
                    ,
                    iData.benefitage3
                    ,
                    iData.benefitrelation3
                    ,
                    iData.benefitpercent3
                    ,
                    iData.benefitname4
                    ,
                    iData.benefitage4
                    ,
                    iData.benefitrelation4
                    ,
                    iData.benefitpercent4
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormPerformanceLv2
        [HttpPost]
        [Route("FormPerformanceLv2Create")]
        public IActionResult FormPerformanceLv2Create(FormPerformanceLv2Models iProp)
        {
            this._logger.LogInformation("FormPerformanceLv2_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPerformanceLv2Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPerformanceLv2_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPerformanceLv2Approve1")]
        public IActionResult FormPerformanceLv2Approve1(FormPerformanceLv2Models iProp)
        {
            this._logger.LogInformation("FormPerformanceLv2_Approve1 [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPerformanceLv2Approve1(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPerformanceLv2_Approve1 [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPerformanceLv2Approve2")]
        public IActionResult FormPerformanceLv2Approve2(FormPerformanceLv2Models iProp)
        {
            this._logger.LogInformation("FormPerformanceLv2_Approve2 [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPerformanceLv2Create(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPerformanceLv2_Approve2 [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPerformanceLv2Detail")]
        public IActionResult FormPerformanceLv2Detail(FormPerformanceLv2Models iProp)
        {
            try
            {
                FormPerformanceLv2Models iData = model.FormPerformanceLv2Detail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.position
                    ,
                    iData.section
                    ,
                    iData.department
                    ,
                    iData.join_date
                    ,
                    iData.probation_start_date
                    ,
                    iData.probation_end_date
                    ,
                    iData.late
                    ,
                    iData.personal_leave
                    ,
                    iData.sick_leave
                    ,
                    iData.absence
                    ,
                    iData.warning
                    ,
                    iData.answer1
                    ,
                    iData.answer2
                    ,
                    iData.answer3
                    ,
                    iData.answer4
                    ,
                    iData.answer5
                    ,
                    iData.answer6
                    ,
                    iData.answer7
                    ,
                    iData.answer8
                    ,
                    iData.answer9
                    ,
                    iData.answer10
                    ,
                    iData.total
                    ,
                    iData.grade
                    ,
                    iData.suitability_mode
                    ,
                    iData.suitability_desc
                    ,
                    iData.strengths_desc
                    ,
                    iData.improvement_desc
                    ,
                    iData.top_supervisor_comment
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormMoveEmployee
        [HttpPost]
        [Route("FormMoveEmployeeCreate")]
        public IActionResult FormMoveEmployeeCreate(FormMoveEmployeeModels iProp)
        {
            this._logger.LogInformation("FormMoveEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormMoveEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormMoveEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormMoveEmployeeDetail")]
        public IActionResult FormMoveEmployeeDetail(FormMoveEmployeeModels iProp)
        {
            try
            {
                FormMoveEmployeeModels iData = model.FormMoveEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.department
                    ,
                    iData.section
                    ,
                    iData.join_date
                    ,
                    iData.position
                    ,
                    iData.age
                    ,
                    iData.job_description
                    ,
                    iData.new_department
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormHiringEmployee
        [HttpPost]
        [Route("FormHiringEmployeeCreate")]
        public IActionResult FormHiringEmployeeCreate(FormHiringEmployeeModels iProp)
        {
            this._logger.LogInformation("FormHiringEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormHiringEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormHiringEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormHiringEmployeeDetail")]
        public IActionResult FormHiringEmployeeDetail(FormHiringEmployeeModels iProp)
        {
            try
            {
                FormHiringEmployeeModels iData = model.FormHiringEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.department
                    ,
                    iData.section
                    ,
                    iData.join_date
                    ,
                    iData.position
                    ,
                    iData.probation_salary
                    ,
                    iData.probation_period
                    ,
                    iData.salary
                    ,
                    iData.description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
