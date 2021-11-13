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

        public TratamentoService(OdontoSimpleContext context, DenteService denteService, PacienteService pacienteService)
        {
            _context = context;
            _pacienteService = pacienteService;
            _denteService = denteService;
        }

        public async Task<List<Tratamento>>FindByDateAsync(DateTime? minDate, DateTime? maxDate, string pacienteInput)
        {
            var result = from obj in _context.Tratamento.Include(x=>x.Paciente).Include(x=>x.Dente) select obj;

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

        public async Task<List<Tratamento>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
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
            return await result
                
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<Tratamento>> FindAllAsync()
        {
            return await _context.Tratamento.Include(obj => obj.Dente).Include(obj => obj.Paciente).ToListAsync();
        }

        public async Task InsertAsync(Tratamento obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Tratamento> FindByIdAsync(int id)
        {
            return await _context.Tratamento.Include(obj => obj.Dente).Include(obj => obj.Paciente).FirstOrDefaultAsync(obj => obj.Id == id);
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
