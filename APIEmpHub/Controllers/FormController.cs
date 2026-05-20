using APIEmpHub.Extension;
using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Buffers.Text;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : baseController<FormModels>
    {
        public WebAPIModels webAPI = new WebAPIModels();
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
            this._configuration.GetSection("WebAPI").Bind(webAPI);
        }

        #region FormNewCard
        [HttpPost]
        [Route("FormNewCardCreate")]
        public IActionResult FormNewCardCreate(FormNewCardModels iProp)
        {
            this._logger.LogInformation("FormNewCard_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormParkingSticker_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormBuyUniform_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormResetPassword_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormSalaryCertificate_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormEmployeeCertificate_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormRequestTraining_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
                    iData.level
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
                    iData.start_date
                    ,
                    iData.end_date
                    ,
                    iData.start_time
                    ,
                    iData.end_time
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

        [HttpPost]
        [Route("FormRequestTrainingPDF")]
        public async Task<IActionResult> FormRequestTrainingPDF(FormRequestTrainingModels iProp)
        {
            try
            {
                FormRequestTrainingModels iData = model.FormRequestTrainingDetail(iProp);

                PDFModels pdf = await LoadPDF("FormRequestTraining", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes,"application/pdf","download.pdf");
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
            this._logger.LogInformation("FormManpower_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormBenefitFund_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormBenefitFundPDF")]
        public async Task<IActionResult> FormBenefitFundPDF(FormBenefitFundModels iProp)
        {
            try
            {
                FormBenefitFundModels iData = model.FormBenefitFundDetail(iProp);

                PDFModels pdf = await LoadPDF("FormBenefitFund", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormBenefitInsurance_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormBenefitInsurancePDF")]
        public async Task<IActionResult> FormBenefitInsurancePDF(FormBenefitInsuranceModels iProp)
        {
            try
            {
                FormBenefitInsuranceModels iData = model.FormBenefitInsuranceDetail(iProp);

                PDFModels pdf = await LoadPDF("FormBenefitInsurance", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormPerformanceLv2_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormPerformanceLv2_Approve1 [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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
            this._logger.LogInformation("FormPerformanceLv2_Approve2 [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormPerformanceLv2PDF")]
        public async Task<IActionResult> FormPerformanceLv2PDF(FormPerformanceLv2Models iProp)
        {
            try
            {
                FormPerformanceLv2Models iData = model.FormPerformanceLv2Detail(iProp);

                PDFModels pdf = await LoadPDF("FormPerformanceLv2", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPerformanceLv1PDF")]
        public async Task<IActionResult> FormPerformanceLv1PDF(FormPerformanceLv2Models iProp)
        {
            try
            {
                FormPerformanceLv2Models iData = model.FormPerformanceLv2Detail(iProp);

                PDFModels pdf = await LoadPDF("FormPerformanceLv1", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormMoveEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormMoveEmployeePDF")]
        public async Task<IActionResult> FormMoveEmployeePDF(FormMoveEmployeeModels iProp)
        {
            try
            {
                FormMoveEmployeeModels iData = model.FormMoveEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormMoveEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormHiringEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormHiringEmployeePDF")]
        public async Task<IActionResult> FormHiringEmployeePDF(FormHiringEmployeeModels iProp)
        {
            try
            {
                FormHiringEmployeeModels iData = model.FormHiringEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormHiringEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormPdpaEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormPdpaEmployeePDF")]
        public async Task<IActionResult> FormPdpaEmployeePDF(FormPdpaEmployeeModels iProp)
        {
            try
            {
                FormPdpaEmployeeModels iData = model.FormPdpaEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormPdpaEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormWfhEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormWfhEmployeePDF")]
        public async Task<IActionResult> FormWfhEmployeePDF(FormWfhEmployeeModels iProp)
        {
            try
            {
                FormWfhEmployeeModels iData = model.FormWfhEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormWfhEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormAgreementEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormAgreementEmployeePDF")]
        public async Task<IActionResult> FormAgreementEmployeePDF(FormAgreementEmployeeModels iProp)
        {
            try
            {
                FormAgreementEmployeeModels iData = model.FormAgreementEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormAgreementEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormPrepareEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormPrepareEmployeePDF")]
        public async Task<IActionResult> FormPrepareEmployeePDF(FormPrepareEmployeeModels iProp)
        {
            try
            {
                FormPrepareEmployeeModels iData = model.FormPrepareEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormPrepareEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormProbationReport_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormProbationReportPDF")]
        public async Task<IActionResult> FormProbationReportPDF(FormProbationReportModels iProp)
        {
            try
            {
                FormProbationReportModels iData = model.FormProbationReportDetail(iProp);

                PDFModels pdf = await LoadPDF("FormProbationReport", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormPromoteEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormPromoteEmployeePDF")]
        public async Task<IActionResult> FormPromoteEmployeePDF(FormPromoteEmployeeModels iProp)
        {
            try
            {
                FormPromoteEmployeeModels iData = model.FormPromoteEmployeeDetail(iProp);

                PDFModels pdf = await LoadPDF("FormPromoteEmployee", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
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
            this._logger.LogInformation("FormIDP_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

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

        [HttpPost]
        [Route("FormIDPPDF")]
        public async Task<IActionResult> FormIDPPDF(FormIDPModels iProp)
        {
            try
            {
                FormIDPModels iData = model.FormIDPDetail(iProp);

                PDFModels pdf = await LoadPDF("FormIDP", iData);
                byte[] pdfBytes = Convert.FromBase64String(pdf.base64);

                // return file
                return File(pdfBytes, "application/pdf", "download.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormUpdatePersonal
        [HttpPost]
        [Route("FormUpdatePersonalCreate")]
        public IActionResult FormUpdatePersonalCreate(FormUpdatePersonalModels iProp)
        {
            this._logger.LogInformation("FormUpdatePersonal_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormUpdatePersonalCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormUpdatePersonal_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormUpdatePersonalDetail")]
        public IActionResult FormUpdatePersonalDetail(FormUpdatePersonalModels iProp)
        {
            try
            {
                FormUpdatePersonalModels iData = model.FormUpdatePersonalDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.userId
                    ,
                    iData.prefix_th
                    ,
                    iData.firstname_th
                    ,
                    iData.lastname_th
                    ,
                    iData.prefix_en
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
                    iData.weight
                    ,
                    iData.height
                    ,
                    iData.blood
                    ,
                    iData.nationality
                    ,
                    iData.ethnicity
                    ,
                    iData.religion
                    ,
                    iData.maritalStatus
                    ,
                    iData.militaryStatus
                    ,
                    iData.disabilityStatus
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormUpdateEmployee
        [HttpPost]
        [Route("FormUpdateEmployeeCreate")]
        public IActionResult FormUpdateEmployeeCreate(FormUpdateEmployeeModels iProp)
        {
            this._logger.LogInformation("FormUpdateEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormUpdateEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormUpdateEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormUpdateEmployeeDetail")]
        public IActionResult FormUpdateEmployeeDetail(FormUpdateEmployeeModels iProp)
        {
            try
            {
                FormUpdateEmployeeModels iData = model.FormUpdateEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.userId
                    ,
                    iData.join_date
                    ,
                    iData.probation_end_date
                    ,
                    iData.employeeType
                    ,
                    iData.divisionCode
                    ,
                    iData.departmentCode
                    ,
                    iData.sectionCode
                    ,
                    iData.positionCode
                    ,
                    iData.levelCode
                    ,
                    iData.grade
                    ,
                    iData.supervisorId
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormUpdateCard
        [HttpPost]
        [Route("FormUpdateCardCreate")]
        public IActionResult FormUpdateCardCreate(FormUpdateCardModels iProp)
        {
            this._logger.LogInformation("FormUpdateCard_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormUpdateCardCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormUpdateCard_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormUpdateCardDetail")]
        public IActionResult FormUpdateCardDetail(FormUpdateCardModels iProp)
        {
            try
            {
                FormUpdateCardModels iData = model.FormUpdateCardDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.userId
                    ,
                    iData.employeeCode
                    ,
                    iData.idcard
                    ,
                    iData.passport
                    ,
                    iData.workPermitNo
                    ,
                    iData.bookNo
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormUpdateContact
        [HttpPost]
        [Route("FormUpdateContactCreate")]
        public IActionResult FormUpdateContactCreate(FormUpdateContactModels iProp)
        {
            this._logger.LogInformation("FormUpdateContact_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormUpdateContactCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormUpdateContact_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormUpdateContactDetail")]
        public IActionResult FormUpdateContactDetail(FormUpdateContactModels iProp)
        {
            try
            {
                FormUpdateContactModels iData = model.FormUpdateContactDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.userId
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
                    iData.mobile
                    ,
                    iData.email
                    ,
                    iData.phone
                    ,
                    iData.phone_office
                    ,
                    iData.email_office
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormUpdateTalent
        [HttpPost]
        [Route("FormUpdateTalentCreate")]
        public IActionResult FormUpdateTalentCreate(List<FormUpdateTalentModels> lProp)
        {
            this._logger.LogInformation("FormUpdateTalent_Create [Request] : " + HelperConvert.ConvertToSerialize(lProp));

            try
            {
                foreach (FormUpdateTalentModels iProp in lProp)
                {
                    iProp.create_by = User.UserId();
                    model.FormUpdateTalentCreate(iProp);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormUpdateTalent_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormUpdateTalentDetail")]
        public IActionResult FormUpdateTalentDetail(FormUpdateTalentModels iProp)
        {
            try
            {
                List<FormUpdateTalentModels> lData = model.FormUpdateTalentDetail(iProp);

                var vData = lData.Select(x=>new 
                {
                    x.refId
                    ,
                    x.userId
                    ,
                    x.talentId
                    ,
                    x.language
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
        #endregion

        #region FormUpdateDocument
        [HttpPost]
        [Route("FormUpdateDocumentCreate")]
        public IActionResult FormUpdateDocumentCreate(FormUpdateDocumentModels iProp)
        {
            this._logger.LogInformation("FormUpdateDocument_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormUpdateDocumentCreate(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormUpdateDocument_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormUpdateDocumentDetail")]
        public IActionResult FormUpdateDocumentDetail(FormUpdateDocumentModels iProp)
        {
            try
            {
                List<FormUpdateDocumentModels> lData = model.FormUpdateDocumentDetail(iProp);

                var vData = lData.Select(x => new
                {
                    x.refId
                    ,
                    x.userId
                    ,
                    x.documentId
                    ,
                    x.documentType
                    ,
                    x.description
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        private async Task<PDFModels> LoadPDF(string projectName, object dataRequest)
        {
            PDFModels iPDF = new PDFModels();

            WebAPIModels webAPI = new WebAPIModels();
            this._configuration.GetSection("WebAPI").Bind(webAPI);

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest), Encoding.UTF8, "application/json");

                var authenticationString = String.Format("{0}:{1}", webAPI.APIPDF_username, webAPI.APIPDF_password);
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");

                using (var response = await httpClient.PostAsync(webAPI.APIPDF + $"/Service/CoreHR/{projectName}/base64", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        iPDF = JsonConvert.DeserializeObject<PDFModels>(apiResponse);
                    }
                    else
                    {
                        throw new Exception(apiResponse);
                    }
                }
            }

            return iPDF;
        }
    }
}
