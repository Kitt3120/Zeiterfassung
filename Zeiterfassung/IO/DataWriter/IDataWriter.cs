using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataWriter
{
    public interface IDataWriter<T>
    {
        /// <summary>
        /// Serialisiert ein Objekt
        /// </summary>
        /// <param name="key">Der zu verwendende Schlüssel (dies kann ein Dateipfad oder auch ein Pfad in einer Datenbank sein)</param>
        /// <param name="obj">Das zu serialisierende Objekt vom generischen Typen T</param>
        /// <param name="options">Optional: Weitere Optionen</param>
        void Write(string key, T obj, string[] options = null);

        /// <summary>
        /// Serialisiert mehrere Objekte
        /// </summary>
        /// <param name="key">Der zu verwendende Schlüssel (dies kann ein Dateipfad oder auch ein Pfad in einer Datenbank sein)</param>
        /// <param name="objs">Array der zu serialisierenden Objekte vom generischen Typen T</param>
        /// <param name="options">Optional: Weitere Optionen</param>
        void WriteAll(string key, T[] objs, string[] options = null);

        /// <summary>
        /// Serialisiert ein Objekt asynchron
        /// </summary>
        /// <param name="key">Der zu verwendende Schlüssel (dies kann ein Dateipfad oder auch ein Pfad in einer Datenbank sein)</param>
        /// <param name="obj">Das zu serialisierende Objekt vom generischen Typen T</param>
        /// <param name="options">Optional: Weitere Optionen</param>
        Task WriteAsync(string key, T obj, string[] options = null);

        /// <summary>
        /// Serialisiert mehrere Objekte asynchron
        /// </summary>
        /// <param name="key">Der zu verwendende Schlüssel (dies kann ein Dateipfad oder auch ein Pfad in einer Datenbank sein)</param>
        /// <param name="objs">Array der zu serialisierenden Objekte vom generischen Typen T</param>
        /// <param name="options">Optional: Weitere Optionen</param>
        Task WriteAllAsync(string key, T[] objs, string[] options = null);
    }
}