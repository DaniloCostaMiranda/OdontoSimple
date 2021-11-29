using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Data
{
    public class SeedingService
    {
        
        private OdontoSimpleContext _context;

        public SeedingService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Dente.Any() ||
                _context.Paciente.Any() ||
                _context.TipoServico.Any() ||
                _context.Status.Any() ||
                _context.Procediment.Any() ||
                _context.Profissional.Any() ||
                _context.Tratamento.Any()
                )
            {
                return; 
            }

            Dente d1 = new Dente(1, 13, "Incisivo");
            Dente d2 = new Dente(2, 23, "Molar");

            Paciente pa1 = new Paciente(1, "Bob Brown", "71991790397", "bob@gmail.com", "rua duarte, 51");
            Paciente pa2 = new Paciente(2, "Jorge Luiz", "7199900876", "horge@gmail.com", "alameda padua, 25");
        

            Procediment pr1 = new Procediment(1, "Coroa", 50.50);
            Procediment pr2 = new Procediment(2, "Implamente", 30.50);
            Procediment pr3 = new Procediment(3, "Restauracao", 10.50);

            Profissional pf1 = new Profissional(1, "Neto Souza", "71991919191", "Neto@hotmail.com", "Rua azevedo penha");
            Profissional pf2 = new Profissional(2, "Rogerio Neto", "71991999999", "Neto@hotmail.com", "Rua azevedo penha");

            Status u1 = new Status(1, "Aberto");
            Status u2 = new Status(2, "Fechado");

            TipoServico t1 = new TipoServico(1, "Estética");
            TipoServico t2 = new TipoServico(2, "Odontologia");

           
            Tratamento tr1 = new Tratamento(1, new DateTime(1986, 3, 27), u1, t1, d1, pr1,  pa1,  pf1, "Dipirona", "Ultrassom");
            Tratamento tr2 = new Tratamento(2, new DateTime(1989, 5, 13), u2, t2, d2, pr2,  pa2, pf2, "Tilenol", "RadioX");
            Tratamento tr3 = new Tratamento(3, new DateTime(1981, 9, 17), u1, t2, d1, pr3, pa2, pf1, "Tylex", "-");
           
            _context.Dente.AddRange(d1, d2);
            _context.Paciente.AddRange(pa1, pa2);
            _context.Procediment.AddRange(pr1, pr2, pr3);
            _context.Profissional.AddRange(pf1, pf2);
            _context.Status.AddRange(u1, u2);
            _context.TipoServico.AddRange(t1, t2);
            _context.Tratamento.AddRange(tr1, tr2, tr3);

            _context.SaveChanges();
            
        }
       
    }
}

