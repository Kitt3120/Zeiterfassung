using System;
using System.Text;
using Zeiterfassung.Models.Arbeitszeit;
using Zeiterfassung.Models.Person;

namespace Zeiterfassung.CSV.Person
{
    internal class CSVHandlerPerson : ICSVHandler<Models.Person.Person>
    {
        public Models.Person.Person Parse(string line)
        {
            if (line.EndsWith(";"))
                line = line.Substring(0, line.Length - 1);
            string[] split = line.Split(';');

            string name = split[0];
            string vorname = split[1];

            PType type;
            if (!Enum.TryParse(split[2], out type))
                throw new ArgumentException("Line did not contain a valid PType at position 3 [2]");

            DateTime geburtsdatum = Convert.ToDateTime(split[3]);
            string email = split[4];
            string passwordHash = split[5];

            double gehalt;
            if (!double.TryParse(split[6], out gehalt))
                throw new ArgumentException("Line did not contain a valid value for \"Lohn\" at position 7 [6]");

            Models.Person.Person person = new Models.Person.Person(name, vorname, type, geburtsdatum, email, passwordHash, gehalt);
            for (int i = 7; i < split.Length; i += 3)
            {
                DateTime datum = Convert.ToDateTime(split[i]);

                long ticks;
                if (!long.TryParse(split[i + 1], out ticks))
                    throw new ArgumentException($"Line did not contain a valid value for \"Ticks\" at position {i + 2} [{i + 1}]");

                TimeSpan zeitspanne = new TimeSpan(ticks);
                string beschreibung = split[i + 2];

                person.AddArbeitszeit(datum, zeitspanne, beschreibung);
            }

            return person;
        }

        public string Revert(Models.Person.Person obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{obj.Name};{obj.Vorname};{obj.Type.ToString()};{obj.Geburtsdatum.ToString()};{obj.Email};{obj.PasswordHash};{obj.Gehalt.ToString()}");

            foreach (Arbeitszeit arbeitszeit in obj.Arbeitszeiten)
                sb.Append($";{arbeitszeit.Datum.ToString()};{arbeitszeit.Zeitspanne.Ticks};{arbeitszeit.Beschreibung}");

            return sb.ToString();
        }
    }
}