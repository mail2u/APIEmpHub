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
                    iData.fullname
                    ,
                    iData.position
                    ,
                    iData.section
                    ,
                    iData.department
                    ,
                    iData.division
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

        #region FormPdpaEmployee
        [HttpPost]
        [Route("FormPdpaEmployeeCreate")]
        public IActionResult FormPdpaEmployeeCreate(FormPdpaEmployeeModels iProp)
        {
            this._logger.LogInformation("FormPdpaEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPdpaEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPdpaEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPdpaEmployeeDetail")]
        public IActionResult FormPdpaEmployeeDetail(FormPdpaEmployeeModels iProp)
        {
            try
            {
                FormPdpaEmployeeModels iData = model.FormPdpaEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.firstname
                    ,
                    iData.lastname
                    ,
                    iData.idcard
                    ,
                    iData.answer1
                    ,
                    iData.answer2
                    ,
                    iData.answer3
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormWfhEmployee
        [HttpPost]
        [Route("FormWfhEmployeeCreate")]
        public IActionResult FormWfhEmployeeCreate(FormWfhEmployeeModels iProp)
        {
            this._logger.LogInformation("FormWfhEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormWfhEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormWfhEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormWfhEmployeeDetail")]
        public IActionResult FormWfhEmployeeDetail(FormWfhEmployeeModels iProp)
        {
            try
            {
                FormWfhEmployeeModels iData = model.FormWfhEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.address
                    ,
                    iData.start_date
                    ,
                    iData.answer1
                    ,
                    iData.answer2
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormAgreementEmployee
        [HttpPost]
        [Route("FormAgreementEmployeeCreate")]
        public IActionResult FormAgreementEmployeeCreate(FormAgreementEmployeeModels iProp)
        {
            this._logger.LogInformation("FormAgreementEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormAgreementEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormAgreementEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormAgreementEmployeeDetail")]
        public IActionResult FormAgreementEmployeeDetail(FormAgreementEmployeeModels iProp)
        {
            try
            {
                FormAgreementEmployeeModels iData = model.FormAgreementEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.position
                    ,
                    iData.department
                    ,
                    iData.join_date
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormPrepareEmployee
        [HttpPost]
        [Route("FormPrepareEmployeeCreate")]
        public IActionResult FormPrepareEmployeeCreate(FormPrepareEmployeeModels iProp)
        {
            this._logger.LogInformation("FormPrepareEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPrepareEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPrepareEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPrepareEmployeeDetail")]
        public IActionResult FormPrepareEmployeeDetail(FormPrepareEmployeeModels iProp)
        {
            try
            {
                FormPrepareEmployeeModels iData = model.FormPrepareEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.prefix
                    ,
                    iData.fullname
                    ,
                    iData.position
                    ,
                    iData.join_date
                    ,
                    iData.phoneNo
                    ,
                    iData.username
                    ,
                    iData.email
                    ,
                    iData.sharedrive
                    ,
                    iData.speccomputer
                    ,
                    iData.answer1
                    ,
                    iData.answer2
                    ,
                    iData.answer3
                    ,
                    iData.answer3_desc
                    ,
                    iData.answer4
                    ,
                    iData.answer4_desc
                    ,
                    iData.answer5
                    ,
                    iData.answer5_desc
                    ,
                    iData.answer6
                    ,
                    iData.answer6_desc
                    ,
                    iData.answer7
                    ,
                    iData.answer7_desc
                    ,
                    iData.answer8
                    ,
                    iData.answer8_desc
                    ,
                    iData.answer9
                    ,
                    iData.answer9_desc
                    ,
                    iData.gls_desc
                    ,
                    iData.gls_system
                    ,
                    iData.ls_desc
                    ,
                    iData.ls_system
                    ,
                    iData.linet_desc
                    ,
                    iData.linet_system
                    ,
                    iData.sun_desc
                    ,
                    iData.sun_system
                    ,
                    iData.prophet_desc
                    ,
                    iData.prophet_system
                    ,
                    iData.bonunza_desc
                    ,
                    iData.bonunza_system
                    ,
                    iData.other_desc
                    ,
                    iData.other_system
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


        #region FormProbationReport
        [HttpPost]
        [Route("FormProbationReportCreate")]
        public IActionResult FormProbationReportCreate(FormProbationReportModels iProp)
        {
            this._logger.LogInformation("FormProbationReport_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormProbationReportCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormProbationReport_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormProbationReportDetail")]
        public IActionResult FormProbationReportDetail(FormProbationReportModels iProp)
        {
            try
            {
                FormProbationReportModels iData = model.FormProbationReportDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.position
                    ,
                    iData.department
                    ,
                    iData.join_date
                    ,
                    iData.period
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
                    iData.answer5_fixed
                    ,
                    iData.answer6
                    ,
                    iData.answer6_fixed
                    ,
                    iData.answer7
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormPromoteEmployee
        [HttpPost]
        [Route("FormPromoteEmployeeCreate")]
        public IActionResult FormPromoteEmployeeCreate(FormPromoteEmployeeModels iProp)
        {
            this._logger.LogInformation("FormPromoteEmployee_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPromoteEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPromoteEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPromoteEmployeeDetail")]
        public IActionResult FormPromoteEmployeeDetail(FormPromoteEmployeeModels iProp)
        {
            try
            {
                FormPromoteEmployeeModels iData = model.FormPromoteEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.position
                    ,
                    iData.department
                    ,
                    iData.section
                    ,
                    iData.join_date
                    ,
                    iData.year
                    ,
                    iData.grade1
                    ,
                    iData.grade2
                    ,
                    iData.position_current
                    ,
                    iData.department_current
                    ,
                    iData.position_new
                    ,
                    iData.department_new
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

        #region FormIDP
        [HttpPost]
        [Route("FormIDPCreate")]
        public IActionResult FormIDPCreate(FormIDPModels iProp)
        {
            this._logger.LogInformation("FormIDP_Create [Request] : " + JsonSerializer.Serialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormIDPCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormIDP_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormIDPDetail")]
        public IActionResult FormIDPDetail(FormIDPModels iProp)
        {
            try
            {
                FormIDPModels iData = model.FormIDPDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.fullname
                    ,
                    iData.department
                    ,
                    iData.join_date
                    ,
                    iData.objective
                    ,
                    iData.answer1_desc
                    ,
                    iData.answer2_desc
                    ,
                    iData.answer2_date
                    ,
                    iData.answer3_desc
                    ,
                    iData.answer3_date
                    ,
                    iData.answer4_desc
                    ,
                    iData.answer4_date
                    ,
                    iData.answer5_desc
                    ,
                    iData.answer6_desc
                    ,
                    iData.answer6_date
                    ,
                    iData.answer7_a_desc
                    ,
                    iData.answer7_b_desc
                    ,
                    iData.answer8_desc
                    ,
                    iData.answer9_desc
                    ,
                    iData.answer9_date
                    ,
                    iData.answer10_a_desc
                    ,
                    iData.answer10_b_desc
                    ,
                    iData.answer11_desc
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
