using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{

    public int achievementNum;
    public static List<Achievement> achievements = new List<Achievement>();

    public Achievement(int a)
    {
        this.achievementNum = a;
        addAchievement();
    }

    public void addAchievement()
    {
        int index = -1;
        bool exists = false;
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievements[i].achievementNum == this.achievementNum)
            {
                exists = true;
                index = i;
            }
        }
        if (!exists)
        {
            achievements.Add(this);
        }
    }

    public static bool getUnlocked(int num)
    {
        bool unlocked = false;
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievements[i].achievementNum == num)
            {
                unlocked = true;
            }
        }
        return unlocked;
    }

    public static int getLength()
    {
        return achievements.Count;
    }
    public static List<int> getList()
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < achievements.Count; i++)
        {
            temp.Add(achievements[i].achievementNum);
        }
        return temp;
    }

    public static void clearAll()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            achievements.RemoveAt(i);
        }
    }
}
