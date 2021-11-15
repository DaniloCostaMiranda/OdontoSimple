using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class StatusService
    {
        private readonly OdontoSimpleContext _context;

        public StatusService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public async Task <List<Status>> FindAllAsync()
        {
            return await _context.Status.ToListAsync();
        }

        public void Insert(Status obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public async Task<Status> FindByIdAsync(int id)
        {
            return await _context.Status.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Status.FindAsync(id);
                _context.Status.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Status obj)
        {
            bool hasAny = await _context.Status.AnyAsync(x => x.Id == obj.Id);
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
