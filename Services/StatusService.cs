using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Services
{
    public class StatusService
    {
        private readonly OdontoSimpleContext _context;

        public StatusService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public List<Status> FindAll()
        {
            return _context.Status.ToList();
        }

        public void Insert(Status obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}
