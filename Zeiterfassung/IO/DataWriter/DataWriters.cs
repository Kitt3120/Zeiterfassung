using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung.IO.DataWriter.Implementation;

namespace Zeiterfassung.IO.DataWriter
{
    public static class DataWriters
    {
        public static IDataWriter<string> FileDataWriter { get; } = new FileDataWriter();
    }
}