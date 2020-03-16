using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{

    public int levelNum, deaths;
    public bool active;
    public static List<level> levels = new List<level>();

    public level(int l, int d, bool a)
    {
        levelNum = l;
        deaths = d;
        active = a;
        addLevel();
    }

    public static void removeActiveLevel(int l)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum == l && levels[i].active == true)
            {
                levels.RemoveAt(i);
            }
        }
    }
    public void addLevel()
    {
        print("hits part 1");
        int index = 0;
        bool exists = false;
        if (this.active == false)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i].levelNum == this.levelNum)
                {
                    exists = true;
                    index = i;
                }
            }
            if (exists == false)
            {
                levels.Add(this);
            }
            else if (levels[index].deaths > this.deaths)
            {
                levels[index].deaths = this.deaths;
            }
        }
        else
        {
            bool existsa = false;
            int indexa = 0;
            print("hits part 2");
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i].levelNum == this.levelNum && levels[i].active == true)
                {
                    print("hits part 3");
                    existsa = true;
                    indexa = i;
                }
            }
            if (existsa == false)
            {
                levels.Add(this);
            }
            else
            {
                levels[index].deaths = this.deaths;
            }
        }
        for (int i = 0; i < levels.Count; i++)
        {
            print("Level Number: " + levels[i].levelNum);
            print("Deaths: " + levels[i].deaths);
            print("Active: " + levels[i].active);
        }
    }

    public static int getLevelDeaths(int num)
    {
        int numDeaths = 13084723;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum == num && levels[i].active == false)
            {
                numDeaths = levels[i].deaths;
            }
        }
            return numDeaths;
    }

    public static int getTotalDeaths()
    {
        int totalDeaths = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            totalDeaths += levels[i].deaths;
        }
        return totalDeaths;
    }

    public static int getActiveDeaths(int l)
    {
        bool exists = false;
        int index = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum == l && levels[i].active == true)
            {
                exists = true;
                index = i;
            }
        }
        if (exists == true)
        {
            return levels[index].deaths;
        }
        else return 0;
    }

    public static int getMaxLevel(bool active)
    {
        int max = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum > max && levels[i].active == active)
            {
                max = levels[i].levelNum;
            }
        }
        return max;
    }

}
