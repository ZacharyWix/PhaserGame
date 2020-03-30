using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public deathStats deathStat;
    private phaserManager gm;
    public Canvas canvas;
    public bool unlocked = false;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Button[] buttons = canvas.GetComponentsInChildren<Button>(true);
            updateButtons(buttons, unlocked);
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
        if (l == 0) {
            deathStat.updateDeathStats();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void deleteSave()
    {
        File.Delete(Application.persistentDataPath + "/gamesave.save");
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
}
