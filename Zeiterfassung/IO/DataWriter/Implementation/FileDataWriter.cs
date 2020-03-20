using System.IO;
using System.Threading.Tasks;

namespace Zeiterfassung.IO.DataWriter.Implementation
{
    //Dokumentation siehe IDataWriter
    public class FileDataWriter : IDataWriter<string>
    {
        public void Write(string key, string obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(key)))
                streamWriter.Write(obj);
        }

        public void WriteAll(string key, string[] obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(key)))
                foreach (string line in obj)
                    streamWriter.WriteLine(line);
        }

        public async Task WriteAsync(string key, string obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(key)))
                await streamWriter.WriteAsync(obj);
        }

        public async Task WriteAllAsync(string key, string[] obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(key)))
                foreach (string line in obj)
                    await streamWriter.WriteLineAsync(line);
        }
    }
}