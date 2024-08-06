using Microsoft.AspNetCore.Mvc;

namespace UserTaskService.Controllers
{
    public class UserTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
