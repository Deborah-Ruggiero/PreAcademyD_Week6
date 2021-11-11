using System;
using System.Collections.Generic;

namespace Libri
{
    class Program
    {
        // Creare un programma per la gestione di libri da parte del proprietario del sito
        // I libri hanno titolo - autore - codice ISBN -> abstract
        // Gli audiolibri hanno anche la durata in minuti
        // I libri cartacei hanno il numero di pagine e la quantità in magazzino

        // Il proprietario può
        // vedere tutti i libri stampando titolo, autore e se è o no audiolibro
        // vedere tutta la lista di libri cartacei
        // vedere tutta la lista di audiolibri
        // Modificare la quantità di libri cartacei in magazzino
        // Modificare la durata in minuti di un audiolibro
        // Cercare per titolo tutti i film (Se inserisce un titolo gli viene mostrato sia il libro cartaceo che l'audiolibro)
        // Può inserire un nuovo libro cartaceo o audiolibro 
        // Nota:prima di inserirlo verificare che non sia già presente tramite codice ISBN
        // due libri sono uguali se hanno lo stesso ISBN(cartecei e audiolibri NON hanno lo stesso ISBN)

        // Gestire il db sia in connected mode che i repository mock

        private static DbManagerAudiolibriMock dbAudiolibro = new DbManagerAudiolibriMock();
        private static DBManagerLibriCartaceiMock dbLibroCartaceo= new DBManagerLibriCartaceiMock();
        static void Main(string[] args)
        {
            

            Console.WriteLine("Benvenuto nella Biblioteca!");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("--------------------------------Menu----------------------------");
                Console.WriteLine("Premi 1 per vedere tutti i libri");
                Console.WriteLine("Premi 2 per vedere tutti i libri cartacei");
                Console.WriteLine("Premi 3 per vedere tutti gli audiolibri");
                Console.WriteLine("Premi 4 per modificare la quantità di libri cartacei");
                Console.WriteLine("Premi 5 per modificare la durata in minuti di un audiolibro");
                Console.WriteLine("Premi 6 per vedere tutti i libri con quel titolo");
                Console.WriteLine("Premi 7 per inserire un nuovo libro");

                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare!");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 7));

                switch (scelta)
                {
                    case 1:
                        //Visualizza Tutti i libri (Audiolibri e libri cartacei)
                        VisualizzaTutti();
                        break;
                    case 2:
                        //visualizza tutti i libri cartacei
                        VisualizzaLibriCartacei();
                        break;
                    case 3:
                        //tutti gli audiolibri
                        break;
                    case 4:
                        //Modifica Quantità di un libro cartaceo
                        //faccio visualizzare tutti i libri cartacei e poi faccio scegliere quale far modificare
                        break;
                    case 5:
                       
                        break;
                    case 6:
                        
                        break;
                    case 7:
                        
                        break;
                    case 8:
                        
                        break;
                    case 9:
                        
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }

        private static void VisualizzaLibriCartacei()
        {
            Console.WriteLine("Tutti i Libri cartacei presenti nella biblioteca sono:\n");
            List<LibroCartaceo> libriCartacei = dbLibroCartaceo.GetAll();
            int numElenco = 1;
            foreach (var item in libriCartacei)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }
        }

        private static void VisualizzaTutti()
        {
            Console.WriteLine("Tutti i Libri presenti nella biblioteca sono:\n");
            List<LibroCartaceo> libriCartacei = dbLibroCartaceo.GetAll();
            List<Audiolibro> audiolibri = dbAudiolibro.GetAll();

            List<Libro> listaLibri = new List<Libro>();
            listaLibri.AddRange(libriCartacei);
            listaLibri.AddRange(audiolibri);

            //foreach (var item in libriCartacei)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //foreach (var item in audiolibri)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            int numElenco = 1;
            foreach (var item in listaLibri)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }
        }
    }
}
