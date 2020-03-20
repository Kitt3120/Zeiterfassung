using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataProvider
{
    public interface IDataProvider<T>
    {
        /// <summary>
        /// Ließt ein serialisiertes Objekt aus
        /// </summary>
        /// <param name="key">Der zu verwendende Schlüssel (dies kann ein Dateipfad oder auch ein Pfad in einer Datenbank sein)</param>
        /// <param name="options">Optional: Weitere Optionen</param>
        /// <returns>Ausgelesenes Objekt vom generischen Typen T</returns>
        T Provide(string key, string[] options = null);

        /// <summary>
        /// Ließt ein serialisiertes Objekt asynchron aus
        /// </summary>
        /// <param name="key">Der zu verwendende Schlüssel (dies kann ein Dateipfad oder auch ein Pfad in einer Datenbank sein)</param>
        /// <param name="options">Optional: Weitere Optionen</param>
        /// <returns>Ausgelesenes Objekt vom generischen Typen T</returns>
        Task<T> ProvideAsync(string key, string[] options = null);
    }
}