using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri
{

    class DBManagerLibriCartacei : IManagerLibroCartaceo
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Biblioteca;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Add(LibroCartaceo item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into LibroCartaceo values(@isbn, @Titolo, @Autore, @NumPag, @Quantita)";
                command.Parameters.AddWithValue("@Titolo", item.Titolo);
                command.Parameters.AddWithValue("@Autore", item.Autore);
                command.Parameters.AddWithValue("@isbn", item.ISBN);
                command.Parameters.AddWithValue("@NumPag", item.NumeroDiPagine);
                command.Parameters.AddWithValue("@Quantita", item.QuantitàInMagazzino);

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

        public List<LibroCartaceo> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from LibroCartaceo";

                SqlDataReader reader = command.ExecuteReader();

                List<LibroCartaceo> libriCartacei = new List<LibroCartaceo>();

                while (reader.Read())
                {
                    string titolo = (string)reader["Titolo"];
                    string autore = (string)reader["Autore"];
                    var isbn = (int)reader["ISBN"];
                    var qta = (int)reader["QuantitàMagazzino"];
                    var numP = (int)reader["NumeroPagine"];
          
                    LibroCartaceo lc = new LibroCartaceo(titolo, autore, isbn, numP, qta);
                    libriCartacei.Add(lc);
                }
                connection.Close();
                return libriCartacei;
            }
        }

        public LibroCartaceo GetByIsbn(int isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from LibroCartaceo where ISBN = @isbn";
                command.Parameters.AddWithValue("@isbn", isbn);

                SqlDataReader reader = command.ExecuteReader();

                LibroCartaceo libroCartaceo = null;

                while (reader.Read())
                {
                    string titolo = (string)reader["Titolo"];
                    string autore = (string)reader["Autore"];
                    var isbn1 = (int)reader["ISBN"];
                    var qta = (int)reader["QuantitàMagazzino"];
                    var numP = (int)reader["NumeroPagine"];

                    libroCartaceo = new LibroCartaceo(titolo, autore, isbn1, numP, qta);
                }
                connection.Close();
                return libroCartaceo;
            }
        }

        public LibroCartaceo GetByTitle(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from LibroCartaceo where Titolo = @titolo";
                command.Parameters.AddWithValue("@titolo", titolo);

                SqlDataReader reader = command.ExecuteReader();

                LibroCartaceo libroCartaceo = null;

                while (reader.Read())
                {
                    string autore = (string)reader["Autore"];
                    var isbn = (int)reader["ISBN"];
                    var qta = (int)reader["QuantitàMagazzino"];
                    var numP = (int)reader["NumeroPagine"];

                    libroCartaceo = new LibroCartaceo(titolo, autore, isbn, numP, qta);
                }
                connection.Close();
                return libroCartaceo;
            }
        }

        public bool ModificaQuantità(LibroCartaceo libro, int quantità)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update LibroCartaceo set QuantitàMagazzino = @qta where ISBN = @Isbn";
                command.Parameters.AddWithValue("@Isbn", libro.ISBN);
                command.Parameters.AddWithValue("@qta", quantità);

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
