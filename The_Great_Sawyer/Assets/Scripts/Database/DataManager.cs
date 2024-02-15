using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class DataManager : MonoBehaviour
{

    public TextMeshProUGUI text;
    //Singletone
    public static DataManager Instance;

    private string userFilePath;
    private string NPCFilePath;
    private string itemsFilePath;
    private string furnituresFilePath;
    private string questsFilePath;
    private string achievementsFilePath;

    //Classes

    [Serializable]
    public class NPC
    {
        public string name;
        public int type;
        public string[] defaultTalks;
        public string[] giveQuestTalks;
        public string[] beforeCompleteTalks;
        public string[] completeQuestTalks;
        public string[] afterCompleteTalks;
        public int NPCID;
        public int questID;
        public Vector3Int location;

        public NPC(string _name, int _questID)
        {
            name = _name;
            type = 0;
            defaultTalks = new string[1];
            giveQuestTalks = new string[1];
            beforeCompleteTalks = new string[1];
            completeQuestTalks = new string[1];
            afterCompleteTalks = new string[1];
            NPCID = 0;
            questID = _questID;
            location = Vector3Int.zero;
        }
    }

    [Serializable]
    public class NPCContainer
    {
        public NPC[] NPCs;
    }

    [Serializable]
    public class Item
    {
        public string name;
        public string description;
        public int itemID;

        public Item()
        {
            name = "temp";
            description = "This is description";
            itemID = 0;
        }

        public Item(string _name, string _description)
        {
            name = _name;
            description = _description;
            itemID = 0;
        }
    }

    [Serializable]
    public class Items
    {
        public Item[] items;
    }

    [Serializable]
    public class Furniture
    {
        public string furnitureName;
        public string description;
        public string color;
        public bool isBatched;
        public int batchX;
        public int batchY;
        public int rotate;
        public string batchTilemap;
        public int furnitureID;

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
            furnitureID = 0;
        }

        public Furniture(string _name, string _description)
        {
            furnitureName = _name;
            description = _description;
            color = "red";
            isBatched = false;
            batchX = 0;
            batchY = 0;
            rotate = 0;
            batchTilemap = "None";
            furnitureID = 0;
        }
    }

    [Serializable]
    public class Furnitures
    {
        public Furniture[] furnitureList;
    }

    [Serializable]
    public class DailyQuest
    {
        public string name;
        public string description;
        public string requireItem;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;
        public int questID;

        public DailyQuest()
        {
            name = "tempQuest";
            description = "This is quest";
            requireItem = "tempItem";
            requireAmount = 1;
            isCleared = false;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
            questID = 0;
        }

        public DailyQuest(string _name, string _description, string _requireItem, int _requireAmount, string _rewardMoney, int _rewardAmount)
        {
            name = _name;
            description = _description;
            requireItem = _requireItem;
            requireAmount = _requireAmount;
            rewardMoney = _rewardMoney;
            rewardAmount = _rewardAmount;
            isCleared = false;
            questID = 0;
        }
    }

    [Serializable]
    public class WeeklyQuest
    {
        public string name;
        public string description;
        public string requireItem;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;
        public int questID;

        public WeeklyQuest()
        {
            name = "tempQuest";
            description = "This is quest";
            requireItem = "tempItem";
            requireAmount = 1;
            isCleared = false;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
            questID=0;
        }

        public WeeklyQuest(string _name, string _description, string _requireItem, int _requireAmount, string _rewardMoney, int _rewardAmount)
        {
            name = _name;
            description = _description;
            requireItem = _requireItem;
            requireAmount = _requireAmount;
            rewardMoney = _rewardMoney;
            rewardAmount = _rewardAmount;
            isCleared = false;
            questID = 0;
        }
    }

    [Serializable]
    public class MonthlyQuest
    {
        public string name;
        public string description;
        public string requireItem;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;
        public int questID;

        public MonthlyQuest()
        {
            name = "tempQuest";
            description = "This is quest";
            requireItem = "tempItem";
            requireAmount = 1;
            isCleared = false;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
            questID = 0;
        }

        public MonthlyQuest(string _name, string _description, string _requireItem, int _requireAmount, string _rewardMoney, int _rewardAmount)
        {
            name = _name;
            description = _description;
            requireItem = _requireItem;
            requireAmount = _requireAmount;
            rewardMoney = _rewardMoney;
            rewardAmount = _rewardAmount;
            isCleared = false;
            questID = 0;
        }
    }

    [Serializable]
    public class Quests
    {
        public DailyQuest[] dailyQuests;
        public WeeklyQuest[] weeklyQuests;
        public MonthlyQuest[] monthlyQuests;
    }

    [Serializable]
    public class moneyAchievement
    {
        public string name;
        public string description;
        public string requireVariable;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;
        public int achiveID;

        public moneyAchievement()
        {
            name = "tempMoneyAchivement";
            description = "description";
            requireVariable = "None";
            requireAmount = 1;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
            achiveID = 0;
        }
    }

    [Serializable]
    public class furnitureAchievement
    {
        public string name;
        public string description;
        public string requireVariable;
        public int requireAmount;
        public bool isCleared;
        public string rewardMoney;
        public int rewardAmount;
        public int achiveID;

        public furnitureAchievement()
        {
            name = "tempMoneyAchivement";
            description = "description";
            requireVariable = "None";
            requireAmount = 1;
            rewardMoney = "ironIngot";
            rewardAmount = 10;
            achiveID = 0;
        }
    }

    [Serializable]
    public class levelAchievement
    {
        public string[] name;
        public string[] description;
        public string requireVariable;
        public int[] requireAmount;
        public int level;
        public bool isCleared;
        public string rewardVariable;
        public int[] rewardAmount;
        public int achiveID;

        public levelAchievement()
        {
            name = new string[] { };
            description = new string[] { };
            requireVariable = "None";
            requireAmount = new int[] { 1 };
            level = 0;
            isCleared = false;
            rewardVariable = "None";
            rewardAmount = new int[] { 1 };
            achiveID = 0;
        }
    }

    [Serializable]
    public class Achievements
    {
        public moneyAchievement[] moneyAchivements;
        public furnitureAchievement[] furnitureAchivements;
        public levelAchievement[] levelAchivements;
    }

    [Serializable]
    public class User
    {
        public string userName;
        public int birthDay;
        public int workDays;
        public string currentCity;
        public Money money;

        [Serializable]
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
                ironIngot = 500;
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

        [Serializable]
        public class Inventory
        {
            public Item[] myItems;
            public int[] itemAmounts;
            public Furniture[] myFurnitures;
            public int[] furnitureAmounts;

            public Inventory()
            {
                myItems = new Item[0];
                itemAmounts = new int[0];
                myFurnitures = new Furniture[0];
                furnitureAmounts = new int[0];
            }
        }

        public Quests myQuest;
        public int clearedQuest;
    }

    public User user;
    public NPCContainer npcContainer;
    public Items items;
    public Furnitures furnitures;
    public Quests quests;
    public Achievements achievements;

    //Functions
    void Awake() //set file pathes.
    {
        userFilePath = Application.persistentDataPath + "/user.json";
        NPCFilePath = Application.persistentDataPath + "/npc.json";
        itemsFilePath = Application.persistentDataPath + "/items.json";
        furnituresFilePath = Application.persistentDataPath + "/furnitures.json";
        questsFilePath = Application.persistentDataPath + "/quests.json";
        achievementsFilePath = Application.persistentDataPath + "/achievements.json";

        if (Instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            Instance = this;
        }
    }


    public void SaveData(string type)
    {
        switch (type)
        {
            case "user":
                SaveUserData(); break;
            case "npc":
                SaveNPCData(); break;
            case "items":
                SaveItemsData(); break;
            case "furnitures":
                SaveFurnituresData(); break;
            case "quests":
                SaveQuestsData(); break;
            case "achivements":
                SaveAchivementsData(); break;
            case "all":
                SaveUserData();
                SaveItemsData();
                SaveFurnituresData();
                SaveQuestsData();
                SaveAchivementsData();
                break;
        }
        Debug.Log(type + " Saved.");
        text.text = "Success!";
    }

    private void SaveUserData()
    {
        string jsonStr = JsonUtility.ToJson(user, true);
        File.WriteAllText(userFilePath, jsonStr);
    }

    private void SaveNPCData()
    {
        string jsonStr = JsonUtility.ToJson(npcContainer, true);
        File.WriteAllText(NPCFilePath, jsonStr);
    }

    private void SaveItemsData()
    {
        string jsonStr = JsonUtility.ToJson(items, true);
        File.WriteAllText(itemsFilePath, jsonStr);
    }

    private void SaveFurnituresData()
    {
        string jsonStr = JsonUtility.ToJson(furnitures, true);
        File.WriteAllText(furnituresFilePath, jsonStr);
    }
    private void SaveQuestsData()
    {
        string jsonStr = JsonUtility.ToJson(quests, true);
        File.WriteAllText(questsFilePath, jsonStr);
    }

    private void SaveAchivementsData()
    {
        string jsonStr = JsonUtility.ToJson(achievements, true);
        File.WriteAllText(achievementsFilePath, jsonStr);
    }

    public void LoadData(string type)
    {
        switch (type)
        {
            case "user":
                LoadUserData(); break;
            case "npc":
                LoadNPCData(); break;
            case "items":
                LoadItemsData(); break;
            case "furnitures":
                LoadFurnituresData(); break;
            case "quests":
                LoadQuestsData(); break;
            case "achievements":
                LoadAchievementsData(); break;
            case "all":
                LoadUserData();
                LoadItemsData();
                LoadFurnituresData();
                LoadQuestsData();
                LoadAchievementsData();
                break;
        }
        Debug.Log(type + " Loaded.");
    }

    private void LoadUserData()
    {
        if (!File.Exists(userFilePath))
        {
            Debug.Log("Load Failed");
        } else
        {
            string jsonStr = File.ReadAllText(userFilePath);
            user = JsonUtility.FromJson<User>(jsonStr);
        }
    }

    private void LoadNPCData()
    {
        if (!File.Exists(NPCFilePath))
        {
            Debug.Log("Load Failed");
        }
        else
        {
            string jsonStr = File.ReadAllText(NPCFilePath);
            npcContainer = JsonUtility.FromJson<NPCContainer>(jsonStr);
        }
    }

    private void LoadItemsData()
    {
        if (!File.Exists(itemsFilePath))
        {
            Debug.Log("Load Failed");
        }
        else
        {
            string jsonStr = File.ReadAllText(itemsFilePath);
            items = JsonUtility.FromJson<Items>(jsonStr);
        }
    }

    private void LoadFurnituresData()
    {
        if (!File.Exists(furnituresFilePath))
        {
            Debug.Log("Load Failed");
        }
        else
        {
            string jsonStr = File.ReadAllText(furnituresFilePath);
            furnitures = JsonUtility.FromJson<Furnitures>(jsonStr);
        }
    }

    private void LoadQuestsData()
    {
        if (!File.Exists(questsFilePath))
        {
            Debug.Log("Load Failed");
        }
        else
        {
            string jsonStr = File.ReadAllText(questsFilePath);
            quests = JsonUtility.FromJson<Quests>(jsonStr);
        }
    }

    private void LoadAchievementsData()
    {
        if (!File.Exists(achievementsFilePath))
        {
            Debug.Log("Load Failed");
        }
        else
        {
            string jsonStr = File.ReadAllText(achievementsFilePath);
            achievements = JsonUtility.FromJson<Achievements>(jsonStr);
        }
    }

    public void Init()
    {
        //Items init
        Item apple = new Item("���", "���� �� ����Դϴ�!");
        Item banana = new Item("�ٳ���", "���� ������ �ٳ����Դϴ�!");
        items.items = new Item[] { apple, banana };

        //Furnitures init
        Furniture lamp = new Furniture("��� ����", "�������� ����ִ� ��� �����Դϴ�.");
        Furniture closet = new Furniture("�ź��� ����", "���� ���� ������ ���� ���� �мŴϽ�Ÿ!");
        furnitures.furnitureList = new Furniture[] { lamp, closet };

        //Quests init
        DailyQuest helpGrandma = new DailyQuest("�ҸӴ� ���͵帮��", "�ҸӴϸ� ���� ������ �����ּ���!", "���尩", 2, "ö����", 50);
        DailyQuest manageTrain = new DailyQuest("���� �����ϱ�", "������ �̻��� ������ �������ּ���!", "���г�", 1, "��Ϲ���", 10);
        WeeklyQuest meetPeople = new WeeklyQuest("E�� ��� �˳���", "���ο� NPC�� 5�� ���� ��ȭ�� ��������!", "None", 0, "��Ϲ���", 50);
        WeeklyQuest adventrue = new WeeklyQuest("���¾� Ž�谡!", "5�ϰ� ������� �Ϸ翡 �ѹ��� ��ȭ�ϼ���!", "None", 0, "ö����", 100);
        MonthlyQuest newCities = new MonthlyQuest("���¾� ��ô��!", "�ٸ� ���÷� �� �� �̻� �̵��ϼ���!", "��޿���", 50, "��ȯ��", 20);
        MonthlyQuest hiddenNPC = new MonthlyQuest("...", "������ NPC�� ��ȭ�ϼ���!", "�޴�� ����", 1, "ö����", 1000);
        quests.dailyQuests = new DailyQuest[] { helpGrandma, manageTrain };
        quests.weeklyQuests = new WeeklyQuest[] { meetPeople, adventrue };
        quests.monthlyQuests = new MonthlyQuest[] { newCities, hiddenNPC };

        //NPCs Init
        NPC testNPC = new NPC("�ŵ���", 1);
        testNPC.location = new Vector3Int(2, 2, 0);
        testNPC.defaultTalks = new string[] { "���� �׽�Ʈ��", "�̵� �и����� �������� Q 4�����̸� ���� �� ��.", "���������� Į���� ��������!" };
        npcContainer.NPCs = new NPC[] { testNPC };

        //quest Init
        //string questsJsonStr = File.ReadAllText(Application.dataPath + "/Scripts/Database/JsonData/quests.json");
        //quests = JsonUtility.FromJson<Quests>(questsJsonStr);

        SaveData("items");
        SaveData("furnitures");
        SaveData("quests");
        SaveData("user");
        SaveData("npc");

        LoadData("user");
        LoadData("npc");
        Debug.Log(user.userName);
    }
}
