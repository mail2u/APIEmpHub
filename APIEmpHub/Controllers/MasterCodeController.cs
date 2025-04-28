using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterCodeController : baseController<MasterCodeModels>
    {
        public MasterCodeController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<MasterCodeModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(MasterCodeModels iProp)
        {
            try
            {
                model.Create(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(MasterCodeModels iProp)
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

        [Authorize("Admin")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(MasterCodeModels iProp)
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
        public IActionResult DataList(MasterCodeModels iProp)
        {
            lData = new List<MasterCodeModels>();

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
                x.groupName
                ,
                x.code
                ,
                x.desc_th
                ,
                x.desc_en
                ,
                x.condition_1
                ,
                x.condition_2
                ,
                x.condition_3
                ,
                x.condition_4
            }).ToList();

            return Ok(vData);
        }


        [HttpPost]
        [Route("Address")]
        public IActionResult Address()
        {
            AddressModels mAddress = new AddressModels();
            mAddress.connectionString = model.connectionString;

            List<AddressModels> lData = new List<AddressModels>();

            try
            {
                lData = mAddress.DataList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.subDistrictCode
                ,
                x.subDistrictName
                ,
                x.districtCode
                ,
                x.districtName
                ,
                x.provinceCode
                ,
                x.provinceName
                ,
                x.postcode
            }).ToList();

            return Ok(vData);
        }
    }
}
