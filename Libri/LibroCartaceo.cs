using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public class LibroCartaceo: Libro
    {
        public int NumeroDiPagine { get; set; }
        public int QuantitàInMagazzino { get; set; }
        public LibroCartaceo()
        {

        }

        public LibroCartaceo(string titolo, string autore, int isbn, int numeroPagine, int quantitaMagazzino)
            :base(titolo, autore, isbn)
        {
            NumeroDiPagine = numeroPagine;
            QuantitàInMagazzino = quantitaMagazzino;
        }
        public override string ToString()
        {
            return $"Titolo: {Titolo}\t Autore: {Autore} \t(Libro Cartaceo)";
        }

    }
}
