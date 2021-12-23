using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class PacienteService
    {
        private readonly OdontoSimpleContext _context;

        public PacienteService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> FindByDateAsync(string pacienteInput)
        {
            var result = from obj in _context.Paciente select obj;

            if (pacienteInput != null)
            {
                result = result.Where(x => x.Nome.Contains(pacienteInput));
            }

            return await result
                .OrderByDescending(x => x.Nome)
                .ToListAsync();
        }

        public async Task<List<Paciente>> FindAllAsync()
        {
            return await _context.Paciente.OrderBy(x => x.Nome).ToListAsync();
        }

        public void Insert(Paciente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public async Task<Paciente> FindByIdAsync(int id)
        {
            return await _context.Paciente.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Paciente.FindAsync(id);
                _context.Paciente.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Paciente obj)
        {
            bool hasAny = await _context.Paciente.AnyAsync(x => x.Id == obj.Id);
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

//OrderBy(x => x.Nome)
