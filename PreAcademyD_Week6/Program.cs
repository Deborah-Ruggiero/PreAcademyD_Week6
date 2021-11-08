using System;
using System.Collections;
using System.Collections.Generic;

namespace PreAcademyD_Week6
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            p1.Nome = "Renata";
            p1.Cognome = "Carriero";
            p1.AnnoDiNascita = 1987;
            p1.DataDiNascita = new DateTime(1987, 04, 01);
            p1.Saluta();


            //Persona p2 = new Persona("Alessandra", "Degan", 1980, new DateTime(1980, 04, 03));
            Persona p3 = new Persona("Topolino", "Disney", new DateTime(1921, 01, 01));            
            Console.WriteLine($"{p3.Nome} è nato nell'anno {p3.AnnoDiNascita}");

            //Persona p4 = new Persona("Deborah");
            //Console.WriteLine($"{p4.Nome} {p4.Cognome} {p4.DataDiNascita} è nato nell'anno {p4.AnnoDiNascita}");



            Studente s1 = new Studente();
            s1.Nome = "Valentina";
            s1.Cognome = "Loi";
            s1.AnnoDiNascita = 1988;
            s1.DataDiNascita = new DateTime(1988, 04, 02);
            s1.Matricola = 27949;

            s1.Saluta();
            s1.SalutaTutti();

            Console.WriteLine("Studenti");
            Studente s2 = new Studente();
            Studente s3 = new Studente("Mario", "Rossi", new DateTime(1980, 10, 12));
            Studente s4 = new Studente("Giuseppe", "Verdi", new DateTime(1860, 10,13));

            //ClasseProva //non visibile da qui perché "internal" al "Progetto Prova"

            //ClasseStatica cs = new ClasseStatica(); //non si possono costruire oggetti di classi statiche
            ClasseStatica.SalutaDaClasseStatica();
            string str= ClasseStatica.Nome;
            
            foreach (var item in ClasseStatica.parole)
            {
                Console.WriteLine(item);
            }

            ClasseStatica.parole.Add("parola4");

            foreach (var item in ClasseStatica.parole)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(s4.ToString());

            s4.Saluta(); 

        }
    }
}
