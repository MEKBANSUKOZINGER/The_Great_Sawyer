using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using JetBrains.Annotations;

public class UserInfo : MonoBehaviour
{
    public static UserInfo Instance { get; private set; }

    public class User
    {
        public string username;
        public int workDays;
        public Dictionary<string, int> money;

        public User()
        {
            username = "Username";
            workDays = 1;
            money = new Dictionary<string, int>();
        }
        public User(string userName)
        {
            username = userName;
            workDays = 1;
            money = new Dictionary<string, int>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        User testUser = new User("MEKBANSUKOZINGER");
        Dictionary<string, int> requirements = new Dictionary<string, int>();
        requirements.Add("¿ï¶ö¶ó", 10);
        string jsonData = JsonConvert.SerializeObject(testUser);
        Debug.Log(jsonData);

        User test2User = JsonConvert.DeserializeObject<User>(jsonData);
    }

}
