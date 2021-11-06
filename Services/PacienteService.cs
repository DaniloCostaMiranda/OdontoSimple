﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Paciente>> FindAllAsync()
        {
            return await _context.Paciente.OrderBy(x => x.Nome).ToListAsync();
        }

        public void Insert(Paciente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}

//OrderBy(x => x.Nome)
