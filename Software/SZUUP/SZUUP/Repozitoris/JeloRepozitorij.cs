using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SZUUP.Models;

namespace SZUUP.Repozitoris
{
    internal class JeloRepozitorij
    {
        public static Jelo GetJelo(int id_jelo)
        {
            Jelo jelo = null;
            string sql = $"SELECT * FROM jelo WHERE Id_jelo = {id_jelo}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                jelo = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return jelo;
        }

        public static List<Jelo> GetJela()
        {
            List<Jelo> jela = new List<Jelo>();
            string sql = "SELECT * FROM jelo";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Jelo jelo = CreateObject(reader);
                jela.Add(jelo);
            }
            reader.Close();
            DB.CloseConnection();
            return jela;
        }

        public static void DodajJelo(Jelo jelo)
        {
            int newIdJelo = GetNextIdJelo();
            string sql = $"INSERT INTO jelo (Id_jelo, Kategorija, Naziv, Cijena, Detalji_o_jelu) VALUES ({newIdJelo}, {jelo.Id_Kategorija}, '{SanitizeInput(jelo.Naziv)}', {jelo.Cijena}, '{SanitizeInput(jelo.Detalji)}')";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void UpdateJelo(Jelo jelo)
        {
            string sql = $"UPDATE jelo SET Kategorija = {jelo.Id_Kategorija}, Naziv = '{SanitizeInput(jelo.Naziv)}', Cijena = {jelo.Cijena}, Detalji_o_jelu = '{SanitizeInput(jelo.Detalji)}' WHERE Id_jelo = {jelo.Id_jelo}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void ObrisiJelo(int id_jelo)
        {
            string sql = $"DELETE FROM jelo WHERE Id_jelo = {id_jelo}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        private static int GetNextIdJelo()
        {
            int nextId = 1; // Default value if table is empty
            string sql = "SELECT MAX(Id_jelo) AS MaxId FROM jelo";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                if (reader["MaxId"] != DBNull.Value)
                {
                    nextId = Convert.ToInt32(reader["MaxId"]) + 1;
                }
                reader.Close();
            }
            DB.CloseConnection();
            return nextId;
        }

        private static Jelo CreateObject(SqlDataReader reader)
        {
            int id_jelo = int.Parse(reader["Id_jelo"].ToString());
            int id_kategorija = int.Parse(reader["Kategorija"].ToString()); // Corrected column name
            string naziv = reader["Naziv"].ToString();
            float cijena = float.Parse(reader["Cijena"].ToString());
            string detalji = reader["Detalji_o_jelu"].ToString();

            var jelo = new Jelo
            {
                Id_jelo = id_jelo,
                Id_Kategorija = id_kategorija,
                Naziv = naziv,
                Cijena = cijena,
                Detalji = detalji
            };

            return jelo;
        }

        private static string SanitizeInput(string input)
        {
            return input.Replace("'", "''"); // Simple sanitization for SQL injection prevention
        }
    }
}
