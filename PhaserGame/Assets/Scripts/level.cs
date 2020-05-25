using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class level : MonoBehaviour
{

    public int levelNum, deaths;
    public bool active;
    public float time;
    public static List<level> levels = new List<level>();
    static bool loading = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        //LoadGame();
    }
    public level(int l, int d, bool a, float t)
    {
        levelNum = l;
        deaths = d;
        active = a;
        time = t;
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

    public static void clear()
    {
        levels.Clear();
    }
    public void addLevel()
    {
        print("Length: " + levels.Count);
        print("Num: " + this.levelNum);
        print("Deaths: " + this.deaths);
        print("Active: " + this.active);
        int index = 0;
        bool exists = false;
        if (this.active == false)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i].levelNum == this.levelNum && levels[i].active == false)
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
            if (exists == true && levels[index].time > this.time)
            {
                levels[index].time = this.time;
            }
            removeActiveLevel(this.levelNum);
        }
        else
        {
            bool existsa = false;
            int indexa = 0;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i].levelNum == this.levelNum && levels[i].active == true)
                {
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
                levels[indexa].deaths = this.deaths;
                levels[indexa].time = this.time;
            }
        }
        if (!loading)
        {
            //SaveGame();
        }
        print("Length: " + levels.Count);
        for (int i = 0; i < levels.Count; i++)
        {
            print("Index: " + i);
            print(levels[i].levelNum);
            print(levels[i].deaths);
            print(levels[i].time);
            print(levels[i].active);
        }
    }

    public static int getLevelNum(int num)
    {
        return levels[num].levelNum;
    }

    public static bool getActive(int num)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum == num)
            {
                return levels[i].active;
            }
        }
        return false;
    }

    public static int getLevelDeaths(int num)
    {
        int numDeaths = -1;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum == num && levels[i].active == false)
            {
                numDeaths = levels[i].deaths;
            }
        }
        return numDeaths;
    }

    public static float getLevelTime(int num)
    {
        float time = -1;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum == num && levels[i].active == false)
            {
                time = levels[i].time;
            }
        }
        return time;
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

    public static float getTotalTime()
    {
        float time = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            time += levels[i].time;
        }
        return time;
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
        else 
        {
            return 0;
        }
    }

    public static float getActiveTime(int l)
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
            return levels[index].time;
        }
        else
        {
            return 0;
        }
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

    public static int getWorldDeaths(int world)
    {
        int one = 0;
        int two = 0;
        int three = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum <= 10 && !levels[i].active)
            {
                one += levels[i].deaths;
            }
            if (levels[i].levelNum <= 20 && levels[i].levelNum > 10 && !levels[i].active)
            {
                two += levels[i].deaths;
            }
            if (levels[i].levelNum > 20 && !levels[i].active)
            {
                three += levels[i].deaths;
            }
        }
        if (world == 1)
        {
            return one;
        }
        else if(world == 2)
        {
            return two;
        }
        else
        {
            return three;
        }
    }

    public static float getWorldTime(int world)
    {
        float one = 0;
        float two = 0;
        float three = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelNum <= 10 && !levels[i].active)
            {
                one += levels[i].time;
            }
            if (levels[i].levelNum <= 20 && levels[i].levelNum > 10 && !levels[i].active)
            {
                two += levels[i].time;
            }
            if (levels[i].levelNum > 20 && !levels[i].active)
            {
                three += levels[i].time;
            }
        }
        if (world == 1)
        {
            return one;
        }
        else if (world == 2)
        {
            return two;
        }
        else
        {
            return three;
        }
    }

    public void SaveGame()
    {
        print("OLD SAVE");
        saveGame save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        //print(Application.persistentDataPath + "/gamesave.save");
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }
    private saveGame CreateSaveGameObject()
    {
        saveGame save = new saveGame();
        for (int i = 0; i < levels.Count; i++)
        {
            List<float> temp = new List<float>();
            temp.Add(levels[i].levelNum);
            temp.Add(levels[i].deaths);
            if (levels[i].active == true)
            {
                temp.Add(1);
            }
            else
            {
                temp.Add(0);
            }
            temp.Add(levels[i].time);
            save.levelSave.Add(temp);
        }
        save.achievementSave = Achievement.getList();
        //save.optionsSave[0] = OptionsMenu.getSFXVolume();
        //save.optionsSave[1] = OptionsMenu.getMusicVolume();
        //if (OptionsMenu.getIsOn())
        //{
           // save.optionsSave[2] = 1f;
        //}
        //else
        //{
            //save.optionsSave[2] = 0f;
        //}
        return save;
    }

    public static void LoadGame()
    {
        loading = true;
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            saveGame save = (saveGame)bf.Deserialize(file);
            file.Close();

            // 3
            foreach (List<float> i in save.levelSave)
            {
                bool activity;
                if (i[2] == 1)
                {
                    activity = true;
                }
                else
                {
                    activity = false;
                }
                level lv = new level((int)i[0], (int)i[1], activity, i[3]);
            }
            foreach (int i in save.achievementSave)
            {
                print("Loading Achievement: " + i);
                Achievement achievement = new Achievement(i);
            }
            //OptionsMenu.setSFX(save.optionsSave[0]);
            //OptionsMenu.setMusic(save.optionsSave[1]);
            if(save.optionsSave[2] == 1)
            {
                OptionsMenu.setIsOn(true);
            }
            else
            {
                OptionsMenu.setIsOn(false);
            }
        }
        else
        {
            Debug.Log("No game saved!");
        }
        loading = false;
    }

    public static int numLevels() {
        return levels.Count;
    }
}
