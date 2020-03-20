using Zeiterfassung.CSV.Person;

namespace Zeiterfassung.CSV
{
    /// <summary>
    /// Klasse, welche statische Instanzen von CSV-Handlern enthält, um sie programmweit zu benutzen
    /// </summary>
    public static class CSVHandlers
    {
        public static ICSVHandler<Models.Person.Person> CSVHandlerPerson { get; } = new CSVHandlerPerson();
    }
}