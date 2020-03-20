using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung.IO.DataWriter.Implementation;

namespace Zeiterfassung.IO.DataWriter
{
    /// <summary>
    /// Klasse, welche statische Instanzen von IDataWritern enthält, um sie programmweit zu benutzen
    /// Writer-Wrapper für die IOHandler-Klasse
    /// </summary>
    public static class DataWriters
    {
        public static IDataWriter<string> FileDataWriter { get; } = IOHandlers.FileDataWriter;
    }
}