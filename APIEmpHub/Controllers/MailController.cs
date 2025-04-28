using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MailController : baseController<MailModels>
    {
        public MailController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<MailModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(MailModels iProp)
        {
            try
            {
                lData = model.DataList(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.id
                ,
                x.sysId
                ,
                x.mailType
                ,
                x.mailitem_id
                ,
                x.profileName
                ,
                x.mailTo
                ,
                x.mailCC
                ,
                x.mailBCC
                ,
                x.subject
                ,
                x.attachments
                ,
                x.body
                ,
                x.requestDate
                ,
                x.sendDate
                ,
                x.resendDate
                ,
                x.is_send
                ,
                x.is_error
                ,
                x.errorMessage
            }).ToList();

            return Ok(new { data = vData, total = iProp.total });
        }

        [HttpPost]
        [Route("Resend")]
        public IActionResult Resend(MailModels iProp)
        {
            try
            {
                model.Resend(iProp);

                if(!String.IsNullOrEmpty(iProp.errorMessage))
                {
                    return BadRequest(iProp.errorMessage);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
