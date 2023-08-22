using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    class SceneManager
    {
        public InputControl inputControl = new InputControl();

        public void LoadTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("   ▄████████    ▄███████▄    ▄████████    ▄████████     ███        ▄████████ ");
            Console.WriteLine("  ███    ███   ███    ███   ███    ███   ███    ███ ▀█████████▄   ███    ███ ");
            Console.WriteLine("  ███    █▀    ███    ███   ███    ███   ███    ███    ▀███▀▀██   ███    ███ ");
            Console.WriteLine("  ███          ███    ███   ███    ███  ▄███▄▄▄▄██▀     ███   ▀   ███    ███ ");
            Console.WriteLine("▀███████████ ▀█████████▀  ▀███████████ ▀▀███▀▀▀▀▀       ███     ▀███████████ ");
            Console.WriteLine("         ███   ███          ███    ███ ▀███████████     ███       ███    ███ ");
            Console.WriteLine("   ▄█    ███   ███          ███    ███   ███    ███     ███       ███    ███ ");
            Console.WriteLine(" ▄████████▀   ▄████▀        ███    █▀    ███    ███    ▄████▀     ███    █▀  ");
            Console.WriteLine("                                         ███    ███                          ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("      ███               ▄████████           ▄███████▄           ▄██████▄     ");
            Console.WriteLine("  ▀█████████▄          ███    ███          ███    ███          ███    ███    ");
            Console.WriteLine("     ▀███▀▀██          ███    ███          ███    ███          ███    █▀     ");
            Console.WriteLine("      ███   ▀         ▄███▄▄▄▄██▀          ███    ███         ▄███           ");
            Console.WriteLine("      ███            ▀▀███▀▀▀▀▀          ▀█████████▀         ▀▀███ ████▄     ");
            Console.WriteLine("      ███            ▀███████████          ███                 ███    ███    ");
            Console.WriteLine("      ███              ███    ███          ███                 ███    ███    ");
            Console.WriteLine("     ▄████▀            ███    ███         ▄████▀               ████████▀     ");
            Console.WriteLine("                       ███    ███                                            ");

            Console.SetCursorPosition(15, 20);
            Console.WriteLine("1.상태 보기");
            Console.SetCursorPosition(50, 20);
            Console.WriteLine("2.인벤토리");

            switch (InputControl.CheckValidInput(1, 2))
            {
                case 1:
                    Console.Clear();
                    LoadStatus();
                    break;
                case 2:
                    Console.Clear();
                    LoadInventory();
                    break;
            }
        }

        public void LoadStatus()
        {
            Data.PlayerInfo playerInfo = Data.LoadData();

            Console.WriteLine("███████╗████████╗ █████╗ ████████╗██╗   ██╗███████╗\r\n" +
                              "██╔════╝╚══██╔══╝██╔══██╗╚══██╔══╝██║   ██║██╔════╝\r\n" +
                              "███████╗   ██║   ███████║   ██║   ██║   ██║███████╗\r\n" +
                              "╚════██║   ██║   ██╔══██║   ██║   ██║   ██║╚════██║\r\n" +
                              "███████║   ██║   ██║  ██║   ██║   ╚██████╔╝███████║\r\n" +
                              "╚══════╝   ╚═╝   ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝\r\n" +
                              "                                                   ");

            Console.WriteLine("┌─────────────────────────────────────────────────┐\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                             $"│                                                 │\r\n" +
                              "└─────────────────────────────────────────────────┘");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine($"이름: {playerInfo.name}");
            Console.SetCursorPosition(28, 9);
            Console.WriteLine($"직업: {playerInfo.playerClass}");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine($"레벨: {playerInfo.level}\n" +
                              $"│ 경험치: {playerInfo.exp}\n" +
                              $"│ 골드: {playerInfo.gold}\n" +
                              $"│ 물리공격: {playerInfo.pAtk}\n" +
                              $"│ 마법공격: {playerInfo.mAtk}\n" +
                              $"│ 물리방어: {playerInfo.pDef}\n" +
                              $"│ 마법방어: {playerInfo.mDef}\n" +
                              $"│ 민첩: {playerInfo.dex}\n" +
                              $"│ 체력: {playerInfo.hp}\n" +
                              $"│ 마나: {playerInfo.mp}\n");

            Console.ReadLine();
        }

        public void LoadInventory()
        {
            Console.WriteLine("██╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗████████╗ ██████╗ ██████╗ ██╗   ██╗\r\n" +
                              "██║████╗  ██║██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝\r\n" +
                              "██║██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║   ██║   ██║   ██║██████╔╝ ╚████╔╝ \r\n" +
                              "██║██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   ██║   ██║██╔══██╗  ╚██╔╝  \r\n" +
                              "██║██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║   ██║   ╚██████╔╝██║  ██║   ██║   \r\n" +
                              "╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \r\n" +
                              "                                                                           ");
        }
    }
}
