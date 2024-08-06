using Microsoft.AspNetCore.Mvc;

namespace UserTaskService.Controllers
{
    public class DutyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
