using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Services.Exceptions;

namespace OdontoSimple.Services
{
    public class TratamentoService
    {
        private readonly OdontoSimpleContext _context;

        public TratamentoService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<Tratamento> FindAll()
        {
            return _context.Tratamento.Include(obj => obj.Dente).ToList();
        }

        public void Insert(Tratamento obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Tratamento FindById(int id)
        {
            return _context.Tratamento.Include(obj => obj.Dente).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Tratamento.Find(id);
            _context.Tratamento.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Tratamento obj)
        {
            if(!_context.Tratamento.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundExceptions("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
