# TRPG 구현 개인과제 

필수 구현 기능 목록
1.게임 시작화면
2.상태보기
3.인벤토리

## 코드

### Game Class
```
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
```
게임 실행 직후 초기 설정들을 실행한다
콘솔창의 크기를 지정하고 아스키 아트의 깨짐을 방지하기 위해 엔코딩 코드를 추가한다
json파일이 경로에 없다면  새로 생성한다
```
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
```
플레이어 이름과 직업이 초기값이라면 새로운 이름과 직업을 사용자에게 입력받는다
전사 외의 직업을 입력한다면 미구현이라고 알려주며 다시 입력을 받는다
```
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
```
정상적으로 입력을 받았다면 그대로 진행할건지 한번 더 확인한다
예를 선택하면 이름과 직업을 출력하고 스탯값을 2차원 배열에 저장한 직업들 각각의 초기 스탯값으로 적용한다
그 후에 플레이어 정보를 저장한다
이후 게임 실행 시 플레이어 이름과  직업을 입력받는 과정은 생략

### Data Class
```
namespace TextGame
{
    public enum PlayerClass
    {
        Warrior = 1, Wizard, Thief, Hunter, Priest, Paladin, Druid, Warlock, Shaman
    }
    public class Data
    {
        //public static readonly PlayerInfo[] classStats = new PlayerInfo[]
        //{
        //    new PlayerInfo { pAtk = 15, mAtk = 5, pDef = 10, mDef = 5, dex = 8, hp = 150, mp = 20 },    // Warrior
        //    new PlayerInfo { pAtk = 5, mAtk = 20, pDef = 5, mDef = 10, dex = 6, hp = 100, mp = 100 },    // Wizard
        //    new PlayerInfo { pAtk = 10, mAtk = 10, pDef = 6, mDef = 6, dex = 12, hp = 120, mp = 30 },    // Thief
        //    new PlayerInfo { pAtk = 12, mAtk = 8, pDef = 8, mDef = 5, dex = 15, hp = 130, mp = 40 },    // Hunter
        //    new PlayerInfo { pAtk = 3, mAtk = 15, pDef = 3, mDef = 15, dex = 5, hp = 80, mp = 150 },    // Priest
        //    new PlayerInfo { pAtk = 12, mAtk = 10, pDef = 15, mDef = 12, dex = 7, hp = 140, mp = 30 },    // Paladin
        //    new PlayerInfo { pAtk = 8, mAtk = 8, pDef = 10, mDef = 10, dex = 10, hp = 130, mp = 60 },    // Druid
        //    new PlayerInfo { pAtk = 18, mAtk = 18, pDef = 5, mDef = 5, dex = 6, hp = 100, mp = 80 },    // Warlock
        //    new PlayerInfo { pAtk = 10, mAtk = 10, pDef = 10, mDef = 10, dex = 10, hp = 120, mp = 70 }    // Shaman
        //};
```
총 9개의 직업과 각 직업에 따라 적절한 스탯들을 추가하여 구현할 예정이었으나 작업 시간에 쫓겨 나중에 개인적으로 구현해보기로 하고 주석처리
```        

        public struct PlayerInfo
        {
            public int level;
            public int exp;
            public string name = null;
            public PlayerClass playerClass = 0;
            //public int pAtk;
            //public int mAtk;
            //public int pDef;
            //public int mDef;
            //public int dex;
            public int atk;
            public int def;
            public int hp;
            //public int mp;
            public int gold;

            public PlayerInfo(string newName, int choiceClass)
            {
                level = 1;
                exp = 0;
                name = newName;
                playerClass = (PlayerClass)choiceClass;

                //PlayerInfo classStat = classStats[choiceClass - 1];
                //pAtk = classStat.pAtk;
                //mAtk = classStat.mAtk;
                //pDef = classStat.pDef;
                //mDef = classStat.mDef;
                //dex = classStat.dex;
                atk = 10;
                def = 5;
                hp = 100;
                //mp = classStat.mp;
                gold = 1500;
            }
        }
```
스탯 변수들을 구조체로 만들고 생성자에서 매개변수로 전달받은 이름과 직업으로 변수들을 초기화한다
```
        public static void SavePlayerData(PlayerInfo playerInfo)
        {
            string saveJson = JsonConvert.SerializeObject(playerInfo, Formatting.Indented);
            File.WriteAllText("player.json", saveJson);
            Console.SetCursorPosition(2, ++Console.CursorTop);
            Console.WriteLine("저장완료");
        }

        public static void SaveItemData(List<Item> items)
        {
            string saveJson = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText("item.json", saveJson);
            Console.SetCursorPosition(2, ++Console.CursorTop);
            Console.WriteLine("저장완료");
        }

        public static PlayerInfo LoadPlayerData()
        {
           string loadJson = File.ReadAllText("player.json");
            PlayerInfo loadPlayerInfo = JsonConvert.DeserializeObject<PlayerInfo>(loadJson);
            return loadPlayerInfo;
        }

        public static List<Item> LoadItemData()
        {
            string loadJson = File.ReadAllText("item.json");
            List<Item> loadItems = JsonConvert.DeserializeObject<List<Item>>(loadJson);
            return loadItems;
        }
    }
}
```
데이터 저장&불러오기 메서드
json 형식으로 저장하며 플레이어 정보와 아이템 정보를 각각의 json파일에 저장한다

### Item Class
```
namespace TextGame
{
    public enum ItemType
    {
        weapon, armor, potion
    }

    public class Item
    {
        public string itemName;
        public string itemInfo;
        public int price;
        public int atkUp;
        public int defUp;
        public int hpUp;
        public int requireLevel;
        public int itemIndex;
        public bool isBought;
        public bool isEquip;
        public ItemType type;
```
아이템의 타입을 무기, 갑옷, 포션 3종으로 나누고 아이템의 각  수치들을 선언한다
```
        static int i;

        public static List<Item> items = new List<Item>
        {
            new Item
            {
                itemName = "무쇠 갑옷",
                itemInfo = "무쇠로 만들어진 튼튼한 갑옷",
                price = 0,
                atkUp = 0,
                defUp = 5,
                requireLevel = 0,
                itemIndex = 0,
                isBought = true,
                isEquip = false,
                type = ItemType.armor
            },
            new Item
            {
                itemName = "낡은 검",
                itemInfo = "쉽게 볼 수 없는 낡은 검",
                price = 0,
                atkUp = 2,
                defUp = 0,
                requireLevel = 0,
                itemIndex = 0,
                isBought = true,
                isEquip = false,
                type = ItemType.weapon
            }
        };
```
아이템들은 리스트로 저장한다
리스트 안에서 아이템 각각의 수치들을 지정한다
```
        public static void PrintItem()
        {
            foreach (Item item in items)
            {
                if (item.isBought)
                {
                    if (item.isEquip)
                        Console.WriteLine($"[E]{item.itemName}");
                    else
                        Console.WriteLine($"{item.itemName}");
                    Console.SetCursorPosition(2, Console.CursorTop + 1);
                }
            }
        }
```
 인벤토리 창에서 사용될 아이템 목록을 출력하는 메서드
 구현 예정인 상점에서 출력될 아이템들은 인벤토리에 나오면 안되니 isBought 변수로 플레이어가 가지고 있는 아이템들만 출력한다
 isEquip 변수로 현재 장착중인지 여부를 확인하여 아이템 이름 앞에 [E]를 띄울지를 결정한다
```

        public static void PrintEquipSetting()
        {
            i = 1;
            foreach (Item item in items)
            {
                if (item.isBought)
                {
                    if (item.isEquip)
                        Console.WriteLine($"{i++}.[E]{item.itemName}");
                    else
                        Console.WriteLine($"{i++}.{item.itemName}");
                    item.itemIndex = i;
                    Console.SetCursorPosition(2, Console.CursorTop + 1);
                }
            }
            Console.SetCursorPosition(2, 34);
        }
```
인벤토리에서 장비 장착관리 창으로 넘어가면 아이템을 출력하는 메서드
위에서 선언한 i 변수는 여기서 아이템 앞에 순서대로 번호를 붙이기 위해 사용된다
item.itemIndex를 1부터 시작하게 만드려 했지만 실제로 저장된 값은 2부터 시작된다
원인을 찾지 못했고 현재는 실행하는데 문제가 없어 일단 방치중
```
        public static void EquipManager(Data.PlayerInfo playerInfo)
        {
            int input;
            while ((input = InputControl.CheckValidInput(0, i)) != 0)
            {
                Item selectedItem = items.Find(items => items.itemIndex == input + 1);
```
장비관리창에서 사용되는 메서드
0번을 누르면 인벤토리 창으로 돌아가게 구현했기 때문에 0을 제외한 값이 입력될때 반복하도록 조건 설정
아이템 이름 앞에 표시되는 숫자를 입력하면 해당 아이템이 선택되도록 구현
```
                if (selectedItem != null)
                {
                    Console.SetCursorPosition(27, 9);
                    Console.WriteLine($"아이템 유형: {selectedItem.type}");
                    Console.SetCursorPosition(27, 10);
                    Console.WriteLine($"가격: {selectedItem.price}");
                    Console.SetCursorPosition(27, 11);
                    Console.WriteLine($"착용 제한 레벨: {selectedItem.requireLevel}");
                    Console.SetCursorPosition(27, 12);
                    Console.WriteLine($"공격력 상승량: {selectedItem.atkUp}");
                    Console.SetCursorPosition(27, 13);
                    Console.WriteLine($"방어력 상승량: {selectedItem.defUp}");
                    Console.SetCursorPosition(27, 14);
                    Console.WriteLine($"아이템 설명:\n{selectedItem.itemInfo}");

                    Console.SetCursorPosition(2, 34);
```
화면에 아이템의 세부 정보들을 가져와서 출력한다
아이템 설명도 창 안의 지정된 범위에서 출력하도록 구현하려 했지만 실패
처음에는 반복문 등을 사용해 구조체 필드 선언 순서대로 값을 대입시킬 방법이 없나 찾아봤지만 없는것 같아 하나씩 일일히 대입시킴
```
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Spacebar) 
                    {
                        selectedItem.isEquip = !selectedItem.isEquip;
                        if (selectedItem.isEquip)
                        {
                            playerInfo.atk += selectedItem.atkUp;
                            playerInfo.def += selectedItem.defUp;
                            playerInfo.hp += selectedItem.hpUp;
                        }
                        else
                        {
                            playerInfo.atk -= selectedItem.atkUp;
                            playerInfo.def -= selectedItem.defUp;
                            playerInfo.hp -= selectedItem.hpUp;
                        }
                        Data.SavePlayerData(playerInfo);
                        Data.SaveItemData(items);
                    }
                }
```
장비의 장착 여부를 판단하여 장착했다면 장비의 추가스탯값을 플레이어에게 적용시킨다
플레이어의 스탯과 아이템의 장착여부를 저장한다
```
                for (int j = 9; j < 31; j++)
                {
                    Console.SetCursorPosition(2, j);
                    Console.Write("                       ");
                    Console.SetCursorPosition(27, j);
                    Console.Write("                       ");
                }
                Console.SetCursorPosition(2, 9);
                PrintEquipSetting();
            }
            Console.Clear();
            SceneManager.LoadInventory();
            Console.SetCursorPosition(2, 34);
        }
    }
}
```
아이템을 장착 또는 해제하고 나면 아이템 설명을 표시하는 부분을 공백문자로 채워 지운다
0을 누르면 반복문을 빠져나와 다시 인벤토리로 돌아간다
### SceneManager Class
```
namespace TextGame
{
    class SceneManager
    {
        public InputControl inputControl = new InputControl();
        static public Data.PlayerInfo playerInfo;
```
클래스 객체 생성
```
        public static void LoadTitle()
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
```
타이틀 화면에서 표시할 아스키아트와 텍스트를 출력한다
```
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
```
입력값에 따라 화면을 지우고 다른 씬을 호출한다
```
        public static void LoadStatus()
        {
            playerInfo = Data.LoadPlayerData();
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
```
상태창 화면을 출력한다
```
            Console.SetCursorPosition(2, 9);
            Console.WriteLine($"이름: {playerInfo.name}");
            Console.SetCursorPosition(28, 9);
            Console.WriteLine($"직업: {playerInfo.playerClass}");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine($"레벨: {playerInfo.level}\n" +
                              $"│ 경험치: {playerInfo.exp}\n" +
                              $"│ 공격력: {playerInfo.atk}\n" +
                              $"│ 방어력: {playerInfo.def}\n" +
                              $"│ 체력: {playerInfo.hp}");
                            //$"│ 물리공격: {playerInfo.pAtk}\n" +
                            //$"│ 마법공격: {playerInfo.mAtk}\n" +
                            //$"│ 물리방어: {playerInfo.pDef}\n" +
                            //$"│ 마법방어: {playerInfo.mDef}\n" +
                            //$"│ 민첩: {playerInfo.dex}\n" +
                            //$"│ 체력: {playerInfo.hp}\n" +
                            //$"│ 마나: {playerInfo.mp}\n");
            Console.SetCursorPosition(2, 24);
            Console.WriteLine("0. 나가기");
```
커서 위치를 조정해가면서 필요한 텍스트들을 출력한다
```
            switch (InputControl.CheckValidInput(0, 0))
            {
                case 0:
                    Console.Clear();
                    LoadTitle();
                    break;
            }
        }
```
0번 입력 시 타이틀 화면으로 돌아간다
```
        public static void LoadInventory()
        {
            Console.WriteLine("██╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗████████╗ ██████╗ ██████╗ ██╗   ██╗\r\n" +
                              "██║████╗  ██║██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝\r\n" +
                              "██║██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║   ██║   ██║   ██║██████╔╝ ╚████╔╝ \r\n" +
                              "██║██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   ██║   ██║██╔══██╗  ╚██╔╝  \r\n" +
                              "██║██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║   ██║   ╚██████╔╝██║  ██║   ██║   \r\n" +
                              "╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \r\n" +
                              "                                                                           \r\n");
            Console.WriteLine("┌────────────────────────┬────────────────────────┐\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                              "└────────────────────────┴────────────────────────┘");
```
인벤토리 화면을 출력한다
```
            Console.SetCursorPosition(2, 9);
            Item.PrintItem();

            Console.SetCursorPosition(2, 32);
            Console.WriteLine("1. 장착관리");
            Console.SetCursorPosition(2, 33);
            Console.WriteLine("0. 나가기");
            switch (InputControl.CheckValidInput(0, 1))
            {
                case 0:
                    Console.Clear();
                    LoadTitle();
                    break;
                case 1:
                    Console.Clear();
                    LoadEquipManager();
                    break;
            }
        }
```
1번 입력시 장비관리 화면
0번 입력시 타이틀로 돌아간다
```
        public static void LoadEquipManager()
        {
            Console.WriteLine("███████╗ ██████╗ ██╗   ██╗██╗██████╗ ███╗   ███╗███████╗███╗   ██╗████████╗\r\n" +
                              "██╔════╝██╔═══██╗██║   ██║██║██╔══██╗████╗ ████║██╔════╝████╗  ██║╚══██╔══╝\r\n" +
                              "█████╗  ██║   ██║██║   ██║██║██████╔╝██╔████╔██║█████╗  ██╔██╗ ██║   ██║   \r\n" +
                              "██╔══╝  ██║▄▄ ██║██║   ██║██║██╔═══╝ ██║╚██╔╝██║██╔══╝  ██║╚██╗██║   ██║   \r\n" +
                              "███████╗╚██████╔╝╚██████╔╝██║██║     ██║ ╚═╝ ██║███████╗██║ ╚████║   ██║   \r\n" +
                              "╚══════╝ ╚══▀▀═╝  ╚═════╝ ╚═╝╚═╝     ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝   \r\n" +
                              "                                                                           \r\n");
            Console.WriteLine("┌────────────────────────┬────────────────────────┐\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                             $"│                        │                        │\r\n" +
                              "└────────────────────────┴────────────────────────┘");
            Console.SetCursorPosition(2, 32);
            Console.WriteLine("아이템 장착 / 해제: Spacebar");
            Console.WriteLine("  0.나가기");

            Console.SetCursorPosition(2, 9);
            Item.PrintEquipSetting();
            Item.EquipManager(playerInfo);
        }
    }
}

```
장착관리 창을 출력한다
### InputControl
```
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
```
사용자로부터 입력받은 값이 매개변수로 지정받은 범위 안에 있는지 확인하고 범위 안이라면 입력받은 값을 반환한다
아니라면 다시 입력하라는 텍스트를 출력하고 입력을 다시 받는다
