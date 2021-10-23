using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Services
{
    public class DenteService
    {
        private readonly OdontoSimpleContext _context;

        public DenteService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<Dente> FindAll()
        {
            return _context.Dente.ToList();
        }
    }
}
