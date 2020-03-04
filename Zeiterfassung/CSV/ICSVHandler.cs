﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.CSV
{
    public interface ICSVHandler<T>
    {
        T Parse(string line);

        List<T> ParseAll(string[] lines);

        string Revert(T obj);

        string[] RevertAll(List<T> objs);
    }
}