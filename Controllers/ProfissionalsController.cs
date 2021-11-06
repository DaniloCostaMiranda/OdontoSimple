using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdontoSimple.Models;
using OdontoSimple.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdontoSimple.Controllers
{
    public class ProfissionalsController : Controller
    {

        private readonly ProfissionalService _profissionalService;


        public ProfissionalsController(ProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        public IActionResult Index()
        {
            var list = _profissionalService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profissional profissional)
        {
            _profissionalService.Insert(profissional);
            return RedirectToAction(nameof(Index));
        }


        /*
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
        */
    }
}
