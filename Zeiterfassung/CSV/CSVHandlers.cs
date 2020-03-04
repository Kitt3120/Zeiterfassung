using Zeiterfassung.CSV.Person;

namespace Zeiterfassung.CSV
{
    public static class CSVHandlers
    {
        public static ICSVHandler<Models.Person.Person> CSVHandlerPerson { get; } = new CSVHandlerPerson();
    }
}