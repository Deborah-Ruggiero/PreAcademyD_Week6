using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public interface IManagerAudiolibro: IManager<Audiolibro>
    {
        //vanno aggiunti il metodo specifico per gli audiolibri
        public bool ModificaDurata(Audiolibro audioLibro);

    }
}
