using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.Storage
{
    public static class StorageContainer
    {
        private static Dictionary<string, Storage> _storages = new Dictionary<string, Storage>();

        /// <summary>
        /// Erstellt einen neuen Storage und speichert diesen im StorageContainer.
        /// </summary>
        /// <typeparam name="T">Der im Storage gehaltene Typ</typeparam>
        /// <param name="key">Schlüssel, unter welchem der Storage gespeichert wird</param>
        /// <returns>Erstellten Storage</returns>
        public static Storage<T> CreateStorage<T>(string key)
        {
            Storage<T> storage = new Storage<T>();
            _storages[key] = storage;
            return storage;
        }

        /// <summary>
        /// Entfernt einen Storage aus dem StorageContainer
        /// </summary>
        /// <typeparam name="T">Der Typ des zu entfernenden Storage</typeparam>
        /// <param name="key">Optional: Der Schlüssel des zu entfernenden Storage</param>
        /// <returns>Ob ein Storage erfolgreich entfernt wurde</returns>
        public static bool DropStorage<T>(string key = null)
        {
            if (key != null)
                return _storages.Remove(key);
            else
            {
                KeyValuePair<string, Storage>[] possiblePairs = _storages.Where(pair => pair.Value.GetType().GenericTypeArguments[0] == typeof(T)).ToArray();
                if (possiblePairs.Length == 0)
                    return false;
                else if (possiblePairs.Length == 1)
                    return _storages.Remove(possiblePairs[0].Key);
                else
                {
                    if (key == null)
                        throw new ArgumentException($"Multiple Storages for type {typeof(T).ToString()} found but no key to identify given.");
                    return false;
                }
            }
        }

        /// <summary>
        /// Ruft einen Storage aus dem StorageContainer ab
        /// </summary>
        /// <typeparam name="T">Der Typ nachdem gefiltert werden soll</typeparam>
        /// <param name="key">Optional: Der Schlüssel, um einen Storage eindeutig zu identifizieren</param>
        /// <returns>Den herausgefilterten Storage</returns>
        public static Storage<T> Get<T>(string key = null)
        {
            KeyValuePair<string, Storage>[] possiblePairs = _storages.Where(pair => pair.Value.GetType().GenericTypeArguments[0] == typeof(T)).ToArray();
            if (possiblePairs.Length == 1)
                return (Storage<T>)possiblePairs[0].Value;
            else if (possiblePairs.Length == 0)
                throw new ArgumentException($"No storage for type {typeof(T).ToString()} found.");
            else
            {
                if (key == null)
                    throw new ArgumentException($"Multiple Storages for type {typeof(T).ToString()} found but no key to identify given.");

                possiblePairs = possiblePairs.Where(pair => pair.Key == key).ToArray();
                if (possiblePairs.Length == 1)
                    return (Storage<T>)possiblePairs[0].Value;
                else if (possiblePairs.Length == 0)
                    throw new ArgumentException($"No storage for type {typeof(T).ToString()} and key {key} found.");
                else
                    throw new ArgumentException($"Multiple storages for type {typeof(T).ToString()} and key {key} found. This should never happen. Houston, we have a problem!");
            }
        }
    }
}