using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptionController : Controller
    {
        [HttpGet]
        [Route("Encrypt")]
        public IActionResult Encrypt(string text)
        {
            try
            {
                if (String.IsNullOrEmpty(text))
                {
                    return BadRequest("text is empty");
                }
                string result = HelperEncrypt.Encrypt(text);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Decrypt")]
        public IActionResult Decrypt(string text)
        {
            try
            {
                if (String.IsNullOrEmpty(text))
                {
                    return BadRequest("text is empty");
                }
                string result = HelperEncrypt.Decrypt(text);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
