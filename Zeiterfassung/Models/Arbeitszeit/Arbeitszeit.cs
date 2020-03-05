using System;

namespace Zeiterfassung.Models.Arbeitszeit
{
    public class Arbeitszeit
    {
        public DateTime Datum { get; }
        public DateTime Anfang { get; }
        public DateTime Ende { get; }
        public TimeSpan Zeitspanne { get => new TimeSpan(Ende.Ticks - Anfang.Ticks); }
        public string Beschreibung { get; }

        public Arbeitszeit(DateTime datum, DateTime anfang, DateTime ende, string beschreibung)
        {
            Datum = datum;
            Anfang = anfang;
            Ende = ende;
            Beschreibung = beschreibung;
        }
    }
}