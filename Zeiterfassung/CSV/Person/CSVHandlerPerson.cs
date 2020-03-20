using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeiterfassung.Models.Arbeitszeit;
using Zeiterfassung.Models.Person;

namespace Zeiterfassung.CSV.Person
{
    //Dokumentation siehe ICSVHandler
    public class CSVHandlerPerson : ICSVHandler<Models.Person.Person>
    {
        public Models.Person.Person Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            if (line.EndsWith(";"))
                line = line.Substring(0, line.Length - 1);
            string[] split = line.Split(';');

            string name = split[0];
            string vorname = split[1];

            Position position;
            if (!Enum.TryParse(split[2], out position))
                throw new ArgumentException("Line did not contain a valid PType at position 3 [2]");

            DateTime geburtsdatum = Convert.ToDateTime(split[3]);
            string email = split[4];
            string passwordHash = split[5];

            double gehalt;
            if (!double.TryParse(split[6], out gehalt))
                throw new ArgumentException("Line did not contain a valid value for \"Lohn\" at position 7 [6]");

            Models.Person.Person person = new Models.Person.Person(name, vorname, position, geburtsdatum, email, passwordHash, gehalt);
            for (int i = 7; i < split.Length; i += 4)
            {
                DateTime datum = Convert.ToDateTime(split[i]);
                DateTime anfang = Convert.ToDateTime(split[i + 1]);
                DateTime ende = Convert.ToDateTime(split[i + 2]);
                string beschreibung = split[i + 3];

                person.AddArbeitszeit(datum, anfang, ende, beschreibung);
            }

            return person;
        }

        public Models.Person.Person[] ParseAll(string[] lines) => lines.Select(line => Parse(line)).ToArray();

        public string Revert(Models.Person.Person obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{obj.Name};{obj.Vorname};{obj.Position.ToString()};{obj.Geburtsdatum.ToString("dd.MM.yyyy")};{obj.Email};{obj.PasswordHash};{obj.Gehalt.ToString()}");

            foreach (Arbeitszeit arbeitszeit in obj.Arbeitszeiten)
                sb.Append($";{arbeitszeit.Datum.ToString("dd.MM.yyyy")};{arbeitszeit.Anfang.ToString()};{arbeitszeit.Ende.ToString()};{arbeitszeit.Beschreibung}");

            return sb.ToString();
        }

        public string[] RevertAll(Models.Person.Person[] objs) => objs.Select(obj => Revert(obj)).ToArray();
    }
}