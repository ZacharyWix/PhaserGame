using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public SteamAchievements sa;
    private Achievement achievement;
    private level lv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateUnlocks()
    {
        if (level.getLevelDeaths(1) != -1 && level.getLevelDeaths(1) < 5)
        {
            print("unlocking 0");
            achievement = new Achievement(0);
            sa.UnlockSteamAchievement("achievement_00");
        }
        if (level.getLevelDeaths(2) != -1 && level.getLevelDeaths(2) < 5)
        {
            print("unlocking 1");
            achievement = new Achievement(1);
            sa.UnlockSteamAchievement("achievement_01");
        }
        if (level.getLevelDeaths(3) != -1 && level.getLevelDeaths(3) < 5)
        {
            print("unlocking 2");
            achievement = new Achievement(2);
        }
    }
}
