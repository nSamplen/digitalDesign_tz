using System;
using System.IO;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input filePath!");
            string textFromFile;
            
            // чтение из файла
            using (FileStream fstream = File.OpenRead(args[0]))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                
                

 
            }

            string[] words = textFromFile.Split(new char[] {' ','.', '?', '!', ';', ':', ',','\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            var result =words.GroupBy(x => x)
                              .Where(x => x.Count() >= 1)
                              .Select(x => new {Word = x.Key, Frequency = x.Count() });
 
           
            // запись в файл
            using (FileStream fstream = new FileStream($"result.txt", FileMode.OpenOrCreate))
            {
               
                foreach (var item in result) {
                   
                    string text = item.Word+"\t\t\t"+item.Frequency+"\n";
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fstream.Write(array, 0, array.Length);
                }
                
                Console.WriteLine("Результат записан в файл");
            }

           
        }
    }
}
