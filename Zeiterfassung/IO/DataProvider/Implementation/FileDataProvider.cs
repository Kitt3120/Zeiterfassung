using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataProvider.Implementation
{
    public class FileDataProvider : IDataProvider<string[]>
    {
        public string[] Provide(string key, string[] options = null)
        {
            string s = null;
            using (StreamReader streamReader = new StreamReader(File.OpenRead(key)))
                s = streamReader.ReadToEnd();

            return s.Split(Environment.NewLine.ToCharArray()).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        }

        public async Task<string[]> ProvideAsync(string key, string[] options = null)
        {
            string s = null;
            using (StreamReader streamReader = new StreamReader(File.OpenRead(key)))
                s = await streamReader.ReadToEndAsync();

            return s.Split(Environment.NewLine.ToCharArray());
        }
    }
}