using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SZUUP.Models;

namespace SZUUP.Repozitoris
{
    public static class KategorijaRepozitorij
    {
        // Use a hardcoded connection string as per your constraints
        private static string connectionString = "YourConnectionStringHere"; // Replace with your actual connection string

        public static List<Kategorija> GetKategorije()
        {
            List<Kategorija> kategorije = new List<Kategorija>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id_Kategorija, Kategorija, Opis FROM Kategorije"; // Adjust table name if necessary
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Kategorija kategorija = new Kategorija
                        {
                            Id_Kategorija = (int)reader["Id_Kategorija"],
                            NazivKategorije = reader["Kategorija"].ToString(),
                            Opis = reader["Opis"].ToString()
                        };
                        kategorije.Add(kategorija);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
            }

            return kategorije;
        }
    }
}
