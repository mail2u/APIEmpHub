using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Controllers
{
    [Authorize("Report")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : baseController<ReportModels>
    {
        public ReportController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ReportModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("ReportWorkforceOverview")]
        public IActionResult ReportWorkforceOverview(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportWorkforceOverview(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ReportEmployeeData")]
        public IActionResult ReportEmployeeData(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportEmployeeData(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ReportHeadcountSection")]
        public IActionResult ReportHeadcountSection(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportHeadcountSection(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportHeadcountSex")]
        public IActionResult ReportHeadcountSex(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportHeadcountSex(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportHeadcountAge")]
        public IActionResult ReportHeadcountAge(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportHeadcountAge(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportHeadcountPosition")]
        public IActionResult ReportHeadcountPosition(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportHeadcountPosition(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportHeadcountMovement")]
        public IActionResult ReportHeadcountMovement(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportHeadcountMovement(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportTurnoverAttrition")]
        public IActionResult ReportTurnoverAttrition(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportTurnoverAttrition(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportRecruitmentDashboard")]
        public IActionResult ReportRecruitmentDashboard(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportRecruitmentDashboard(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportTimeToFill")]
        public IActionResult ReportTimeToFill(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportTimeToFill(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportEmployeeReferral")]
        public IActionResult ReportEmployeeReferral(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportEmployeeReferral(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportLearningDevelopment")]
        public IActionResult ReportLearningDevelopment(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportLearningDevelopment(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportTrainingHours")]
        public IActionResult ReportTrainingHours(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportTrainingHours(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportTrainingCost")]
        public IActionResult ReportTrainingCost(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportTrainingCost(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportPerformanceDashboard")]
        public IActionResult ReportPerformanceDashboard(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportPerformanceDashboard(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ReportPerformanceEvaluation")]
        public IActionResult ReportPerformanceEvaluation(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportPerformanceEvaluation(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ReportHighPotential")]
        public IActionResult ReportHighPotential(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportHighPotential(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ReportAddress")]
        public IActionResult ReportAddress(ReportModels iProp)
        {
            try
            {
                dtData = model.ReportAddress(iProp);

                return Ok(new { data = JsonConvert.SerializeObject(dtData), total = iProp.total });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
