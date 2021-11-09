using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcio
{
    class Atleta
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public Atleta(string nome, string cognome, int età)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = età;
        }
    }
}
