using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class TipoServicoService
    {
        private readonly OdontoSimpleContext _context;

        public TipoServicoService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public async Task<List<TipoServico>> FindAllAsync()
        {
            return await _context.TipoServico.ToListAsync();
        }

        public void Insert(TipoServico obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public async Task<TipoServico> FindByIdAsync(int id)
        {
            return await _context.TipoServico.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.TipoServico.FindAsync(id);
                _context.TipoServico.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(TipoServico obj)
        {
            bool hasAny = await _context.TipoServico.AnyAsync(x => x.Id == obj.Id);
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
