using Microsoft.AspNetCore.Mvc;

namespace eExamApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
