using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Services
{
    public class ProcedimentService
    {
        private readonly OdontoSimpleContext _context;

        public ProcedimentService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<Procediment> FindAll()
        {
            return _context.Procediment.ToList();
        }

        public void Insert(Procediment obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}
