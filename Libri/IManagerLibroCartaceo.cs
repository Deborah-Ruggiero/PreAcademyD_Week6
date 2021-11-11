using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    interface IManagerLibroCartaceo: IManager<LibroCartaceo>
    {
        public bool ModificaQuantità(LibroCartaceo libroModificato, int quantità);
    }
}
