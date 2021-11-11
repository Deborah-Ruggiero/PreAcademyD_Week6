using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public class Audiolibro : Libro
    {
        public int DurataInMinuti { get; set; }
        public Audiolibro()
        {
                
        }

        public Audiolibro(string titolo, string autore, int isbn, int durataMinuti)
            :base(titolo, autore, isbn)
        {
            DurataInMinuti = durataMinuti;
        }

        public override string ToString()
        {
            return $"ISBN{ISBN} - Titolo: {Titolo}\t Autore: {Autore} \tDurata(minuti)= {DurataInMinuti} \t(Audiolibro)";
        }
    }
}
