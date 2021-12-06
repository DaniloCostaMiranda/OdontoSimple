using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Services.Exceptions;
using System.Threading.Tasks;

namespace OdontoSimple.Services
{
    public class TratamentoService
    {
        private readonly OdontoSimpleContext _context;

        private readonly PacienteService _pacienteService;

        private readonly DenteService _denteService;

        private readonly ProcedimentService _procedimentService;

        private readonly StatusService _statusService;

        private readonly TipoServicoService _tipoServicoService;

        private readonly ProfissionalService _profissionalService;


        public TratamentoService(OdontoSimpleContext context, DenteService denteService, PacienteService pacienteService, ProcedimentService procedimentService, StatusService statusService, TipoServicoService tipoServicoService, ProfissionalService profissionalService)
        {
            _context = context;
            _pacienteService = pacienteService;
            _denteService = denteService;
            _procedimentService = procedimentService;
            _statusService = statusService;
            _tipoServicoService = tipoServicoService;
            _profissionalService = profissionalService;
        }

        public async Task<List<Tratamento>>FindByDateAsync(DateTime? minDate, DateTime? maxDate, string pacienteInput)
        {
            var result = from obj in _context.Tratamento.Include(x=>x.Paciente).Include(x=>x.TratamentoDentes).Include(x=>x.Status).Include(x=>x.TipoServico).Include(x=>x.Profissional) select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            if(pacienteInput != null) { 
            result = result.Where(x => x.Paciente.Nome.Contains(pacienteInput));
            }

            return await result
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Status, Tratamento>>>FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate, string pacienteInput)
        {
            var result = from obj in _context.Tratamento select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            if (pacienteInput != null)
            {
                result = result.Where(x => x.Paciente.Nome.Contains(pacienteInput));
            }

            var inform = await result
                
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x=>x.Status)
                .OrderByDescending(x => x.Data)
                //.GroupBy(x=>x.Status)
                .ToListAsync();

            return inform.GroupBy(x=>x.Status).ToList();
        }

        public async Task<List<Tratamento>> FindAllAsync()
        {
            return await _context.Tratamento.Include(obj => obj.TratamentoDentes).Include(obj => obj.Paciente).Include(obj => obj.Status).Include(obj => obj.TipoServico).Include(obj => obj.Profissional).ToListAsync();
        }

        public async Task InsertAsync(Tratamento obj)
        {
            foreach (var item in obj.DentesId)
            {
                obj.TratamentoDentes.Add(new TratamentoDente()
                {
                    DenteId = item
                });
            }
          
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Tratamento> FindByIdAsync(int id)
        {
            var tratamento =  await _context.Tratamento.Include(obj => obj.TratamentoDentes).Include(obj => obj.Paciente).Include(obj => obj.Status).Include(obj => obj.TipoServico).Include(obj => obj.Profissional).FirstOrDefaultAsync(obj => obj.Id == id);

           
         

            return tratamento;
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Tratamento.FindAsync(id);
                _context.Tratamento.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
            
        }

        public async Task UpdateAsync(Tratamento obj)
        {
            bool hasAny = await _context.Tratamento.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundExceptions("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}