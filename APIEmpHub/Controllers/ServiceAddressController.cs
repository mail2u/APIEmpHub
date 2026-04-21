using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceAddressController : baseController<ServiceAddressModels>
    {
        public ServiceAddressController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<ServiceAddressModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(ServiceAddressModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceAddress Save : " + JsonConvert.SerializeObject(iProp));
                model.Save(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Detail")]
        public IActionResult Detail(ServiceAddressModels iProp)
        {
            try
            {
                iData = model.Detail(iProp);

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

                return Ok(vData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
