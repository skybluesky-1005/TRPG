using System;
using System.Text;
using System.Reflection;
using static TextGame.Data;

namespace TextGame
{
    [System.Serializable]
    public class Game
    {
        static void Main()
        {
            int winWidth = 80;
            int winHeight = 40;

            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(winWidth, winHeight);
            if (!File.Exists("player.json"))
                File.WriteAllText("player.json", "{}");
            if (!File.Exists("item.json"))
                File.WriteAllText("item.json", "{}");

            PlayerInfo playerInfo = LoadPlayerData();
            LoadItemData();

            while (playerInfo.name == null && playerInfo.playerClass == 0)
            {
                Console.WriteLine("게임을 처음 실행합니다. 이름과 직업을 입력하세요.");
                playerInfo.name = Console.ReadLine();
                Console.WriteLine("1.전사\n2.마법사\n3.도적\n4.사냥꾼\n5.사제\n6.성기사\n7.드루이드\n8.흑마법사\n9.주술사");
                playerInfo.playerClass = (PlayerClass)InputControl.CheckValidInput(1, 10);
                if ((int)playerInfo.playerClass > 1 && (int)playerInfo.playerClass < 10)
                {
                    Console.WriteLine("미구현된 직업입니다");
                    Thread.Sleep(1000);
                    Console.Clear();
                    playerInfo.name = null;
                    playerInfo.playerClass = 0;
                    continue;
                }

                Console.WriteLine($"이름 : {playerInfo.name}\n직업 : {playerInfo.playerClass}\n이대로 진행합니까?\n1.예 2. 아니오");
                if (InputControl.CheckValidInput(1, 2) == 1)
                {
                    Console.WriteLine("설정 완료");
                    Console.WriteLine($"이름 : {playerInfo.name}\n직업 : {playerInfo.playerClass}");
                    PlayerInfo stat = new PlayerInfo(playerInfo.name, (int)playerInfo.playerClass);
                    
                    playerInfo.atk = stat.atk;
                    playerInfo.def = stat.def;
                    playerInfo.hp = stat.hp;
                    playerInfo.gold = stat.gold;
                    playerInfo.level = stat.level;
                    playerInfo.exp = stat.exp;

                    SavePlayerData(playerInfo);
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("취소하셨습니다.");
                    playerInfo.name = null;
                    playerInfo.playerClass = 0;
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            SceneManager.LoadTitle();
            LoadItemData();
            LoadPlayerData();
        }
    }
}
