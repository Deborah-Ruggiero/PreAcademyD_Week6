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
        // due libri sono uguali se hanno lo stesso ISBN(cartecei e audiolibri NON hanno lo stesso ISBN)--opzionale

        // Gestire il db sia in connected mode che i repository mock

        //private static DBManagerAudiolibriMock dbAudiolibro = new DBManagerAudiolibriMock();
        //private static DBManagerLibriCartaceiMock dbLibroCartaceo = new DBManagerLibriCartaceiMock();
        private static DBManagerAudiolibri dbAudiolibro = new DBManagerAudiolibri();
        private static DBManagerLibriCartacei dbLibroCartaceo = new DBManagerLibriCartacei();
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
                        VisualizzaAudiolibri();
                        break;
                    case 4:
                        //Modifica Quantità di un libro cartaceo
                        //faccio visualizzare tutti i libri cartacei e poi faccio scegliere quale far modificare
                        ModificaQuantitàLibroCartaceo();
                        break;
                    case 5:
                       
                        break;
                    case 6:
                        
                        break;
                    case 7:
                        InserisciNuovoLibro();
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }

        private static void InserisciNuovoLibro()
        {
            Console.WriteLine("Quale libro vuoi inserire?");
            Console.WriteLine("1. Libro Cartaceo");
            Console.WriteLine("2. Audiolibro");
            int scelta;
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 1 && scelta <= 2))
            {
                Console.WriteLine("Errore. Riprova:");
            }
            switch (scelta)
            {
                case 1:
                    //TODO: chiedo all'utente di inserire i dati che mi servono per creare un nuovo LibroCartaceo
                    string titolo = "TitoloProva";
                    string autore = "AutoreProva";
                    int isbn = 1234;
                    int numPagine = 100;
                    int scorteInMagazzino = 3;

                    var libroCartaceo = new LibroCartaceo(titolo, autore, isbn, numPagine, scorteInMagazzino);
                    dbLibroCartaceo.Add(libroCartaceo);
                    break;
                case 2:
                    break;
            }
        }

        private static void ModificaQuantitàLibroCartaceo()
        {
            VisualizzaLibriCartacei();
            Console.WriteLine("Quale Libro vuoi modificare? Inserisci l'isbn");
            int librodaModificare;           

            while (!(int.TryParse(Console.ReadLine(), out librodaModificare)))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }

            var libroEsistente = dbLibroCartaceo.GetByIsbn(librodaModificare);
            if (libroEsistente == null)
            {
                Console.WriteLine("Non esiste nessun audiolibro con questo isbn");
            }
            else
            {
                int quantità;
                Console.WriteLine("Qual è la nuova quantità?");
                while (!(int.TryParse(Console.ReadLine(), out quantità) && quantità>0))
                {
                    Console.WriteLine("Valore errato. Riprova:");
                }                

                bool esito = dbLibroCartaceo.ModificaQuantità(libroEsistente, quantità);
                if (esito == true)
                {
                    Console.WriteLine("Modifica effettuata");
                }
                else
                {
                    Console.WriteLine("Errore generico");
                }
            }
        }

        private static void VisualizzaAudiolibri()
        {
            Console.WriteLine("Tutti gli Audiolibri presenti nella biblioteca sono:\n");
            var audiolibri = dbAudiolibro.GetAll();
            int numElenco = 1;
            foreach (var item in audiolibri)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }
        }

        private static void VisualizzaLibriCartacei()
        {
            Console.WriteLine("Tutti i Libri cartacei presenti nella biblioteca sono:\n");
            var libriCartacei = dbLibroCartaceo.GetAll();
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
