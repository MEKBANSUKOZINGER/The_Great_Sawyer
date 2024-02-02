using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public class City
    {
        public string cityName;
        public bool isUnlocked;

        public City()
        {
            cityName = "temp";
            isUnlocked = false;
        }
    }

    public class Cities
    {
        public City[] cities;
    }

    public class Item
    {
        public string name;
        public string description;

        public Item()
        {
            name = "temp";
            description = "This is description";
        }
    }

    public class Items
    {
        public Item[] items;
    }

    public class  Furniture
    {
        public string furnitureName;
        public string description;
        public string color;
        public bool isBatched;
        public int batchX;
        public int batchY;
        public int rotate;
        public string batchTilemap;

        public Furniture()
        {
            furnitureName = "temp";
            description = "This is description";
            color = "red";
            isBatched = false;
            batchX = 0;
            batchY = 0;
            rotate = 0;
            batchTilemap = "tilemap";
        }
    }

    public class furnitures
    {
        public Furniture[] furnitureList;
    }

    public class DailyQuest
    {
        public string name;
        public string description;
        public string requireItem;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;

        public DailyQuest()
        {
            name = "tempQuest";
            description = "This is quest";
            requireItem = "tempItem";
            requireAmount = 1; 
            isCleared = false;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
        }
    }

    public class WeeklyQuest
    {
        public string name;
        public string description;
        public string requireItem;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;

        public WeeklyQuest()
        {
            name = "tempQuest";
            description = "This is quest";
            requireItem = "tempItem";
            requireAmount = 1;
            isCleared = false;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
        }
    }

    public class MonthlyQuest
    {
        public string name;
        public string description;
        public string requireItem;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;

        public MonthlyQuest()
        {
            name = "tempQuest";
            description = "This is quest";
            requireItem = "tempItem";
            requireAmount = 1;
            isCleared = false;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
        }
    }

    public class Quests
    {
        public DailyQuest[] dailyQuests;
        public WeeklyQuest[] weeklyQuests;
        public MonthlyQuest[] monthlyQuests;
    }

    public class moneyAchivement
    {
        public string name;
        public string description;
        public string requireVariable;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;

        public moneyAchivement()
        {
            name = "tempMoneyAchivement";
            description = "description";
            requireVariable = "None";
            requireAmount = 1;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
        }
    }

    public class  furnitureAchivement
    {
        public string name;
        public string description;
        public string requireVariable;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;

        public furnitureAchivement()
        {
            name = "tempMoneyAchivement";
            description = "description";
            requireVariable = "None";
            requireAmount = 1;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
        }
    }

    public class levelAchivement
    {
        public string[] name;
        public string[] description;
        public string requireVariable;
        public int[] requireAmount;
        public int level;
        public bool isCleared;
        public string rewardVariable;
        public int[] rewardAmount;

        public levelAchivement()
        {
            name = new string[] { };
            description = new string[] { };
            requireVariable = "None";
            requireAmount = new int[] { 1 };
            level = 0;
            isCleared = false;
            rewardVariable = "None";
            rewardAmount = new int[] { 1 };
        }
    }

    public class Achivements
    {
        public moneyAchivement[] moneyAchivements;
        public furnitureAchivement[] furnitureAchivements;
        public levelAchivement[] levelAchivements;
    }

    public class User
    {
        public string userName;
        public int birthDay;
        public int workDays;
        public City currentCity;
        public Money money;
        public class Money
        {
            public int ironIngot;
            public int gear;
            public int blueIce;
            public int star;
            public int shell;
            public int dotori;
            public int cloud;
            public int coal;
            public int ticket;
            public Money()
            {
                ironIngot = 0;
                gear = 0;  
                blueIce = 0;
                star = 0;
                shell = 0;
                dotori = 0;
                cloud = 0;
                ticket = 0;
            }
        }
        public Inventory inventory;

        public class Inventory
        {
            public Dictionary<Item, int> items;
            public Dictionary<Furniture, int> furnitures;

            public Inventory()
            {
                items = new Dictionary<Item, int>();
                furnitures = new Dictionary<Furniture, int>();
            }
        }

        public DailyQuest[] dailyQuests;
        public WeeklyQuest[] weeklyQuests;
        public MonthlyQuest[] monthlyQuests;
        public int clearedQuest;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        //FileStream stream = new FileStream(Application.dataPath + "/Data")
    }
}
