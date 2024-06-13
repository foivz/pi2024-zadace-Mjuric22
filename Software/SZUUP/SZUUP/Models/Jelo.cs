using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZUUP.Models
{
    public class Jelo
    {
        public int Id_jelo { get; set; }
        public int Id_Kategorija { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public string Detalji { get; set; }

        // Ovdje možete dodati dodatne atribute i metode specifične za Jelo ako je potrebno
    }
}
