using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    class DbManagerMock : IDbManager
    {
        static List<Film> Films = new List<Film>() {
        new Film{ FilmId=1, Titolo="Titanic", Durata=240, Genere="Storico"},
        new Film{ FilmId=2, Titolo="Peter Pan", Durata=60, Genere="Animazione" }
        };


        public void GetAllFilms()
        {
            foreach (var item in Films)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetFilmByDurataMax(int durataMax)
        {
            throw new NotImplementedException();
        }

        public void GetFilmByGenere(string genere)
        {
            foreach (var item in Films)
            {
                if (item.Genere == genere)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void GetFilmByGenereEDurataMin(string genere, int durataMin)
        {
            throw new NotImplementedException();
        }

        public void GetFilmByTitolo(string titolo)
        {
            throw new NotImplementedException();
        }

        public void GetNumeroDiFilm()
        {
            throw new NotImplementedException();
        }
    }
}
