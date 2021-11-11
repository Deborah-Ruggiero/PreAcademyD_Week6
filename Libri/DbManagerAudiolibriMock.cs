using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    class DbManagerAudiolibriMock : IManagerAudiolibro
    {
        static List<Audiolibro> audiolibri = new List<Audiolibro>()
        {
            new Audiolibro{ISBN=1, Autore="Autore1", DurataInMinuti=10, Titolo="TitoloLibro1"},
            new Audiolibro{ISBN=2, Autore="Autore2", DurataInMinuti=20, Titolo="TitoloLibro2"}
        };

        public bool Add(Audiolibro item)
        {
            throw new NotImplementedException();
        }

        public List<Audiolibro> GetAll()
        {
            return audiolibri;
        }

        public Audiolibro GetByIsbn(int isbn)
        {
            foreach (var item in audiolibri)
            {
                if (item.ISBN == isbn)
                {
                    return item;
                }
            }
            return null;
        }

        public bool ModificaDurata(Audiolibro audioLibro)
        {
            throw new NotImplementedException();
        }
    }
}
