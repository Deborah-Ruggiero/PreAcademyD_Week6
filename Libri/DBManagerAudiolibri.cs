using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{
    public class DBManagerAudiolibri : IManagerAudiolibro
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Biblioteca;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Add(Audiolibro item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Audiolibro values(@Titolo, @Autore, @isbn, @DurataMin)";
                command.Parameters.AddWithValue("@Titolo", item.Titolo);
                command.Parameters.AddWithValue("@Autore", item.Autore);
                command.Parameters.AddWithValue("@isbn", item.ISBN);
                command.Parameters.AddWithValue("@DurataMin", item.DurataInMinuti);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public List<Audiolibro> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Audiolibro";

                SqlDataReader reader = command.ExecuteReader();

                List<Audiolibro> audiolibri = new List<Audiolibro>();

                while (reader.Read())
                {
                    string titolo = (string)reader["Titolo"];
                    string autore = (string)reader["Autore"];
                    var isbn = (int)reader["ISBN"];
                    var durataMinuti = (int)reader["DurataInMinuti"];

                    Audiolibro al = new Audiolibro(titolo, autore, isbn, durataMinuti);
                    audiolibri.Add(al);
                }
                connection.Close();

                return audiolibri;
            }
        }

        public Audiolibro GetByIsbn(int isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Audiolibro where ISBN = @isbn";
                command.Parameters.AddWithValue("@isbn", isbn);

                SqlDataReader reader = command.ExecuteReader();

                Audiolibro audiolibro = null;

                while (reader.Read())
                {
                    string tit = (string)reader["Titolo"];
                    string autore = (string)reader["Autore"];
                    var isbn1 = (int)reader["ISBN"];
                    var durataMinuti = (int)reader["DurataInMinuti"];

                    audiolibro = new Audiolibro(tit, autore, isbn1, durataMinuti);
                }
                connection.Close();
                return audiolibro;
            }
        }

        public Audiolibro GetByTitle(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Audiolibro where Titolo = @Titolo";
                command.Parameters.AddWithValue("@Titolo", titolo);

                SqlDataReader reader = command.ExecuteReader();

                Audiolibro audiolibro = null;

                while (reader.Read())
                {
                    string tit = (string)reader["Titolo"];
                    string autore = (string)reader["Autore"];
                    var isbn = (int)reader["ISBN"];
                    var durataMinuti = (int)reader["DurataInMinuti"];

                    audiolibro = new Audiolibro(tit, autore, isbn, durataMinuti);                    
                }
                connection.Close();
                return audiolibro;
            }
        }

        public bool ModificaDurata(Audiolibro audioLibro, int durataModificata)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update dbo.Audiolibro set DurataInMinuti = @DurataInMinuti where ISBN = @Isbn";
                command.Parameters.AddWithValue("@Isbn", audioLibro.ISBN);
                command.Parameters.AddWithValue("@DurataInMinuti", durataModificata);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }
    }
}
