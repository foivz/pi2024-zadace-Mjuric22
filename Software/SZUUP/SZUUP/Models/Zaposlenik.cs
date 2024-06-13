using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZUUP.Models
{
    public abstract class Zaposlenik
    {
        public int Id_zaposlenika { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int GodineIskustva { get; set; }
        public string RadnoMjesto { get; set; }
        public override string ToString()
        {
            return KorisnickoIme + " - " + RadnoMjesto;
        }
    }
}
