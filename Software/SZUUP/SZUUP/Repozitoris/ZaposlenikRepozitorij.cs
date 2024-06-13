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
    internal class ZaposlenikRepozitorij
    {
        public static Zaposlenik GetZaposlenik(int id_zaposlenika)
        {
            Zaposlenik zaposlenik = null;
            string sql = $"SELECT * FROM zaposlenik WHERE Id_zaposlenika = {id_zaposlenika}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                zaposlenik = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return zaposlenik;
        }

        public static List<Zaposlenik> GetZaposlenici()
        {
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            string sql = "SELECT * FROM zaposlenik";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Zaposlenik zaposlenik = CreateObject(reader);
                zaposlenici.Add(zaposlenik);
            }
            reader.Close();
            DB.CloseConnection();
            return zaposlenici;
        }

        private static Zaposlenik CreateObject(SqlDataReader reader)
        {
            int id_zaposlenika = int.Parse(reader["Id_zaposlenika"].ToString());
            string korisnickoIme = reader["KorisnickoIme"].ToString();
            string lozinka = reader["Lozinka"].ToString();
            int.TryParse(reader["GodineIskustva"].ToString(), out int godineIskustva);
            string radnoMjesto = reader["RadnoMjesto"].ToString();

            var zaposlenik = new KonkretniZaposlenik
            {
                Id_zaposlenika = id_zaposlenika,
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                GodineIskustva = godineIskustva,
                RadnoMjesto = radnoMjesto
            };

            return zaposlenik;
        }
    }
}
