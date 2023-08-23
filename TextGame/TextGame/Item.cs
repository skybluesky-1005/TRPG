using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void EquipManager(Data.PlayerInfo playerInfo)
        {
            int input;
            while ((input = InputControl.CheckValidInput(0, i)) != 0)
            {
                Item selectedItem = items.Find(items => items.itemIndex == input + 1);
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
