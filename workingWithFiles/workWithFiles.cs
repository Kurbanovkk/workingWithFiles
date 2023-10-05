using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workingWithFiles
{
    internal class workWithFiles
    {
        public async Task AppendTextAsync(string fileName, string text)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    await writer.WriteLineAsync(" - Асинхронное дополнение: " + text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при асинхронной записи в файл {fileName}: {ex.Message}");
            }
        }

        public void ReadAndPrintFiles(string directoryPath)
        {
            Console.WriteLine($"Содержимое директории: {directoryPath}");
            Console.WriteLine();
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string filePath in files)
            {
                try
                {
                    string fileName = Path.GetFileName(filePath);
                    string fileContent = File.ReadAllText(filePath, Encoding.UTF8);
                    Console.WriteLine($"{fileName}: {fileContent}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
                }
            }
        }
    }
}
