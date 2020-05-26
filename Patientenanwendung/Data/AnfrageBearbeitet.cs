using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patientenanwendung.Data
{
    public class AnfrageBearbeitet
    {
        public Anfrage Basierende_Anfrage { get; set; }
        public Nurse Responsible_Nurse { get; set; }
        public DateTime DateTime_Bearbeitet { get; set; }
    }
}
