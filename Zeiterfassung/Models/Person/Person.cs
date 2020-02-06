using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.Models.Person
{
    public class Person
    {
        public string Name { get; }
        public string Vorname { get; }
        public PType Type { get; }
        public DateTime DateTime { get; }
        public string EMail { get; }
        public string PasswordHash { get; }
        public double Gehalt { get; }

        private List<Arbeitszeit.Arbeitszeit> _arbeitszeiten;

        public Person(string name, string vorname, PType type, DateTime dateTime, string eMail, string passwordHash, double gehalt)
        {
            Name = name;
            Vorname = vorname;
            Type = type;
            DateTime = dateTime;
            EMail = eMail;
            PasswordHash = passwordHash;
            Gehalt = gehalt;
        }
    }
}