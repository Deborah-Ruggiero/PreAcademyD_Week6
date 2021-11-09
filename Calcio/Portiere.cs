using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcio
{
    class Portiere :Calciatore
    {
        public int GoalSubiti { get; set; } = 0;

        public Portiere(string nome, string cognome, int età/*, int numermoMaglia, Ruolo ruolo*/)
            :base(nome, cognome, età, 1, Ruolo.Portiere)
        {

        }
        

    }
}
