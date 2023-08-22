using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    class InputControl
    {
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.Write("잘못된 입력입니다. 다시 입력하세요.");
                Thread.Sleep(1000);

                Console.CursorLeft = 0;
                Console.Write(new string(' ', Console.WindowWidth));
                Console.CursorLeft = 0;
                Console.CursorTop--;
                Console.Write(new string(' ', Console.WindowWidth));
                Console.CursorLeft = 0;
            }
        }
    }
}
