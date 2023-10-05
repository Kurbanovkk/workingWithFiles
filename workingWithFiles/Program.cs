using System.Text;

namespace workingWithFiles
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var wwf = new workWithFiles();
            Directory.CreateDirectory("c:\\Otus\\TestDir1");
            Directory.CreateDirectory("c:\\Otus\\TestDir2");
            for (int i = 1; i <= 10; i++)
            {
                string fileName1 = $"c:\\Otus\\TestDir1\\File{i}.txt";
                string fileName2 = $"c:\\Otus\\TestDir2\\File{i}.txt";
                File.WriteAllText(fileName1, $"File {i} - Синхронная запись", Encoding.UTF8);
                File.WriteAllText(fileName2, $"File {i} - Синхронная запись", Encoding.UTF8);
                await wwf.AppendTextAsync(fileName1, DateTime.Now.ToString());
                await wwf.AppendTextAsync(fileName2, DateTime.Now.ToString());
            }
            wwf.ReadAndPrintFiles("c:\\Otus\\TestDir1");
            wwf.ReadAndPrintFiles("c:\\Otus\\TestDir2");
        }
    }
}