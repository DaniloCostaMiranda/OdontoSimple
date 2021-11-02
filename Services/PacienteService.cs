using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Services
{
    public class PacienteService
    {
        private readonly OdontoSimpleContext _context;

        public PacienteService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<Paciente> FindAll()
        {
            return _context.Paciente.OrderBy(x => x.Nome).ToList();
        }

        public void Insert(Paciente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}

//OrderBy(x => x.Nome)
