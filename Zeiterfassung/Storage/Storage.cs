using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung.Storage
{
    public class Storage
    { }

    public class Storage<T> : Storage
    {
        private List<T> _list;

        public T[] Values => _list.ToArray();

        public T this[int key]
        {
            get { return _list[key]; }
            set { _list[key] = value; }
        }

        public bool Contains(T value) => _list.Contains(value);

        public void Add(T value) => _list.Add(value);

        public void Remove(T value) => _list.Remove(value);

        public void RemoveAt(int index) => _list.RemoveAt(index);

        public Type Type { get { return GetType().GenericTypeArguments[0]; } }

        public Storage()
        {
            _list = new List<T>();
        }
    }
}