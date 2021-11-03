using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdontoSimple.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
