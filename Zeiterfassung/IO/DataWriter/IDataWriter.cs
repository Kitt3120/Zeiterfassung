using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataWriter
{
    public interface IDataWriter<T>
    {
        void Write(string key, T obj, string[] options = null);

        void WriteAll(string key, T[] obj, string[] options = null);

        Task WriteAsync(string key, T obj, string[] options = null);

        Task WriteAllAsync(string key, T[] obj, string[] options = null);
    }
}