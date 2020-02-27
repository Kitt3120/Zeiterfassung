using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.CSV
{
    internal interface ICSVHandler<T>
    {
        T Parse(string line);

        string Revert(T obj);
    }
}