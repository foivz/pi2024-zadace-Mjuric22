using System;

namespace SZUUP.Models
{
    public class Kategorija
    {
        public int Id_Kategorija { get; set; }
        public string NazivKategorije { get; set; }
        public string Opis { get; set; }

        public override string ToString()
        {
            return NazivKategorije;
        }
    }
}
