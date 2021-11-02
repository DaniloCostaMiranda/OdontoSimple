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
    public class ProcedimentsController : Controller
    {
        private readonly ProcedimentService _procedimentService;


        public ProcedimentsController(ProcedimentService procedimentService)
        {
            _procedimentService = procedimentService;
        }

        public IActionResult Index()
        {
            var list = _procedimentService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Procediment procediment)
        {
            _procedimentService.Insert(procediment);
            return RedirectToAction(nameof(Index));
        }
    }
}
