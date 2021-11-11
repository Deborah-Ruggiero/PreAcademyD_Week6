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
                        ModificaDurataAudiolibro();
                        break;
                    case 6:
                        CercaLibriPerTitolo();
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

        private static void CercaLibriPerTitolo()
        {
            Console.WriteLine("Inserisci il titolo da ricercare:");
            string titoloDaRicercare = Console.ReadLine();
            var l1=dbAudiolibro.GetByTitle(titoloDaRicercare);
            var l2=dbLibroCartaceo.GetByTitle(titoloDaRicercare);
            List<Libro> libri = new List<Libro>();
            libri.Add(l1);
            libri.Add(l2);
            Console.WriteLine("Ecco i libri(audiolibri/libri cartacei) corrispondenti al titolo inserito:");
            foreach (var item in libri)
            {
                Console.WriteLine(item);
            }
        }

        private static void ModificaDurataAudiolibro()
        {
            VisualizzaAudiolibri();
            Console.WriteLine("Quale Libro vuoi modificare? Inserisci l'isbn");
            int librodaModificare;

            while (!(int.TryParse(Console.ReadLine(), out librodaModificare)))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }

            var libroEsistente = dbAudiolibro.GetByIsbn(librodaModificare);
            if (libroEsistente == null)
            {
                Console.WriteLine("Non esiste nessun audiolibro con questo isbn");
            }
            else
            {
                int durata;
                Console.WriteLine("Qual è la nuova durata?");
                while (!(int.TryParse(Console.ReadLine(), out durata) && durata > 0))
                {
                    Console.WriteLine("Valore errato. Riprova:");
                }

                bool esito = dbAudiolibro.ModificaDurata(libroEsistente, durata);
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
                    int isbn;
                    Console.WriteLine("Inserisci ISBN");
                    while(!(int.TryParse(Console.ReadLine(), out isbn) && isbn>0 && dbLibroCartaceo.GetByIsbn(isbn)==null))
                    {
                        Console.WriteLine("Formato errato e/o codice isbn già presente. Riprova");
                    }
                    Console.WriteLine("Inserisci titolo");
                    string titolo = Console.ReadLine();
                    Console.WriteLine("Inserisci autore");
                    string autore = Console.ReadLine();
                        
                    int numPagine;
                    Console.WriteLine("Inserisci numero pagine");
                    while (!(int.TryParse(Console.ReadLine(), out numPagine) && numPagine > 0))
                    {
                        Console.WriteLine("Formato errato. Deve essere un intero. Riprova");
                    }
                    int scorteInMagazzino;
                    Console.WriteLine("Inserisci scorte in magazzino");
                    while (!(int.TryParse(Console.ReadLine(), out scorteInMagazzino) && scorteInMagazzino > 0))
                    {
                        Console.WriteLine("Formato errato. Deve essere un intero. Riprova");
                    }

                    var libroCartaceo = new LibroCartaceo(titolo, autore, isbn, numPagine, scorteInMagazzino);
                    bool esito=dbLibroCartaceo.Add(libroCartaceo);
                    if (esito)
                    {
                        Console.WriteLine("Aggiunto correttamente");
                    }
                    else
                    {
                        Console.WriteLine("Errore. Non è stato possibile aggiungere!");
                    }
                    break;
                case 2:
                    
                    int isbn1;
                    Console.WriteLine("Inserisci ISBN");
                    while (!(int.TryParse(Console.ReadLine(), out isbn1) && isbn1 > 0 && dbAudiolibro.GetByIsbn(isbn1)==null))
                    {
                        Console.WriteLine("Formato errato e/o codice isbn già presente. Riprova. Riprova");
                    }
                    Console.WriteLine("Inserisci titolo");
                    string tit = Console.ReadLine();
                    Console.WriteLine("Inserisci autore");
                    string aut = Console.ReadLine();

                    int durata;
                    Console.WriteLine("Inserisci numero pagine");
                    while (!(int.TryParse(Console.ReadLine(), out durata) && durata > 0))
                    {
                        Console.WriteLine("Formato errato. Deve essere un intero. Riprova");
                    }
                    
                    var audiolibro = new Audiolibro(tit,aut,isbn1, durata);
                    
                    bool esito1 = dbAudiolibro.Add(audiolibro);
                    if (esito1)
                    {
                        Console.WriteLine("Aggiunto correttamente");
                    }
                    else
                    {
                        Console.WriteLine("Errore. Non è stato possibile aggiungere!");
                    }
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
                Console.WriteLine("Non esiste nessun libro cartaceo con questo isbn");
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
