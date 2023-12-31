﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.AccessControl;
using Newtonsoft.Json;

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
