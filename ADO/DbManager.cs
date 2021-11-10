using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    class DbManager : IDbManager
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Videoteca1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public void GetAllFilms()
        {
           using(SqlConnection connection =new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Film";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"];
                    var titolo = reader["Titolo"];
                    var genere = reader["Genere"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - Genere: {genere} - Durata: {durata}");
                }
                connection.Close();     
            }
        }

        public void GetFilmByDurataMax(int durataMax)
        {
            throw new NotImplementedException();
        }

        public void GetFilmByGenere(string genere)
        {
            throw new NotImplementedException();
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
