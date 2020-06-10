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
    private int x = 0;
    private float speed = 0.1f;
    private float pos = -100.0f;
    private bool up = true;
    private List<GameObject> popups = new List<GameObject>();
    int width = Screen.width / 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x < popups.Count)
        {
            active = popups[x];
            if (pos < 125 && up)
            {
                pos += 2f;
                active.transform.position = new Vector2(width, pos);
            }
            else if (pos >= 125 && timer < 5 && up)
            {
                timer += 0.005f;
            }
            else if (timer >= 5)
            {
                timer = 0;
                up = false;
            }
            else if(pos > -100 && !up)
            {
                pos -= 2f;
                active.transform.position = new Vector2(width, pos);
            }
            else if(pos <= -100 && !up)
            {
                x += 1;
                up = true;
            }
        }
        else
        {
            x = 0;
            popups.Clear();
        }
    }

    public void updateUnlocks()
    {
        if (SteamManager.getActive())
        {
            sa.updateLevelsStat(level.getMaxLevel(false));
            sa.updateDeathStat(level.getTotalDeaths());
            sa.updateTimeStat(level.getTotalTime());
            if (level.getLevelDeaths(30) != -1)
            {
                SteamLeaderboards.UpdateScore(level.getTotalTime());
            }
        }
        if (level.getLevelDeaths(10) != -1)
        {
            unlock(achievement_00);
        }
        if (level.getLevelDeaths(10) != -1 && level.getTotalDeaths() < 25)
        {
            unlock(achievement_01);
        }
        if (level.getLevelDeaths(10) != -1  && level.getWorldTime(1) < 195)
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
        if (level.getLevelDeaths(20) != -1 && level.getWorldTime(2) < 240)
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
        if (level.getLevelDeaths(30) != -1 && level.getWorldTime(3) < 390)
        {
            unlock(achievement_10);
        }
        if (level.getLevelDeaths(30) != -1 && level.getWorldDeaths(3) == 0)
        {
            unlock(achievement_11);
        }
        if (level.getLevelDeaths(30) != -1 && level.getTotalTime() < 780)
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
            popups.Add(ach);
            ach.SetActive(true);
            showing = true;
        }
    }
}
