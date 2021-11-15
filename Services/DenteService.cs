using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdontoSimple.Models;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class DenteService
    {
        private readonly OdontoSimpleContext _context;

        public DenteService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public async Task<List<Dente>> FindAllAsync()
        {
            return await _context.Dente.OrderBy(x => x.Numero).ToListAsync();
        }

        public void Insert(Dente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public async Task<Dente> FindByIdAsync(int id)
        {
            return await _context.Dente.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Dente.FindAsync(id);
                _context.Dente.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Dente obj)
        {
            bool hasAny = await _context.Dente.AnyAsync(x => x.Id == obj.Id);
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
