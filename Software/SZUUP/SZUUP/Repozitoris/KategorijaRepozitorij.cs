using System;
using System.Collections.Generic;
using SZUUP.Models;

namespace SZUUP.Repozitoris
{
    public static class KategorijaRepozitorij
    {
        public static List<Kategorija> GetKategorije()
        {
            // Simulate fetching from a database
            return new List<Kategorija>
            {
                new Kategorija { Id_Kategorija = 1, NazivKategorije = "Predjela", Opis = "Razna predjela" },
                new Kategorija { Id_Kategorija = 2, NazivKategorije = "Glavna jela", Opis = "Razna glavna jela" },
                new Kategorija { Id_Kategorija = 3, NazivKategorije = "Deserti", Opis = "Razni deserti" }
            };
        }
    }
}
