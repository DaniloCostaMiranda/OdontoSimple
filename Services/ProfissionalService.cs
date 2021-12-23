using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class ProfissionalService
    {
        private readonly OdontoSimpleContext _context;

        public ProfissionalService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public async Task<List<Profissional>> FindAllAsync()
        {
            return await _context.Profissional.ToListAsync();
        }

        public void Insert(Profissional obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public async Task<Profissional> FindByIdAsync(int id)
        {
            return await _context.Profissional.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Profissional.FindAsync(id);
                _context.Profissional.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Profissional obj)
        {
            bool hasAny = await _context.Profissional.AnyAsync(x => x.Id == obj.Id);
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
