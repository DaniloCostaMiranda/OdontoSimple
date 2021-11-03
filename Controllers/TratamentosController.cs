using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdontoSimple.Models;
using OdontoSimple.Services;
using OdontoSimple.Models.ViewModels;
using OdontoSimple.Services.Exceptions;
using System.Diagnostics;

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
            if (!ModelState.IsValid)
            {
                var dentes = _denteService.FindAll();
                var viewModel = new TratamentoFormViewModel { Tratamento = tratamento, Dentes = dentes };
                return View(viewModel);
            }
            _tratamentoService.Insert(tratamento);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = _tratamentoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
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
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _tratamentoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _tratamentoService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Dente> dentes = _denteService.FindAll();
            TratamentoFormViewModel viewModel = new TratamentoFormViewModel { Tratamento = obj, Dentes = dentes };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tratamento tratamento)
        {
            if (!ModelState.IsValid)
            {
                var dentes = _denteService.FindAll();
                var viewModel = new TratamentoFormViewModel { Tratamento = tratamento, Dentes = dentes };
                return View(viewModel);
            }

            if (id != tratamento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _tratamentoService.Update(tratamento);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundExceptions e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}