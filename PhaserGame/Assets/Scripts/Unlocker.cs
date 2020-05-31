using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public SteamAchievements sa;
    private Achievement achievement;
    private level lv;
    public GameObject achievement_00, achievement_01, achievement_02, achievement_03, achievement_04, 
    achievement_05, achievement_06, achievement_07, achievement_08, achievement_09, achievement_10, achievement_11,
    achievement_12, achievement_13, achievement_14, achievement_15;
    private bool showing = false;
    private float timer = 0;
    private GameObject active;
    private bool mystery = false;
    private List<GameObject> popups = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showing)
        {
            timer += 0.02f;
            if(timer > 5)
            {
                timer = 0;
                showing = false;
                active.SetActive(false);
            }
        }
    }

    public void updateUnlocks()
    {
        if (SteamManager.getActive())
        {
            sa.updateDeathStat(level.getTotalDeaths());
            SteamLeaderboards.UpdateScore(level.getTotalDeaths());
        }
        if (level.getLevelDeaths(1) != -1)
        {
            unlock(achievement_00);
        }
        if (level.getLevelDeaths(10) != -1 && level.getWorldDeaths(1) < 25)
        {
            unlock(achievement_01);
        }
        if (level.getLevelDeaths(10) != -1 && level.getWorldTime(1) < 200)
        {
            unlock(achievement_02);
        }
        if (level.getLevelDeaths(10) != -1 && level.getWorldDeaths(1) == 0)
        {
            unlock(achievement_03);
        }

        if (level.getLevelDeaths(20) != -1)
        {
            unlock(achievement_04);
        }
        if (level.getLevelDeaths(20) != -1 && level.getWorldDeaths(2) < 25)
        {
            unlock(achievement_05);
        }
        if (level.getLevelDeaths(20) != -1 && level.getWorldTime(2) < 300)
        {
            unlock(achievement_06);
        }
        if (level.getLevelDeaths(20) != -1 && level.getWorldDeaths(2) == 0)
        {
            unlock(achievement_07);
        }

        if (level.getLevelDeaths(30) != -1)
        {
            unlock(achievement_08);
        }
        if (level.getLevelDeaths(30) != -1 && level.getWorldDeaths(3) < 25)
        {
            unlock(achievement_09);
        }
        if (level.getLevelDeaths(30) != -1 && level.getWorldTime(3) < 400)
        {
            unlock(achievement_10);
        }
        if (level.getLevelDeaths(30) != -1 && level.getWorldDeaths(3) == 0)
        {
            unlock(achievement_11);
        }
        if (level.getLevelDeaths(30) != -1 && level.getTotalTime() < 1080)
        {
            unlock(achievement_12);
        }
        if (mystery)
        {
            unlock(achievement_13);
        }
        if (level.getLevelDeaths(30) != -1 && level.getTotalDeaths() == 0)
        {
            unlock(achievement_14);
        }
        if (Achievement.getLength() == 15)
        {
            unlock(achievement_15);
        }
    }

    public void unlock(GameObject ach)
    {
        char[] MyChar = { 'a', 'c', 'h', 'i', 'e', 'v', 'e', 'm', 'e', 'n', 't', '_' };
        string a = ach.name.TrimStart(MyChar);
        int x = Int32.Parse(a);
        if (!Achievement.getUnlocked(x))
        {
            achievement = new Achievement(x);
            if (SteamManager.getActive())
            {
                sa.UnlockSteamAchievement(ach.name);
            }
            ach.SetActive(true);
            active = ach;
            showing = true;
        }
    }
}
