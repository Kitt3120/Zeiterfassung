using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.Models.Arbeitszeit
{
    public class Arbeitszeit
    {
        public DateTime Datum { get; }
        public TimeSpan Zeitspanne { get; set; }
        public string Beschreibung { get; }
    }
}