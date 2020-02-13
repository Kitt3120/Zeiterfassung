using Zeiterfassung.IO.DataProvider.Implementation;
using Zeiterfassung.IO.DataWriter.Implementation;

namespace Zeiterfassung.IO
{
    public static class IOHandlers
    {
        public static FileDataProvider FileDataProvider { get; } = new FileDataProvider();
        public static FileDataWriter FileDataWriter { get; } = new FileDataWriter();
    }
}