using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public SteamAchievements sa;
    private Achievement achievement;
    private level lv;
    public GameObject achievement_00, achievement_01, achievement_02, achievement_03;
    private bool showing = false;
    private float timer = 0;
    private GameObject active;
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
        if (level.getLevelDeaths(1) != -1 && level.getLevelDeaths(1) < 5)
        {
            unlock(achievement_00);
        }
        if (level.getLevelDeaths(2) != -1 && level.getLevelDeaths(2) < 5)
        {
            unlock(achievement_01);
        }
        if (level.getLevelDeaths(3) != -1 && level.getLevelDeaths(3) < 5)
        {
            achievement = new Achievement(2);
        }
    }

    public void unlock(GameObject ach)
    {
        char[] MyChar = { 'a', 'c', 'h', 'i', 'e', 'v', 'e', 'm', 'e', 'n', 't', '_' };
        string a = ach.name.TrimStart(MyChar);
        int x = Int32.Parse(a);
        print(x);
        if(!Achievement.getUnlocked(x))
        {
            achievement = new Achievement(x);
            sa.UnlockSteamAchievement(ach.name);
            ach.SetActive(true);
            active = ach;
            showing = true;
        }
    }
}
