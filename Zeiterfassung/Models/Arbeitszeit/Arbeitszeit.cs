using System;

namespace Zeiterfassung.Models.Arbeitszeit
{
    public class Arbeitszeit
    {
        public DateTime Datum { get; }
        public TimeSpan Zeitspanne { get; set; }
        public string Beschreibung { get; }
    }
}