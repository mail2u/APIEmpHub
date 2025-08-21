using APIEmpHub.iBase;
using APIEmpHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEmpHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : baseController<CalendarModels>
    {
        public CalendarController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<CalendarModels> logger)
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
        public IActionResult Create(CalendarModels iProp)
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

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(CalendarModels iProp)
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
        public IActionResult Delete(CalendarModels iProp)
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
        [Route("EventList")]
        public IActionResult EventList(CalendarModels iProp)
        {
            try
            {
                lData = model.EventList(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = lData.Select(x => new
            {
                x.rn
                ,
                x.refId
                ,
                x.dt
                ,
                x.time_start
                ,
                x.time_end
                ,
                x.type
                ,
                x.note
            }).ToList();

            return Ok(vData);
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(CalendarModels iProp)
        {
            lData = new List<CalendarModels>();

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
                x.rn
                ,
                x.dt
                ,
                x.day_of_week
                ,
                x.week_of_year
                ,
                x.day
                ,
                x.month
                ,
                x.year
                ,
                x.is_now
                ,
                x.eventName
                ,
                x.status
                ,
                x.lEvent
            }).ToList();

            return Ok(vData);
        }
    }
}
