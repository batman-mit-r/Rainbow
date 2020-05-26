using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patientenanwendung.Data
{
    public class Anfrage
    {
        public Bett Bett { get; set; }
        public DateTime DateTime { get; set; }
        public AnfrageArt AnfrageArt { get; set; }

        public int Schmerzlevel { get; set; }
        public String Zusatz { get; set; }

    }

    public enum AnfrageArt
    {
        Schmerzen,
        Medikamente,
        Hygiene,
        Nahrungsmittel,
        Sonstiges
    }
}
