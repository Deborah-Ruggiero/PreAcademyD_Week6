using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    class DBManagerLibriCartacei : IManagerLibroCartaceo
    {
        public bool Add(LibroCartaceo item)
        {
            throw new NotImplementedException();
        }

        public List<LibroCartaceo> GetAll()
        {
            throw new NotImplementedException();
        }

        public LibroCartaceo GetByIsbn(int isbn)
        {
            throw new NotImplementedException();
        }

        public LibroCartaceo GetByTitle(string titolo)
        {
            throw new NotImplementedException();
        }

        public bool ModificaQuantità(LibroCartaceo libroModificato, int quantità)
        {
            throw new NotImplementedException();
        }
    }
}
