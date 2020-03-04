using System.IO;
using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataWriter.Implementation
{
    public class FileDataWriter : IDataWriter<string>
    {
        public void Write(string key, string obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenRead(key)))
                streamWriter.Write(obj);
        }

        public void WriteAll(string key, string[] obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenRead(key)))
                foreach (string line in obj)
                    streamWriter.Write(line);
        }

        public async Task WriteAsync(string key, string obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenRead(key)))
                await streamWriter.WriteAsync(obj);
        }

        public async Task WriteAllAsync(string key, string[] obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenRead(key)))
                foreach (string line in obj)
                    await streamWriter.WriteAsync(line);
        }
    }
}