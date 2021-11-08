using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAcademyD_Week6
{
    class Studente : Persona
    {
        private static int MatricolaPartenza = 10000;

        public int Matricola { get; set; }


        public Studente()
        {

        }
        public Studente(string nomeStudente, string cognomeStudente, DateTime dataDiNascitaStudente) 
            : base(nomeStudente, cognomeStudente, dataDiNascitaStudente)
        {
            Matricola=MatricolaPartenza;
            MatricolaPartenza++;
        }



        public void SalutaTutti()
        {
            Console.WriteLine("Ciao a tutti");
            Console.WriteLine($"Il mio soprannome è {soprannome}");
        }

        public new void Saluta()
        {
            Console.WriteLine($"Ciao, sono uno STUDENTE e mi chiamo {Nome}");
        } 

        public override string ToString()
        {
            return $"{Matricola} - {Nome} {Cognome} - anno di nascita {AnnoDiNascita} - Data di bascita completa: {DataDiNascita.ToShortDateString()}";
        }

        //public override int CalcolaEtà()
        //{
        //    return DateTime.Today.Year - AnnoDiNascita;
        //}
    }
}
