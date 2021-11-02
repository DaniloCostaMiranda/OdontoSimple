﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OdontoSimple.Models
{
    public class Dente
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }

        public Dente()
        {
        }

        public Dente(int id, int numero, string nome)
        {
            Id = id;
            Numero = numero;
            Nome = nome;
        }

        /*
        public void AddProcediment(Procediment pr)
        {
            Procediments.Add(pr);
        }

        public void RemoveProcediment(Procediment pr)
        {
            Procediments.Remove(pr);
        }

        public double TotalProcediment()
        {
            return Procediments.Sum(x => x.Valor);
        }
        */
    }
}
