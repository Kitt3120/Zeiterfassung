using System;

namespace Zeiterfassung.Models.Arbeitszeit
{
    public class Arbeitszeit
    {
        public DateTime Datum { get; }
        public TimeSpan Zeitspanne { get; set; }
        public string Beschreibung { get; }

        public Arbeitszeit(DateTime datum, TimeSpan zeitspanne, string beschreibung)
        {
            Datum = datum;
            Zeitspanne = zeitspanne;
            Beschreibung = beschreibung;
        }
    }
}