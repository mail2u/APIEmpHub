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
        public ServiceStepModels mServiceStep = new ServiceStepModels();
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
            mServiceStep.connectionString = model.connectionString; 
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
                    iData.color
                    ,
                    iData.size
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

                if (iData.start_date == iData.end_date)
                {
                    iData.location += $" วันที่ {iData.start_date}";
                }
                else
                {
                    iData.location += $" วันที่ {iData.start_date} ถึง {iData.end_date}";
                }

                iData.location += $" เวลา {iData.start_time} - {iData.end_time}";

                var vData = new
                {
                    create_date = ""
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
                    objectives = new string(' ', 55) + iData.objectives
                    ,
                    iData.organization
                    ,
                    location = new string(' ', 50) + iData.location
                    ,
                    iData.price
                    ,
                    iData.net
                    ,
                    option1 = iData.option1 == 1 ? "√" : ""
                    ,
                    option2 = iData.option2 == 1 ? "√" : ""
                    ,
                    option3 = iData.option3 == 1 ? "√" : ""
                    ,
                    option4 = iData.option4 == 1 ? "√" : ""
                    ,
                    iData.option4_desc
                    ,
                    iData.create_by
                    ,
                    approve1_y = "√"
                    ,
                    approve1_n = ""
                    ,
                    approve1_by = ""
                    ,
                    approve1_position = ""
                    ,
                    approve2_y = "√"
                    ,
                    approve2_n = ""
                    ,
                    approve2_by = ""
                    ,
                    approve3_y = "√"
                    ,
                    approve3_n = ""
                    ,
                    approve3_by = ""
                    ,
                    approve4_y = "√"
                    ,
                    approve4_n = ""
                    ,
                    approve4_by = ""
                };

                PDFModels pdf = await LoadPDF("FormRequestTraining", vData);
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

        [HttpPost]
        [Route("FormManpowerPDF")]
        public async Task<IActionResult> FormManpowerPDF(FormManpowerModels iProp)
        {
            try
            {
                FormManpowerModels iData = model.FormManpowerDetail(iProp);
                List<ServiceStepModels> lStep = mServiceStep.DataList(new ServiceStepModels() { refId = iProp.refId });
                ServiceStepModels? requestBy = lStep.Find(x=>x.status == "Request");
                ServiceStepModels? approveBy1 = lStep.Find(x => x.status == "Approve1");
                ServiceStepModels? approveBy2 = lStep.Find(x => x.status == "Approve2");
                ServiceStepModels? approveBy3 = lStep.Find(x => x.status == "Approve3");

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
                    num_employee = iData.num_employee > 0 ? iData.num_employee.ToString() : ""
                    ,
                    // ประเภทของการจ้างงาน (เลือกได้อย่างเดียว) แปลงเป็นเครื่องหมายถูกให้ตรงช่องในแบบฟอร์ม
                    emp_permanent = iData.type_employment == "permanent" ? "√" : ""
                    ,
                    emp_daily = iData.type_employment == "daily" ? "√" : ""
                    ,
                    emp_monthly = iData.type_employment == "monthly" ? "√" : ""
                    ,
                    emp_outsource = iData.type_employment == "outsource" ? "√" : ""
                    ,
                    iData.type_employment_desc
                    ,
                    // ประเภทของความต้องการ
                    req_external = iData.type_requirement == "external_recruit" ? "√" : ""
                    ,
                    req_internal = iData.type_requirement == "internal_recruit" ? "√" : ""
                    ,
                    // เหตุผลการขอกำลังคนเพิ่ม
                    reason_budget = iData.type_reason == "additional_budget" ? "√" : ""
                    ,
                    reason_hire = iData.type_reason == "additional_hire" ? "√" : ""
                    ,
                    iData.type_reason_additional_hire_desc
                    ,
                    reason_replacement = iData.type_reason == "replacement" ? "√" : ""
                    ,
                    iData.type_reason_replacement_desc
                    ,
                    iData.description_work
                    ,
                    // คุณสมบัติ
                    sex_male = iData.sex == "male" ? "√" : ""
                    ,
                    sex_female = iData.sex == "female" ? "√" : ""
                    ,
                    age = iData.age > 0 ? iData.age.ToString() : ""
                    ,
                    iData.education
                    ,
                    iData.major
                    ,
                    iData.knowledge
                    ,
                    // ความสามารถพิเศษ
                    skill_language = iData.skill_language == 1 ? "√" : ""
                    ,
                    iData.skill_language_desc
                    ,
                    skill_computer = iData.skill_computer == 1 ? "√" : ""
                    ,
                    iData.skill_computer_desc
                    ,
                    skill_other = iData.skill_other == 1 ? "√" : ""
                    ,
                    iData.skill_other_desc
                    ,
                    // ประสบการณ์
                    exp_no = iData.type_experience == "no" ? "√" : ""
                    ,
                    exp_yes = iData.type_experience == "yes" ? "√" : ""
                    ,
                    iData.type_experience_yes_desc
                    ,
                    exp_other = iData.type_experience == "other" ? "√" : ""
                    ,
                    iData.type_experience_other_desc
                    ,
                    iData.create_by
                    ,
                    requestBy = requestBy?.actionName ?? ""
                    ,
                    requestPosition = requestBy?.position ?? ""
                    ,
                    requestDate = requestBy?.actionDate.Substring(0,10) ?? ""
                    ,
                    approveBy1 = approveBy1?.actionName ?? ""
                    ,
                    approvePosition1 = approveBy1?.position ?? ""
                    ,
                    approveDate1 = approveBy1?.actionDate.Substring(0, 10) ?? ""
                    ,
                    approveBy2 = approveBy2?.actionName ?? ""
                    ,
                    approvePosition2 = approveBy2?.position ?? ""
                    ,
                    approveDate2 = approveBy2?.actionDate.Substring(0, 10) ?? ""
                    ,
                    approveBy3 = approveBy3?.actionName ?? ""
                    ,
                    approvePosition3 = approveBy3?.position ?? ""
                    ,
                    approveDate3 = approveBy3?.actionDate.Substring(0, 10) ?? ""
                };

                PDFModels pdf = await LoadPDF("FormManpower", vData);
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

                var vDate = new
                {
                    create_date = ""
                    ,
                    iData.fullname
                    ,
                    iData.idcard
                    ,
                    mode_1 = iData.mode == "new" ? "√" : ""
                    ,
                    mode_2 = iData.mode == "change" ? "√" : ""
                    ,
                    iData.benefitname1
                    ,
                    iData.benefitname2
                    ,
                    iData.benefitname3
                    ,
                    iData.benefitrelation1
                    ,
                    iData.benefitrelation2
                    ,
                    iData.benefitrelation3
                    ,
                    benefitpercent1 = iData.benefitpercent1 > 0 ? iData.benefitpercent1.ToString("0.00") : ""
                    ,
                    benefitpercent2 = iData.benefitpercent2 > 0 ? iData.benefitpercent2.ToString("0.00") : ""
                    ,
                    benefitpercent3 = iData.benefitpercent3 > 0 ? iData.benefitpercent3.ToString("0.00") : ""
                    ,
                    iData.create_by
                };

                PDFModels pdf = await LoadPDF("FormBenefitFund", vDate);
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
                    iData.prefix
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

                var vDate = new
                {
                    create_date = ""
                    ,
                    iData.fullname
                    ,
                    iData.employeeCode
                    ,
                    iData.birth_date_day
                    ,
                    iData.birth_date_month
                    ,
                    iData.birth_date_year
                    ,
                    iData.birth_date_age
                    ,
                    iData.join_date
                    ,
                    iData.position
                    ,
                    iData.benefitname1
                    ,
                    iData.benefitname2
                    ,
                    iData.benefitname3
                    ,
                    iData.benefitname4
                    ,
                    iData.benefitname5
                    ,
                    benefitage1 = iData.benefitage1 > 0 ? iData.benefitage1.ToString("0") : ""
                    ,
                    benefitage2 = iData.benefitage2 > 0 ? iData.benefitage2.ToString("0") : ""
                    ,
                    benefitage3 = iData.benefitage3 > 0 ? iData.benefitage3.ToString("0") : ""
                    ,
                    benefitage4 = iData.benefitage4 > 0 ? iData.benefitage4.ToString("0") : ""
                    ,
                    benefitage5 = iData.benefitage5 > 0 ? iData.benefitage5.ToString("0") : ""
                    ,
                    iData.benefitrelation1
                    ,
                    iData.benefitrelation2
                    ,
                    iData.benefitrelation3
                    ,
                    iData.benefitrelation4
                    ,
                    iData.benefitrelation5
                    ,
                    benefitpercent1 = iData.benefitpercent1 > 0 ? iData.benefitpercent1.ToString("0.00") : ""
                    ,
                    benefitpercent2 = iData.benefitpercent2 > 0 ? iData.benefitpercent2.ToString("0.00") : ""
                    ,
                    benefitpercent3 = iData.benefitpercent3 > 0 ? iData.benefitpercent3.ToString("0.00") : ""
                    ,
                    benefitpercent4 = iData.benefitpercent4 > 0 ? iData.benefitpercent4.ToString("0.00") : ""
                    ,
                    benefitpercent5 = iData.benefitpercent5 > 0 ? iData.benefitpercent5.ToString("0.00") : ""
                    ,
                    iData.create_by
                };

                PDFModels pdf = await LoadPDF("FormBenefitInsurance", vDate);
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

        #region FormPerformanceLv1

        [HttpPost]
        [Route("FormPerformanceLv1Detail")]
        public IActionResult FormPerformanceLv1Detail(FormPerformanceLv2Models iProp)
        {
            try
            {
                FormPerformanceLv2Models iData = model.FormPerformanceLv1Detail(iProp);

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
        [Route("FormPerformanceLv1PDF")]
        public async Task<IActionResult> FormPerformanceLv1PDF(FormPerformanceLv2Models iProp)
        {
            try
            {
                FormPerformanceLv2Models iData = model.FormPerformanceLv1Detail(iProp);

                var vData = new
                {
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
                    iData.probation_start_date
                    ,
                    iData.probation_end_date
                    ,
                    iData.late
                    ,
                    iData.absence
                    ,
                    iData.personal_leave
                    ,
                    iData.sick_leave
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
                    iData.score1
                    ,
                    iData.score2
                    ,
                    iData.score3
                    ,
                    iData.score4
                    ,
                    iData.score5
                    ,
                    iData.score6
                    ,
                    iData.score7
                    ,
                    iData.score8
                    ,
                    iData.score9
                    ,
                    iData.score10
                    ,
                    iData.total
                    ,
                    iData.grade
                    ,
                    mode_1 = iData.suitability_mode == "" ? "" : ""
                    ,
                    mode_2 = iData.suitability_mode == "" ? "" : ""
                    ,
                    mode_3 = iData.suitability_mode == "" ? "" : ""
                    ,
                    iData.suitability_mode
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                    ,
                    iData.approve1_by
                    ,
                    iData.approve1_position
                    ,
                    iData.approve1_date
                    ,
                    iData.approve2_by
                    ,
                    iData.approve2_date
                };

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

                var vData = new
                {
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
                    iData.probation_start_date
                    ,
                    iData.probation_end_date
                    ,
                    iData.late
                    ,
                    iData.absence
                    ,
                    iData.personal_leave
                    ,
                    iData.sick_leave
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
                    iData.score1
                    ,
                    iData.score2
                    ,
                    iData.score3
                    ,
                    iData.score4
                    ,
                    iData.score5
                    ,
                    iData.score6
                    ,
                    iData.score7
                    ,
                    iData.score8
                    ,
                    iData.score9
                    ,
                    iData.score10
                    ,
                    iData.total
                    ,
                    iData.grade
                    ,
                    mode_1 = iData.suitability_mode == "" ? "" : ""
                    ,
                    mode_2 = iData.suitability_mode == "" ? "" : ""
                    ,
                    mode_3 = iData.suitability_mode == "" ? "" : ""
                    ,
                    iData.suitability_mode
                    ,
                    iData.create_by
                    ,
                    iData.approve1_by
                    ,
                    iData.approve1_position
                    ,
                    iData.approve1_date
                    ,
                    iData.approve2_by
                    ,
                    iData.approve2_date
                };

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

                var vData = new
                {
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
                    description = new string(' ', 25) + iData.description
                    ,
                    job_description = new string(' ', 35) + iData.job_description
                    ,
                    iData.new_department
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                    ,
                    iData.approve1_by
                    ,
                    iData.approve1_position
                    ,
                    iData.approve1_date
                    ,
                    iData.approve2_by
                    ,
                    iData.approve2_position
                    ,
                    iData.approve2_date
                    ,
                    iData.approve3_by
                    ,
                    iData.approve3_position
                    ,
                    iData.approve3_date
                    ,
                    iData.approve4_by
                    ,
                    iData.approve4_position
                    ,
                    iData.approve4_date
                    ,
                    iData.approve5_by
                    ,
                    iData.approve5_position
                    ,
                    iData.approve5_date
                    ,
                    iData.approve6_by
                    ,
                    iData.approve6_position
                    ,
                    iData.approve6_date
                };

                PDFModels pdf = await LoadPDF("FormMoveEmployee", vData);
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
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                    ,
                    iData.create_position
                    ,
                    iData.approve1_by
                    ,
                    iData.approve1_date
                    ,
                    iData.approve1_position
                    ,
                    iData.approve2_by
                    ,
                    iData.approve2_date
                    ,
                    iData.approve2_position
                };

                PDFModels pdf = await LoadPDF("FormHiringEmployee", vData);
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

        #region FormPermanentEmployee
        [HttpPost]
        [Route("FormPermanentEmployeeCreate")]
        public IActionResult FormPermanentEmployeeCreate(FormPermanentEmployeeModels iProp)
        {
            this._logger.LogInformation("FormPermanentEmployee_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormPermanentEmployeeCreate(iProp);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormPermanentEmployee_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormPermanentEmployeeDetail")]
        public IActionResult FormPermanentEmployeeDetail(FormPermanentEmployeeModels iProp)
        {
            try
            {
                FormPermanentEmployeeModels iData = model.FormPermanentEmployeeDetail(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.letter_date
                    ,
                    iData.fullname
                    ,
                    iData.start_date
                    ,
                    iData.position
                    ,
                    iData.department
                    ,
                    iData.include_salary
                    ,
                    iData.salary
                    ,
                    iData.salary_text
                    ,
                    iData.effective_date
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
                    iData.prefix
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

                var vData = new
                {
                    iData.refId
                    ,
                    iData.prefix
                    ,
                    prefix_mr = iData.prefix == "นาย" ? "√" : ""
                    ,
                    prefix_mrs = iData.prefix == "นาง" ? "√" : ""
                    ,
                    prefix_miss = iData.prefix == "นางสาว" ? "√" : ""
                    ,
                    iData.firstname
                    ,
                    iData.lastname
                    ,
                    iData.idcard
                    ,
                    answer1_y = iData.answer1 == "Yes" ? "√" : ""
                    ,
                    answer1_n = iData.answer1 != "Yes" ? "√" : ""
                    ,
                    answer2_y = iData.answer2 == "Yes" ? "√" : ""
                    ,
                    answer2_n = iData.answer2 != "Yes" ? "√" : ""
                    ,
                    answer3_y = iData.answer3 == "Yes" ? "√" : ""
                    ,
                    answer3_n = iData.answer3 != "Yes" ? "√" : ""
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                };

                PDFModels pdf = await LoadPDF("FormPdpaEmployee", vData);
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
                    iData.prefix
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
                    answer1_y = iData.answer1 == "Yes" ? "√" : ""
                    ,
                    answer1_n = iData.answer1 != "Yes" ? "√" : ""
                    ,
                    answer2_y = iData.answer2 == "Yes" ? "√" : ""
                    ,
                    answer2_n = iData.answer2 != "Yes" ? "√" : ""
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                    ,
                    iData.approve1_by
                };

                PDFModels pdf = await LoadPDF("FormWfhEmployee", vData);
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
                    iData.create_by
                    ,
                    iData.create_date
                };

                PDFModels pdf = await LoadPDF("FormAgreementEmployee", vData);
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
                    answer1_y = iData.answer1 == "Yes" ? "√" : ""
                    ,
                    answer1_n = iData.answer1 != "Yes" ? "√" : ""
                    ,
                    answer2_y = iData.answer2 == "Yes" ? "√" : ""
                    ,
                    answer2_n = iData.answer2 != "Yes" ? "√" : ""
                    ,
                    answer3_y = iData.answer3 == "Yes" ? "√" : ""
                    ,
                    answer3_n = iData.answer3 != "Yes" ? "√" : ""
                    ,
                    iData.answer3_desc
                    ,
                    answer4_y = iData.answer4 == "Yes" ? "√" : ""
                    ,
                    answer4_n = iData.answer4 != "Yes" ? "√" : ""
                    ,
                    iData.answer4_desc
                    ,
                    answer5_y = iData.answer5 == "Yes" ? "√" : ""
                    ,
                    answer5_n = iData.answer5 != "Yes" ? "√" : ""
                    ,
                    iData.answer5_desc
                    ,
                    answer6_y = iData.answer6 == "Yes" ? "√" : ""
                    ,
                    answer6_n = iData.answer6 != "Yes" ? "√" : ""
                    ,
                    iData.answer6_desc
                    ,
                    answer7_y = iData.answer7 == "Yes" ? "√" : ""
                    ,
                    answer7_n = iData.answer7 != "Yes" ? "√" : ""
                    ,
                    iData.answer7_desc
                    ,
                    answer8_y = iData.answer8 == "Yes" ? "√" : ""
                    ,
                    answer8_n = iData.answer8 != "Yes" ? "√" : ""
                    ,
                    iData.answer8_desc
                    ,
                    answer9_y = iData.answer9 == "Yes" ? "√" : ""
                    ,
                    answer9_n = iData.answer9 != "Yes" ? "√" : ""
                    ,
                    iData.answer9_desc
                    ,
                    iData.gls_desc
                    ,
                    gls_system = iData.gls_system == "Yes" ? "√" : ""
                    ,
                    iData.ls_desc
                    ,
                    ls_system =iData.ls_system == "Yes" ? "√" : ""
                    ,
                    iData.linet_desc
                    ,
                    linet_system = iData.linet_system == "Yes" ? "√" : ""
                    ,
                    iData.sun_desc
                    ,
                    sun_system =iData.sun_system == "Yes" ? "√" : ""
                    ,
                    iData.prophet_desc
                    ,
                    prophet_system = iData.prophet_system == "Yes" ? "√" : ""
                    ,
                    iData.bonunza_desc
                    ,
                    bonunza_system = iData.bonunza_system == "Yes" ? "√" : ""
                    ,
                    iData.other_desc
                    ,
                    other_system = iData.other_system == "Yes" ? "√" : ""
                    ,
                    iData.description
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                    ,
                    iData.create_position
                };

                PDFModels pdf = await LoadPDF("FormPrepareEmployee", vData);
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
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                    ,
                    iData.create_date_day
                    ,
                    iData.create_date_month
                    ,
                    iData.create_date_year
                };


                PDFModels pdf = await LoadPDF("FormProbationReport", vData);
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

                var vData = new
                {
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
                    ,
                    iData.approve1_by
                    ,
                    iData.approve1_position
                    ,
                    iData.approve2_by
                    ,
                    iData.approve2_position
                    ,
                    iData.approve3_by
                    ,
                    iData.approve3_position
                };

                PDFModels pdf = await LoadPDF("FormPromoteEmployee", vData);
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
                    ,
                    iData.disabilityCardNo
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
                    iData.functionCode
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

                var vData = lData.Select(x => new
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

        #region FormJobDescription
        [HttpPost]
        [Route("FormJobDescriptionCreate")]
        public IActionResult FormJobDescriptionCreate(FormJobDescriptionModels iProp)
        {
            this._logger.LogInformation("FormJobDescription_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormJobDescriptionCreate(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormJobDescription_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormJobDescriptionDetail")]
        public IActionResult FormJobDescriptionDetail(FormJobDescriptionModels iProp)
        {
            try
            {
                FormJobDescriptionModels iData = model.FormJobDescriptionDetail(iProp);

                var vData = new
                {
                    iData.refId
     ,
                    iData.positionName
     ,
                    iData.jobFunction
     ,
                    iData.departmentName
     ,
                    iData.sectionName
     ,
                    iData.position_description
     ,
                    iData.major_description
     ,
                    iData.education
     ,
                    iData.experience
     ,
                    iData.functional_competencies
     ,
                    iData.leadership_competencies
     ,
                    iData.financial
     ,
                    iData.customer_and_market
     ,
                    iData.process
     ,
                    iData.people_development
     ,
                    iData.internal_description
     ,
                    iData.internal_contact_description
     ,
                    iData.external_description
     ,
                    iData.external_contact_description
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region FormEmployeeData
        [HttpPost]
        [Route("FormEmployeeDataCreate")]
        public IActionResult FormEmployeeDataCreate(FormEmployeeDataModels iProp)
        {
            this._logger.LogInformation("FormEmployeeData_Create [Request] : " + HelperConvert.ConvertToSerialize(iProp));

            try
            {
                iProp.create_by = User.UserId();
                model.FormEmployeeDataCreate(iProp);

                return Ok(iProp);
            }
            catch (Exception ex)
            {
                this._logger.LogError("FormEmployeeData_Create [Error] : " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FormEmployeeDataDetail")]
        public IActionResult FormEmployeeDataDetail(FormEmployeeDataModels iProp)
        {
            try
            {
                FormEmployeeDataModels iData = model.FormEmployeeDataDetail(iProp);

                var vData = new
                {
                    iData.refId
     ,
                    iData.is_username
     ,
                    iData.is_prefix_th
     ,
                    iData.is_prefix_en
     ,
                    iData.is_fullname_th
     ,
                    iData.is_fullname_en
     ,
                    iData.is_position
     ,
                    iData.is_position_en
     ,
                    iData.is_employee_type_th
     ,
                    iData.is_employee_type_en
     ,
                    iData.is_department
     ,
                    iData.is_department_en
     ,
                    iData.is_division_th
     ,
                    iData.is_division_en
     ,
                    iData.is_function_th
     ,
                    iData.is_function_en
     ,
                    iData.is_join_date
     ,
                    iData.is_resign_date
     ,
                    iData.is_employee_code
     ,
                    iData.is_nickname
     ,
                    iData.is_email
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

        private async Task<PDFModels> LoadPDF(string projectName, object dataRequest)
        {
            PDFModels iPDF = new PDFModels();

            WebAPIModels webAPI = new WebAPIModels();
            this._configuration.GetSection("WebAPI").Bind(webAPI);

            using (var httpClient = new HttpClient())
            {
                // แปลงปีของวันที่ (dd/MM/yyyy) ในข้อมูลทั้งหมดเป็น พ.ศ. เพื่อให้เอกสาร PDF แสดงเป็น พ.ศ.
                string json = ConvertJsonDatesToBuddhist(JsonConvert.SerializeObject(dataRequest));
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

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

        // แปลงปีของวันที่รูปแบบ dd/MM/yyyy ใน JSON payload เป็น พ.ศ. (บวก 543)
        // กันแปลงซ้ำด้วยการข้ามปีที่เป็น พ.ศ. อยู่แล้ว (>= 2400)
        private static string ConvertJsonDatesToBuddhist(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return json;
            }

            return System.Text.RegularExpressions.Regex.Replace(json, @"(\d{1,2}/\d{1,2}/)(\d{4})", m =>
            {
                int year = int.Parse(m.Groups[2].Value);

                if (year >= 2400)
                {
                    return m.Value;
                }

                return m.Groups[1].Value + (year + 543);
            });
        }
    }
}
