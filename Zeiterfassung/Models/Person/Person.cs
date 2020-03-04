using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zeiterfassung.Models.Arbeitszeit;

namespace Zeiterfassung.Models.Person
{
    public class Person
    {
        public string Name { get; }
        public string Vorname { get; }
        public Position Position { get; }
        public DateTime Geburtsdatum { get; }
        public string Email { get; }
        public string PasswordHash { get; }
        public double Gehalt { get; }

        public override string ToString()
        {
            return $"{Name} {Vorname}";
        }

        public ReadOnlyCollection<Arbeitszeit.Arbeitszeit> Arbeitszeiten { get => _arbeitszeiten.AsReadOnly(); }

        private List<Arbeitszeit.Arbeitszeit> _arbeitszeiten;

        public Person(string name, string vorname, Position position, DateTime geburtsdatum, string email, string passwordHash, double gehalt)
        {
            Name = name;
            Vorname = vorname;
            Position = position;
            Geburtsdatum = geburtsdatum.Date; //Grabs only the Date, resets time to 00:00:00
            Email = email;
            PasswordHash = passwordHash;
            Gehalt = gehalt;
            _arbeitszeiten = new List<Arbeitszeit.Arbeitszeit>();
        }

        public void AddArbeitszeit(DateTime datum, TimeSpan zeitspanne, string beschreibung)
        {
            if (!_arbeitszeiten.Any(arbeitszeit => arbeitszeit.Datum == datum.Date && arbeitszeit.Zeitspanne == zeitspanne))
                _arbeitszeiten.Add(new Arbeitszeit.Arbeitszeit(datum, zeitspanne, beschreibung));
        }

        public void RemoveArbeitszeit(DateTime datum) => _arbeitszeiten.RemoveAll(arbeitszeit => arbeitszeit.Datum == datum.Date);

        public void RemoveArbeitszeit(DateTime datum, TimeSpan zeitspanne) => _arbeitszeiten.RemoveAll(arbeitszeit => arbeitszeit.Datum == datum.Date && arbeitszeit.Zeitspanne == zeitspanne);

        public void RemoveArbeitszeiten() => _arbeitszeiten.Clear();
    }
}