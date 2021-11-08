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

        private readonly PacienteService _pacienteService;

        private readonly DenteService _denteService;


        public TratamentosController(TratamentoService tratamentoService, DenteService denteService, PacienteService pacienteService)
        {
            _tratamentoService = tratamentoService;
            _pacienteService = pacienteService;
            _denteService = denteService;

        }

        public async Task<IActionResult> Index()
        {
            var list =await _tratamentoService.FindAllAsync();
            return View(list);
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {

            var pacientes = await _pacienteService.FindAllAsync();
            var dentes = await _denteService.FindAllAsync();
            var viewModelss = new TratamentoFormViewModel { Dentes = dentes, Pacientes = pacientes };
            return View(viewModelss);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tratamento tratamento)
        {
            if (!ModelState.IsValid)
            {
                var dentes = await _denteService.FindAllAsync();
                var pacientes = await _pacienteService.FindAllAsync();
                var viewModel = new TratamentoFormViewModel { Tratamento = tratamento, Dentes = dentes, Pacientes = pacientes };
                return View(viewModel);
            }
            await _tratamentoService.InsertAsync(tratamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj =await _tratamentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tratamentoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _tratamentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _tratamentoService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Dente> dentes = await _denteService.FindAllAsync();
            List<Paciente> pacientes = await _pacienteService.FindAllAsync();
            TratamentoFormViewModel viewModel = new TratamentoFormViewModel { Tratamento = obj, Dentes = dentes, Pacientes = pacientes };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tratamento tratamento)
        {
            if (!ModelState.IsValid)
            {
                var dentes =await _denteService.FindAllAsync();
                var pacientes = await _pacienteService.FindAllAsync();
                var viewModel = new TratamentoFormViewModel { Tratamento = tratamento, Dentes = dentes, Pacientes = pacientes };
                return View(viewModel);
            }

            if (id != tratamento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                await _tratamentoService.UpdateAsync(tratamento);
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