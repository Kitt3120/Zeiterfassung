using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung.IO.DataProvider.Implementation;

namespace Zeiterfassung.IO.DataProvider
{
    public static class DataProviders
    {
        public static IDataProvider<string[]> FileDataProvider { get; } = new FileDataProvider();
    }
}