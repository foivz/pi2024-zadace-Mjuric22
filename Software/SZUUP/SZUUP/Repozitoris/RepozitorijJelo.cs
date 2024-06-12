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
    public class RepozitorijJelo
    {
        public static Jelo GetJelo(int id)
        {
            Jelo jelo = null;
            string sql = $"SELECT * FROM jelo WHERE Id_jelo = {id}";
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
        public static List<Jelo> GetJelo()
        {
            List<Jelo> jela = new List<Jelo>();
            string sql = "SELECT * FROM jelo";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Jelo jelo = CreateObject(reader);
                Jelo.Add(jelo);
            }
            reader.Close();
            DB.CloseConnection();
            return jelo;
        }

        private static Jelo CreateObject(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}