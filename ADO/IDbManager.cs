using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public interface IDbManager
    {
        public void GetAllFilms();
        public void GetFilmByTitolo(string titolo);
        public void GetFilmByGenere(string genere);
        /// <summary>
        /// Restituisce i film del genere passato in input che hanno una duarata superione a durataMin passata in input
        /// </summary>
        /// <param name="genere"></param>
        /// <param name="durataMin"></param>
        public void GetFilmByGenereEDurataMin(string genere, int durataMin);

        /// <summary>
        /// Restituisce i film con durata minore della durataMax passata in input. 
        /// </summary>
        /// <param name="durataMax"></param>
        public void GetFilmByDurataMax(int durataMax);
        public void GetNumeroDiFilm();
        public void InserisciFilm(string titolo, string genre, int durata);

        public void ModificaDurataFilm(int idFilmDaModificare);
        public void EliminaFilm(int idFilmDaEliminare);
    }
}
