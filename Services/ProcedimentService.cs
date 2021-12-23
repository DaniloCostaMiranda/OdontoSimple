using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class ProcedimentService
    {
        private readonly OdontoSimpleContext _context;

        public ProcedimentService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public async Task<List<Procediment>> FindAllAsync()
        {
            return await _context.Procediment.ToListAsync();
        }

        public void Insert(Procediment obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public async Task<Procediment> FindByIdAsync(int id)
        {
            return await _context.Procediment.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Procediment.FindAsync(id);
                _context.Procediment.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Procediment obj)
        {
            bool hasAny = await _context.Procediment.AnyAsync(x => x.Id == obj.Id);
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
