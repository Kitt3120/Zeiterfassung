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

        public static Storage<T> CreateStorage<T>(string key)
        {
            Storage<T> storage = new Storage<T>();
            _storages[key] = storage;
            return storage;
        }

        public static bool DropStorage(string key) => _storages.Remove(key);

        public static Storage<T> Get<T>(string key = null)
        {
            Storage[] possibleStorages = _storages.Select(pair => pair.Value).Where(storage => storage.GetType().GenericTypeArguments[0] == typeof(T)).ToArray();
            if (possibleStorages.Length == 1)
                return (Storage<T>)possibleStorages[0];
            else if (possibleStorages.Length == 0)
                throw new ArgumentException($"No storage for type {typeof(T).ToString()} found.");
            else
            {
                if (key == null)
                    throw new ArgumentException($"No storage for type {typeof(T).ToString()} found.");

                possibleStorages = _storages.Where(pair => pair.Key == key).Select(pair => pair.Value).ToArray();
                if (possibleStorages.Length == 1)
                    return (Storage<T>)possibleStorages[0];
                else if (possibleStorages.Length == 0)
                    throw new ArgumentException($"No storage for type {typeof(T).ToString()} and key {key} found.");
                else
                    throw new ArgumentException($"Multiple storages for type {typeof(T).ToString()} and key {key} found. This should never happen. Houston, we have a problem!");
            }
        }
    }
}