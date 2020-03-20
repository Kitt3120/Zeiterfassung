using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung.IO.DataProvider.Implementation;

namespace Zeiterfassung.IO.DataProvider
{
    /// <summary>
    /// Klasse, welche statische Instanzen von IDataProvidern enthält, um sie programmweit zu benutzen
    /// Provider-Wrapper für die IOHandler-Klasse
    /// </summary>
    public static class DataProviders
    {
        public static IDataProvider<string[]> FileDataProvider { get; } = IOHandlers.FileDataProvider;
    }
}