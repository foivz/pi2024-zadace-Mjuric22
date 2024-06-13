using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private static Jelo CreateObject(SqlDataReader reader)
        {
            int id_jelo = int.Parse(reader["Id_jelo"].ToString());
            int id_kategorija = int.Parse(reader["Id_Kategorija"].ToString());
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
    }
}
