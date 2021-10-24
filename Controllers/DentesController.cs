using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdontoSimple.Models;
using OdontoSimple.Services;

namespace OdontoSimple.Controllers
{
    public class DentesController : Controller
    {
        private readonly DenteService _denteService;

        public DentesController(DenteService denteService)
        {
            _denteService = denteService;
        }

        public IActionResult Index()
        {
            var list = _denteService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dente dente)
        {
            _denteService.Insert(dente);
            return RedirectToAction(nameof(Index));
        }
    }
}