using Microsoft.AspNetCore.Mvc;

namespace eExamApp.Controllers
{
    public class QuestionAnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
