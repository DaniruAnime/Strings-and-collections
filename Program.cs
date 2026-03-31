using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextCorrector
{
  class Program
  {
    static void Main()
    {
      string directoryPath = @"./ErrorFiles";
      
      Dictionary<string, string> errorDictionary = new Dictionary<string, string>()
      {
        { "приет", "привет" },
        { "пирвет", "привет" },
        { "прорама", "программа" },
        { "кталог", "каталог" },
        { "ошика", "ошибка" }
      };

      if (!Directory.Exists(directoryPath))
      {
        Console.WriteLine(@$"Директория {directoryPath} не найдена");
        return;
      }

      string[] files = Directory.GetFiles(directoryPath, "*.txt");
      string[] keys = errorDictionary.Keys.ToArray();

      for (int fileIndex = 0; fileIndex < files.Length; ++fileIndex)
      {
        string filePath = files[fileIndex];
        string content = File.ReadAllText(filePath);

        for (int wordIndex = 0; wordIndex < keys.Length; ++wordIndex)
        {
          string wrongWord = keys[wordIndex];
          string correctWord = errorDictionary[wrongWord];

          // используются границы слова "\b" чтобы заменить только конкретные слова
          string wordPattern = @$"\b{wrongWord}\b";
          content = Regex.Replace(content, wordPattern, correctWord, RegexOptions.IgnoreCase);
        }
    
        string phonePattern = @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})";
        string replacement = "+380 $1 $2 $3 $4";
        
        content = Regex.Replace(content, phonePattern, replacement);

        File.WriteAllText(filePath, content);
        Console.WriteLine($"Готовый файл: {Path.GetFileName(filePath)}");
      }

      Console.WriteLine("Нажмите чтобы продолжить...");
      Console.ReadKey();
    }
  }
}