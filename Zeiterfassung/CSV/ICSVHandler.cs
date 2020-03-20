using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.CSV
{
    /// <summary>
    /// Konvertiert CSV-Daten zwischen strings und dem generischen Typen T
    /// </summary>
    /// <typeparam name="T">Ausgangstyp für Konvertierung</typeparam>
    public interface ICSVHandler<T>
    {
        /// <summary>
        /// Konvertier eine CSV-formatierte Zeile in ein Objekt
        /// </summary>
        /// <param name="line">Zeile, welche konvertiert werden sollen</param>
        /// <returns>Ausgelesenes Objekt vom generischen Typen T</returns>
        T Parse(string line);

        /// <summary>
        /// Konvertiert CSV-formatierte Zeilen in Objekte
        /// </summary>
        /// <param name="lines">Array mit Zeilen, welche konvertiert werden sollen</param>
        /// <returns>Array an ausgelesenen Objekten vom generischen Typen T</returns>
        T[] ParseAll(string[] lines);

        /// <summary>
        /// Konvertiert ein Objekt in CSV-formatierten Text
        /// </summary>
        /// <param name="obj">Das zu konvertierende Objekt vom generischen Typen T</param>
        /// <returns>Konvertierte Textzeile</returns>
        string Revert(T obj);

        /// <summary>
        /// Konvertiert mehrere Objekte in CSV-formatierten Text
        /// </summary>
        /// <param name="objs">Die zu konvertierenden Objekte vom generischen Typen T</param>
        /// <returns>Konvertierte Textzeilen</returns>
        string[] RevertAll(T[] objs);
    }
}