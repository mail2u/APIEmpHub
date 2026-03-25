using Microsoft.AspNetCore.Mvc;

namespace APIEmpHub.Controllers
{
    public class OfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
