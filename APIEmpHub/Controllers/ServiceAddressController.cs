using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIEmpHub.Controllers
{
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
        [Route("Cancel")]
        public IActionResult Cancel(ServiceAddressModels iProp)
        {
            try
            {
                this._logger.LogInformation("ServiceAddress Cancel : " + JsonConvert.SerializeObject(iProp));
                model.Cancel(iProp);
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
                    iData.home
                    ,
                    iData.road
                    ,
                    iData.subDistrictCode
                    ,
                    iData.subDistrictName
                    ,
                    iData.districtCode
                    ,
                    iData.districtName
                    ,
                    iData.provinceCode
                    ,
                    iData.provinceName
                    ,
                    iData.postcode
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

        [HttpPost]
        [Route("DetailByRef")]
        public IActionResult DetailByRef(ServiceAddressModels iProp)
        {
            try
            {
                iData = model.DetailByRef(iProp);

                var vData = new
                {
                    iData.refId
                    ,
                    iData.addressId
                    ,
                    iData.home
                    ,
                    iData.road
                    ,
                    iData.subDistrictCode
                    ,
                    iData.subDistrictName
                    ,
                    iData.districtCode
                    ,
                    iData.districtName
                    ,
                    iData.provinceCode
                    ,
                    iData.provinceName
                    ,
                    iData.postcode
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
