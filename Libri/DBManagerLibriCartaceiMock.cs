using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public class DBManagerLibriCartaceiMock : IManagerLibroCartaceo
    {
        static List<LibroCartaceo> libriCartacei = new List<LibroCartaceo>()
        {
            new LibroCartaceo{ISBN=100, Autore="Autore1", Titolo="TitoloLibro1", NumeroDiPagine=1000},
            new LibroCartaceo{ISBN=101, Autore="Autore2", Titolo="TitoloLibro2", NumeroDiPagine=1000}
        };

        public bool Add(LibroCartaceo item)
        {
            if (item != null)
            {
                var libroEsistente = GetByIsbn(item.ISBN);
                if (libroEsistente == null)
                {
                    libriCartacei.Add(item);
                    return true;
                }
            }
            return false;
        }

        public List<LibroCartaceo> GetAll()
        {
            return libriCartacei;
        }

        public LibroCartaceo GetByIsbn(int isbn)
        {
            foreach (var item in libriCartacei)
            {
                if (item.ISBN == isbn)
                {
                    return item;
                }
            }
            return null;
        }

        public LibroCartaceo GetByTitle(string titolo)
        {
            foreach (var item in libriCartacei)
            {
                if (item.Titolo == titolo)
                {
                    return item;
                }
            }
            return null;
        }

        public bool ModificaQuantità(LibroCartaceo libroModificato, int quantità)
        {
            foreach (var item in libriCartacei)
            {
                if (libroModificato.ISBN == item.ISBN)
                {
                    item.QuantitàInMagazzino = quantità;
                    return true;
                }
            }
            return false;
        }
    }
}
