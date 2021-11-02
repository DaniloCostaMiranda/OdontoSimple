using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;
using OdontoSimple.Services;

namespace OdontoSimple.Controllers
{
    public class StatussController : Controller
    {
        private readonly StatusService _statusService;


        public StatussController(StatusService statusService)
        {
            _statusService = statusService;
        }

        public IActionResult Index()
        {
            var list = _statusService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Status status)
        {
            _statusService.Insert(status);
            return RedirectToAction(nameof(Index));
        }
    }
}
