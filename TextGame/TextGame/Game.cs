using System;
using System.Text;
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

            SceneManager sceneManager = new SceneManager();
            PlayerInfo playerInfo = LoadData();

            if (playerInfo.name == null && playerInfo.playerClass == 0)
            {
                Console.WriteLine("게임을 처음 실행합니다. 이름과 직업을 입력하세요.");
                playerInfo.name = Console.ReadLine();
                Console.WriteLine("1.전사\n2.마법사\n3.도적\n4.사냥꾼\n5.사제\n6.성기사\n7.드루이드\n8.흑마법사\n9.주술사");
                playerInfo.playerClass = (PlayerClass)InputControl.CheckValidInput(1, 10);

                Console.WriteLine($"이름 : {playerInfo.name}\n직업 : {playerInfo.playerClass}\n이대로 진행합니까?\n1.예 2. 아니오");
                if (InputControl.CheckValidInput(1, 2) == 1)
                {
                    Console.WriteLine("설정 완료");
                    Console.WriteLine($"이름 : {playerInfo.name}\n직업 : {playerInfo.playerClass}");

                    SaveData(playerInfo);
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("취소하셨습니다.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            sceneManager.LoadTitle();
        }
    }
}
