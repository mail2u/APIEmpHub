using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : baseController<CommentModels>
    {
        public WebAPIModels _webAPI = new WebAPIModels();
        public CommentController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<CommentModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
            this._webAPI = this._configuration.GetSection("WebAPI").Get<WebAPIModels>();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CommentModels iProp)
        {
            try
            {
                model.Create(iProp);
                model.CommentMail(iProp);

                await SendMail(iProp);

                model.MailResponse(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(iProp);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(CommentModels iProp)
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
        public IActionResult DataList(CommentModels iProp)
        {
            lData = new List<CommentModels>();

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
                x.refId
                ,
                x.mode
                ,
                x.detail
                ,
                x.create_by
                ,
                x.create_department
                ,
                x.create_date
                ,
                x.can_delete
            }).ToList();

            return Ok(new { data = vData, total = lData.Count() });
        }

        #region SendMail
        private async Task SendMail(CommentModels iProp)
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
        #endregion
    }
}
