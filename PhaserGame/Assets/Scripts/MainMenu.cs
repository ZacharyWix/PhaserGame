using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
<<<<<<< Updated upstream
=======
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using System.Globalization;
>>>>>>> Stashed changes

public class MainMenu : MonoBehaviour
{
    private phaserManager gm;
    public Canvas canvas;
<<<<<<< Updated upstream
    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Button[] buttons = canvas.GetComponentsInChildren<Button>(true);
            updateButtons(buttons);
=======
    private bool unlocked = false;
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
>>>>>>> Stashed changes
        }
    }
    public void PlayGame ()
    {
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
        SceneManager.LoadScene(l);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
<<<<<<< Updated upstream
=======
    public void deleteSave()
    {
        File.Delete(Application.persistentDataPath + user + "/gamesave.sav");
        level.clear();
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
>>>>>>> Stashed changes

    public static void updateButtons(UnityEngine.UI.Button[] buttons)
    {
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
        }
    }
}
