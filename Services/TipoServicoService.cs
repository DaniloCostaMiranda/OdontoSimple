using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Services
{
    public class TipoServicoService
    {
        private readonly OdontoSimpleContext _context;

        public TipoServicoService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<TipoServico> FindAll()
        {
            return _context.TipoServico.ToList();
        }

        public void Insert(TipoServico obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}
