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

        private readonly ProcedimentService _procedimentService;

        private readonly StatusService _statusService;

        private readonly TipoServicoService _tipoServicoService;

        private readonly ProfissionalService _profissionalService;


        public TratamentosController(TratamentoService tratamentoService, DenteService denteService, PacienteService pacienteService, ProcedimentService procedimentService, StatusService statusService, TipoServicoService tipoServicoService, ProfissionalService profissionalService)
        {
            _tratamentoService = tratamentoService;
            _pacienteService = pacienteService;
            _denteService = denteService;
            _procedimentService = procedimentService;
            _statusService = statusService;
            _tipoServicoService = tipoServicoService;
            _profissionalService = profissionalService;

        }

        public async Task<IActionResult> Index()
        {
            var list =await _tratamentoService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> SimpleSearc(DateTime? minDate, DateTime? maxDate, string pacienteInput)
        {
            
            if (!minDate.HasValue)
            {
                //minDate = new DateTime(DateTime.Now.Year, 1, 1);
                minDate = new DateTime(1980, 1, 1);
            }
            
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            ViewData["pacienteInput"] = pacienteInput;

            var result = await _tratamentoService.FindByDateAsync(minDate, maxDate, pacienteInput);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearc(DateTime? minDate, DateTime? maxDate, string pacienteInput)
        {

            if (!minDate.HasValue)
            {
                minDate = new DateTime(1980, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            ViewData["pacienteInput"] = pacienteInput;
            

            var result = await _tratamentoService.FindByDateGroupingAsync(minDate, maxDate, pacienteInput);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {

            var pacientes = await _pacienteService.FindAllAsync();
            var dentes = await _denteService.FindAllAsync();
            var procediments = await _procedimentService.FindAllAsync();
            var statuss = await _statusService.FindAllAsync();
            var tipoServicos = await _tipoServicoService.FindAllAsync();
            var profissionals = await _profissionalService.FindAllAsync();
            var viewModelss = new TratamentoFormViewModel {Dentes = dentes, Pacientes = pacientes, Procediments = procediments, Statuss = statuss, TipoServicos = tipoServicos, Profissionals = profissionals };
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
                var procediments = await _procedimentService.FindAllAsync();
                var statuss = await _statusService.FindAllAsync();
                var tipoServicos = await _tipoServicoService.FindAllAsync();
                var profissionals = await _profissionalService.FindAllAsync();
                var viewModel = new TratamentoFormViewModel { Tratamento = tratamento, Dentes = dentes, Pacientes = pacientes, Procediments = procediments, Statuss = statuss, TipoServicos = tipoServicos, Profissionals = profissionals };
                return View(viewModel);
            }

            await _tratamentoService.InsertAsync(tratamento);
            //return RedirectToAction(nameof(Details), new { id = tratamento.Id });
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
            List<Procediment> procediments = await _procedimentService.FindAllAsync();
            List<Status> statuss = await _statusService.FindAllAsync();
            List<TipoServico> tipoServicos = await _tipoServicoService.FindAllAsync();
            List<Profissional> profissionals = await _profissionalService.FindAllAsync();
            TratamentoFormViewModel viewModel = new TratamentoFormViewModel { Tratamento = obj, Dentes = dentes, Pacientes = pacientes, Procediments = procediments, Statuss = statuss, TipoServicos = tipoServicos, Profissionals = profissionals };

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
                var procediments = await _procedimentService.FindAllAsync();
                var statuss = await _statusService.FindAllAsync();
                var tipoServicos = await _tipoServicoService.FindAllAsync();
                var profissionals = await _profissionalService.FindAllAsync();
                var viewModel = new TratamentoFormViewModel { Tratamento = tratamento, Dentes = dentes, Pacientes = pacientes, Procediments = procediments, Statuss = statuss, TipoServicos = tipoServicos, Profissionals = profissionals };
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

        [HttpGet]
        public async Task<IActionResult> AdicionarDenteProcedimento(int tratamentoId)
        {
            

            var viewModel = new DenteTratamentoViewModel()
            {
                TratamentoId = tratamentoId,
                Dentes =await _denteService.FindAllAsync() ,
                Procediments = await _procedimentService.FindAllAsync()
            };

            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarDenteProcedimento(DenteTratamentoViewModel model)
        {
            var tratamento = await _tratamentoService.FindByIdAsync(model.TratamentoId);
            var dente = new TratamentoDente()
            {
                TratamentoId =model.TratamentoId,
                DenteId = model.DenteId
            };

            foreach (var item in model.ProcedimentId)
            {
                dente.DenteProcedimentos.Add(new DenteProcedimento(){
                    ProcedimentId = item
                }); 
            }

            tratamento.TratamentoDentes.Add(dente);
            await _tratamentoService.UpdateAsync(tratamento);

            ;
            // Salva informações...
            return RedirectToAction(nameof(Index));
        }


    }
}