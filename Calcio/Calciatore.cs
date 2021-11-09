using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcio
{
     class Calciatore : Atleta
    {
        public int NumeroMaglia { get; set; }
        public Ruolo Ruolo { get; set; }

        public Calciatore(string nome, string cognome, int età, int numeroMaglia, Ruolo ruolo)
            :base(nome, cognome, età)
        {
            NumeroMaglia = numeroMaglia;
            Ruolo = ruolo;
        }

        public override string ToString()
        {
            return $"Maglia n. {NumeroMaglia} - {Nome} {Cognome} - ruolo {Ruolo}";
        }

    }

    public enum Ruolo
    {
        Attaccante,
        Centrocampista,
        Difensore,
        Portiere
    }
}
