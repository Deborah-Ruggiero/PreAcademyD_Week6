using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAcademyD_Week6
{
    class Persona
    {
        //proprietà
        public string Nome { get; set; }
        public string Cognome { get; set; } = "sconosciuto";
        public int AnnoDiNascita { get; set; }
        public DateTime DataDiNascita { get; set; }
        protected string soprannome { get; set; } = "Pippo";

        public Persona()
        {

        }
        //public Persona(string nome, string cognome, int annoDiNascita, DateTime dataNascita)
        //{
        //    Nome = nome;
        //    Cognome = cognome;
        //    AnnoDiNascita = annoDiNascita;
        //    DataDiNascita = dataNascita;
        //}

        public Persona(string nome, string cognome, DateTime dataNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = dataNascita.Year;
            DataDiNascita = dataNascita;
        }

        //public Persona(string nome)
        //{
        //    Nome = nome;           
        //}

        //Metodo
        public void Saluta()
        {
            Console.WriteLine($"Ciao, sono una PERSONA e mi chiamo {Nome}");
        }

        //public abstract int CalcolaEtà();

        public override string ToString()
        {
            return $"{Nome} {Cognome} nato il {DataDiNascita.ToShortDateString()}";
        }
    }
}
