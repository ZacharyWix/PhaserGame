using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class level : MonoBehaviour
{

    public int levelNum, deaths;
    public bool active;
    public static List<level> levels = new List<level>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        LoadGame();
    }
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
                levels[index].deaths = this.deaths;
            }
        }
        SaveGame();
    }

    public static int getLevelDeaths(int num)
    {
        print("Level Count: " + levels.Count);
        int numDeaths = -1;
        for (int i = 0; i < levels.Count; i++)
        {
            print("for" + i);
            print(levels[i].levelNum);
            print(levels[i].active);
            if (levels[i].levelNum == num && levels[i].active == false)
            {
                numDeaths = levels[i].deaths;
            }
        }
        print("finish" + numDeaths);
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

    public void SaveGame()
    {
        saveGame save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        print(Application.persistentDataPath + "/gamesave.save");
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }
    private saveGame CreateSaveGameObject()
    {
        saveGame save = new saveGame();
        for (int i = 0; i < levels.Count; i++)
        {
            List<int> temp = new List<int>();
            print("i: " + i);
            temp.Add(levels[i].levelNum);
            print("a");
            temp.Add(levels[i].deaths);
            print("b");
            if (levels[i].active == true)
            {
                temp.Add(1);
            }
            else
            {
                temp.Add(0);
            }
            save.levelSave.Add(temp);
        }
        return save;
    }

    public static void LoadGame()
    {
        print("runs");
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            print("finds");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            saveGame save = (saveGame)bf.Deserialize(file);
            file.Close();

            // 3
            foreach (List<int> i in save.levelSave)
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
                level lv = new level(i[0], i[1], activity);
            }
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public static int numLevels() {
        return levels.Count;
    }
}
