using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataProvider
{
    public interface IDataProvider<T>
    {
        T Provide(string key, string[] options = null);

        Task<T> ProvideAsync(string key, string[] options = null);
    }
}