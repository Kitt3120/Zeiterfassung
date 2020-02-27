using System;
using System.Collections.Generic;

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

        public DateTime Datum { get; }
        public TimeSpan Zeitspanne { get; set; }
        public string Beschreibung { get; }
    }
}