using System;
using System.Collections.Generic;

namespace TextCorrector {
  class Program {
    static void Main() {

      Dictionary<string, string> errorWords = new Dictionary<string, string>()
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
