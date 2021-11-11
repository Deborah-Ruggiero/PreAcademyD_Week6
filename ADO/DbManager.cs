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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Film where Durata<@d";
                command.Parameters.AddWithValue("@d", durataMax);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"];
                    var genere = reader["Genere"];
                    var titolo = reader["Titolo"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - Genere: {genere} - Durata: {durata}");
                }
                connection.Close();
            }
        }

        public void GetFilmByGenere(string genere)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Film where Genere=@g";
                command.Parameters.AddWithValue("@g", genere);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"];
                    var titolo = reader["Titolo"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - Genere: {genere} - Durata: {durata}");
                }
                connection.Close();
            }
        }

        public void GetFilmByGenereEDurataMin(string genere, int durataMin)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Film where Genere=@g and Durata>@d";
                command.Parameters.AddWithValue("@g", genere);
                command.Parameters.AddWithValue("@d", durataMin);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"];
                    var titolo = reader["Titolo"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - Genere: {genere} - Durata: {durata}");
                }
                connection.Close();
            }
        }


        public void GetFilmByTitolo(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Film where Titolo= @t";
                command.Parameters.AddWithValue("@t", titolo);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"];                    
                    var gen = reader["Genere"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - Genere: {gen} - Durata: {durata}");
                }
                connection.Close();
            }
        }

        public void GetNumeroDiFilm()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select count(*) from Film ";

                int numFilm= (int)command.ExecuteScalar();
                Console.WriteLine($"ci sono {numFilm} film nella videoteca");
                connection.Close();
            }
        }


        public void InserisciFilm(string titolo, string genere, int durata)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Film values( @Titolo, @Durata, @Genere)";                
                command.Parameters.AddWithValue("@Titolo", titolo);
                command.Parameters.AddWithValue("@Durata", durata);
                command.Parameters.AddWithValue("@Genere", genere);

                int rigaInserita=command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Film inserito correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile inserire il film");
                }
                connection.Close();
            }
        }

        public void ModificaDurataFilm(int idFilmDaModificare, int nuovaDurata)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "update Film set Durata=@Durata where FilmId=@Id";
                command.Parameters.AddWithValue("@Id", idFilmDaModificare);
                command.Parameters.AddWithValue("@Durata", nuovaDurata);               

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Durata aggiornata correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile aggiornare la durata. Ricontrolla i dati inseriti!");
                }
                connection.Close();
            }
        }
        public void EliminaFilm(int idFilmDaEliminare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete Film where FilmId=@Id";
                command.Parameters.AddWithValue("@Id", idFilmDaEliminare);                

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Film eliminato correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile eliminare il Film. Ricontrolla i dati inseriti!");
                }
                connection.Close();
            }
        }
    }
}
