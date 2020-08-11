using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRunMode : MonoBehaviour
{
    public MainMenu menu;
    public deathStats deathStat;
    private static bool speedRun = false;
    private static int level = 1;
    private static int deaths = 0;
    private static float time = 0;
    private static int bestDeaths = -1;
    private static float bestTime = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpeedRun(bool run)
    {
        speedRun = run;
    }

    public static bool getSpeedRun()
    {
        return speedRun;
    }

    public static void setLevel(int lvl)
    {
        level = lvl;
        if (level > 30)
        {
            level = 1;
            if(bestDeaths == -1 || deaths< bestDeaths)
            {
                bestDeaths = deaths;
            }
            if(bestTime == -1f || time < bestTime)
            {
                bestTime = time;
            }
            deaths = 0;
            time = 0;
        }
    }

    public void reset()
    {
        level = 1;
        deaths = 0;
        time = 0;
        menu.SaveGame();
        deathStat.updateDeathStats();
    }

    public static int getLevel()
    {
        return level;
    }

    public static void incLevel(int lvl)
    {
        level += lvl;
    }

    public static void setDeaths(int d)
    {
        deaths = d;
    }

    public static int getDeaths()
    {
        return deaths;
    }

    public static void incDeaths(int d)
    {
        deaths += d;
    }

    public static void setTime(float t)
    {
        time = t;
    }
    public static float getTime()
    {
        return time;
    }

    public static void incTime(float t)
    {
        time += t;
    }

    public void loadLevel()
    {
        menu.LoadScene(level);
    }

    public static int getBestDeaths()
    {
        return bestDeaths;
    }

    public static void setBestDeaths(int d)
    {
        bestDeaths = d;
    }

    public static float getBestTime()
    {
        return bestTime;
    }

    public static void setBestTime(float t)
    {
        bestTime = t;
    }
}
