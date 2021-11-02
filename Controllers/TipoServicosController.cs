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
    public class TipoServicosController : Controller
    {
        private readonly TipoServicoService _tipoServicoService;


        public TipoServicosController(TipoServicoService tipoServicoService)
        {
            _tipoServicoService = tipoServicoService;
        }

        public IActionResult Index()
        {
            var list = _tipoServicoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoServico tipoServico)
        {
            _tipoServicoService.Insert(tipoServico);
            return RedirectToAction(nameof(Index));
        }
    }
}
