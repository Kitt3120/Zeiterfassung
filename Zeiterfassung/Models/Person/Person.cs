using System;
using System.Collections.Generic;
using System.Linq;
using Zeiterfassung.Models.Arbeitszeit;

namespace Zeiterfassung.Models.Person
{
    public class Person
    {
        public string Name { get; }
        public string Vorname { get; }
        public PType Type { get; }
        public DateTime Geburtsdatum { get; }
        public string EMail { get; }
        public string PasswordHash { get; }
        public double Gehalt { get; }

        private List<Arbeitszeit.Arbeitszeit> _arbeitszeiten;

        public Person(string name, string vorname, PType type, DateTime dateTime, string eMail, string passwordHash, double gehalt)
        {
            Name = name;
            Vorname = vorname;
            Type = type;
            Geburtsdatum = dateTime.Date; //Grabs only the Date, resets time to 00:00:00
            EMail = eMail;
            PasswordHash = passwordHash;
            Gehalt = gehalt;
        }

        public void AddArbeitszeit(DateTime datum, TimeSpan zeitspanne, string beschreibung)
        {
            if (!_arbeitszeiten.Any(arbeitszeit => arbeitszeit.Datum == datum && arbeitszeit.Zeitspanne == zeitspanne))
                _arbeitszeiten.Add(new Arbeitszeit.Arbeitszeit(datum, zeitspanne, beschreibung));
        }
    }
}