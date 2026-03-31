using System;
using System.Collections.Generic;

namespace TextCorrector {
  class Program {
    static void Main() {

      string directoryPath = "./ErrorFiles";
      
      Dictionary<string, string> errorDictionary = new Dictionary<string, string>()
      {
        { "приет", "привет" },
        { "пирвет", "привет" },
        { "прорама", "программа" },
        { "кталог", "каталог" },
        { "ошика", "ошибка" }
      };

    }
  }
}
