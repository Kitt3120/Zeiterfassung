using Zeiterfassung.IO.DataProvider;
using Zeiterfassung.IO.DataProvider.Implementation;
using Zeiterfassung.IO.DataWriter;
using Zeiterfassung.IO.DataWriter.Implementation;

namespace Zeiterfassung.IO
{
    /// <summary>
    /// Klasse, welche statische Instanzen von IDataWritern und IDataProvidern enthält, um sie programmweit zu benutzen
    /// </summary>
    public static class IOHandlers
    {
        public static IDataProvider<string[]> FileDataProvider { get; } = new FileDataProvider();
        public static IDataWriter<string> FileDataWriter { get; } = new FileDataWriter();
    }
}