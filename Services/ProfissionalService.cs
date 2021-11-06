using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Services
{
    public class ProfissionalService
    {
        private readonly OdontoSimpleContext _context;

        public ProfissionalService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<Profissional> FindAll()
        {
            return _context.Profissional.ToList();
        }

        public void Insert(Profissional obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }



    }
}
