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

        public TratamentoService(OdontoSimpleContext context)
        {
            _context = context;
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
