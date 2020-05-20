using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamAchievements : MonoBehaviour
{
    // Start is called before the first frame update
    public static SteamAchievements script;

    private int iconInt = -1;
    private uint icon_width;
    private uint icon_height;
    private bool unlockTest = false;

    void Start()
    {
        
    }

    void Awake()
    {
        TestUnlock();
        script = this;
        if (!SteamManager.Initialized)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockSteamAchievement(string ID)
    {
        TestSteamAchievement(ID);
        if (!unlockTest)
        {
            SteamUserStats.SetAchievement(ID);
            SteamUserStats.StoreStats();
        }
    }

    public void DEBUG_LockSteamAchievement(string ID)
    {
        TestSteamAchievement(ID);
        if(unlockTest)
        {
            SteamUserStats.ClearAchievement(ID);
        }
    }

    public bool GetSteamAchievementStatus(string ID)
    {
        TestSteamAchievement(ID);
        return unlockTest;
    }

    public void UnlockAchievement(int ID)
    {
        if (SteamAchievements.script.gameObject.activeSelf)
        {
            SteamAchievements.script.UnlockSteamAchievement("achievement_" + (ID < 10 ? "0" : "") + ID.ToString());
        }
    }

    void TestSteamAchievement(string ID)
    {
        SteamUserStats.GetAchievement(ID, out unlockTest);
    }

    public void TestUnlock()
    {
        //SteamAchievements.script.UnlockSteamAchievement("achievement_00");
    }

    public void resetAll()
    {
        SteamUserStats.ResetAllStats(true);
    }

    public void updateDeathStat(int deaths)
    {
        print("input: " + deaths);
        int num;
        print(SteamUserStats.RequestCurrentStats());
        print(SteamUserStats.SetStat("Deaths", deaths));
        print(SteamUserStats.StoreStats());
        print(SteamUserStats.RequestUserStats(SteamUser.GetSteamID()));
        print(SteamUserStats.GetStat("Deaths", out num));
        print("Deaths from steam stats: " + num);
    }
}
