using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdontoSimple.Models;
using OdontoSimple.Services;
using OdontoSimple.Models.ViewModels;

namespace OdontoSimple.Controllers
{
    public class TratamentosController : Controller
    {
        private readonly TratamentoService _tratamentoService;

        //private readonly PacienteService _pacienteService;

        private readonly DenteService _denteService;


        public TratamentosController(TratamentoService tratamentoService, DenteService denteService)
        {
            _tratamentoService = tratamentoService;
            //_pacienteService = pacienteService;
            _denteService = denteService;

        }

        public IActionResult Index()
        {
            var list = _tratamentoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {


            var dentes = _denteService.FindAll();
            var viewModelss = new TratamentoFormViewModel { Dentes = dentes };
            return View(viewModelss);

            /*
            var tipoServicos = _tipoServicoService.FindAll();
            var viewModelsss = new TratamentoFormViewModel { TipoServicos = tipoServicos };
            return View(viewModelsss);
*/
 }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tratamento tratamento)
        {
            _tratamentoService.Insert(tratamento);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _tratamentoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _tratamentoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _tratamentoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}