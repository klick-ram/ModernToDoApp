﻿using Microsoft.AspNetCore.Mvc;

namespace TaskService.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
