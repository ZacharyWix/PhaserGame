using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using Steamworks;
using TMPro;
using System.Globalization;

public class MainMenu : MonoBehaviour
{
    public deathStats deathStat;
    public deathCounter deathCount;
    public AchievementMenu achievementMenu;
    public OptionsMenu options;
    private phaserManager gm;
    public Canvas canvas;
    private bool unlocked = false;
    public SteamAchievements sa;
    private static bool loaded = false;
    private string user = "";
    private static bool practice = false;
    public GameObject controlsMenu, back;
    public GameObject cControlsMenu, backC;
    public TextMeshProUGUI w1CC, w2CC, w3CC, play1, play2, play3, prac1, prac2, prac3, cont1, cont2;
    private static int skin = 0;
    private static string delimiter = ".";

    private void Start()
    {
        string delim = Time.deltaTime.ToString();
        if (delim.Contains("."))
        {
            delimiter = ".";
        }
        else if (delim.Contains(","))
        {
            delimiter = ",";
        }
        Time.timeScale = 1;
        if (SteamManager.getActive())
        {
            user = "/" + SteamUser.GetSteamID();
        }
        if (!loaded)
        {
            LoadGame();
            loaded = true;
        }
         gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Button[] buttons = canvas.GetComponentsInChildren<Button>(true);
            updateButtons(buttons, unlocked);
            deathStat.updateDeathStats();
            achievementMenu.updateIcons();
        }
        if (SteamManager.getActive())
        {
            SteamLeaderboards.Init();
        }
    }

    public static string getDelimiter()
    {
        return delimiter;
    }
    public static void setLoaded(bool load)
    {
        loaded = load;
    }

    public static bool getLoaded()
    {
        return loaded;
    }
    public void practiceText()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            w1CC.text = "Use the C key (RB) to create a new checkpoint";
            w2CC.text = w1CC.text;
            w3CC.text = w1CC.text;
            play1.text = play2.text = play3.text = Environment.NewLine + "Play Mode" + Environment.NewLine + "(X)";
            prac1.text = prac2.text = prac3.text = Environment.NewLine + "Practice Mode (X)";
            cont1.text = Environment.NewLine + "Controller" + Environment.NewLine + "(X)";
            cont2.text = Environment.NewLine + "Keyboard" + Environment.NewLine + "(X)";
        }
    }
    public void PlayGame ()
    {
        deathCount.setTime(level.getActiveTime(SceneManager.GetActiveScene().buildIndex + 1));
        gm.setDeathCount(level.getActiveDeaths(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int l)
    {
        gm.setDeathCount(level.getActiveDeaths(l));
        deathCount.setTime(level.getActiveTime(l));
        SceneManager.LoadScene(l);
        if (l == 0)
        {
            SaveGame();
        }
    }

    public void SetSkin(int num)
    {
        skin = num;
        SaveGame();
    }

    public static int GetSkin()
    {
        return skin;
    }

    public void controls()
    {
        if (Input.GetJoystickNames().Length != 0)
        {
            controlsMenu.SetActive(true);
        }
        else
        {
            cControlsMenu.SetActive(true);
        }
    }

    public void Exit()
    {
        SaveGame();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void deleteSave()
    {
        File.Delete(Application.persistentDataPath + user + "/gamesave.sav");
        level.clear();
        sa.resetAll();
        Start();
    }

    public void unlockAll()
    {
        unlocked = true;
        Start();
    }

    public void relockAll()
    {
        unlocked = false;
        Start();
    }

    public static void updateButtons(UnityEngine.UI.Button[] buttons, bool unlocked)
    {
        if (unlocked == false) {
            int max = level.getMaxLevel(false) + 1;
            char[] MyChar = { 'L', 'e', 'v', 'e', 'l' };
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].name.Contains("Level"))
                {
                    string levelNum = buttons[i].name.TrimStart(MyChar);
                    int num = Int16.Parse(levelNum);
                    if (num <= max)
                    {
                        buttons[i].interactable = true;
                    }
                    else
                    {
                        buttons[i].interactable = false;
                    }
                }
                if (buttons[i].name == "Skin1")
                {
                    if(Achievement.getLength() == 15)
                    {
                        buttons[i].interactable = true;
                    }
                    else
                    {
                        buttons[i].interactable = false;
                    }
                }
                if (buttons[i].name == "Skin2")
                {
                    if (Achievement.getUnlocked(13))
                    {
                        buttons[i].interactable = true;
                    }
                    else
                    {
                        buttons[i].interactable = false;
                    }
                }
                if (buttons[i].name == "Skin3")
                {
                    if (Achievement.getUnlocked(8))
                    {
                        buttons[i].interactable = true;
                    }
                    else
                    {
                        buttons[i].interactable = false;
                    }
                }
            }
        }
        else {
             for (int i = 0; i < buttons.Length; i++) {
                 if (buttons[i].name.Contains("Level")) {
                     buttons[i].interactable = true;
                 }
             }
         }
    }

    public void SaveGame()
    {
        saveGame save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + user);
        FileStream file = File.Create(Application.persistentDataPath + user + "/gamesave.sav");
        bf.Serialize(file, save);
        file.Close();
    }
    private saveGame CreateSaveGameObject()
    {
        saveGame save = new saveGame();
        for (int i = 0; i < level.numLevels(); i++)
        {
            List<float> temp = new List<float>();
            if (level.getActiveIndex(i))
            {
                temp.Add(level.getLevelNum(i));
                temp.Add(level.getActiveDeaths(level.getLevelNum(i)));
                temp.Add(1);
                temp.Add(level.getActiveTime(level.getLevelNum(i)));

            }
            else
            {
                temp.Add(level.getLevelNum(i));
                temp.Add(level.getLevelDeaths(level.getLevelNum(i)));
                temp.Add(0);
                temp.Add(level.getLevelTime(level.getLevelNum(i)));
            }
            save.levelSave.Add(temp);
        }
        save.achievementSave = Achievement.getList();
        save.optionsSave.Add(options.getSFXVolume());
        save.optionsSave.Add(options.getMusicVolume());
        if (options.getIsOn())
        {
            save.optionsSave.Add(1f);
        }
        else
        {
            save.optionsSave.Add(0f);
        }
        save.skin = skin;
        return save;
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + user + "/gamesave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + user + "/gamesave.sav", FileMode.Open);
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
                Achievement achievement = new Achievement(i);
            }
            options.SetSoundEffectsVolume(save.optionsSave[0]);
            options.SetMusicVolume(save.optionsSave[1]);
            if (save.optionsSave[2] == 1)
            {
                options.Toggle(true);
            }
            else
            {
                options.Toggle(false);
            }
            skin = save.skin;
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void setPractice(bool prac)
    {
        practice = prac;
    }

    public static bool getPractice()
    {
        return practice;
    }
}
