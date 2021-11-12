using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenti
{
    interface IManagerAgenti
    {
        public List<Agente> GetAll();
        public List<Agente> GetByAreaGeografica(string areaGeografica);
        public List<Agente> GetByAnniDiServizio(int anniDiServizio);
        public bool Add(Agente agente);

        public List<string> GetAllAreeGeografiche();
        public bool EsisteArea(string areaGeografica);
        public Agente GetByCF(string cf);
    }
}
