using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public interface IManager<T> 
    {
        public List<T> GetAll();

        public T GetByIsbn(int isbn);

        public bool Add(T item);

        public T GetByTitle(string titolo);

    }
}
