using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : baseController<CandidateModels>
    {
        public CandidateController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<CandidateModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CandidateModels iProp)
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
        [Route("Update")]
        public IActionResult Update(CandidateModels iProp)
        {
            try
            {
                model.Update(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(CandidateModels iProp)
        {
            try
            {
                model.Delete(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(CandidateModels iProp)
        {
            lData = new List<CandidateModels>();

            try
            {
                lData = model.DataList(iProp);

                var vData = lData.Select(x => new
                {
                    x.candidateId
                    ,
                    x.firstname
                    ,
                    x.lastname
                    ,
                    x.email
                    ,
                    x.status
                    ,
                    x.create_by
                    ,
                    x.create_date
                }).ToList();

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(CandidateModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

                var vData = new
                {
                    iData.candidateId
                    ,
                    iData.firstname
                    ,
                    iData.lastname
                    ,
                    iData.email
                    ,
                    iData.status
                    ,
                    iData.create_by
                    ,
                    iData.create_date
                };

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
