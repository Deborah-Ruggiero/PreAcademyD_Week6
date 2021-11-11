using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public abstract class Libro
    {
        public int ISBN { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }

        public Libro()
        {

        }
        public Libro(string titolo, string autore, int isbn)
        {
            Titolo = titolo;
            Autore = autore;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"ISBN{ISBN} - Titolo: {Titolo}\t Autore: {Autore}";
        }

    }
}
