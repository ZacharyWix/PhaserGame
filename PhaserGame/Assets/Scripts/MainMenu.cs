using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public deathStats deathStat;
    private phaserManager gm;
    public Canvas canvas;
    private void Start()
    {
        deathStat = new deathStats();
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Button[] buttons = canvas.GetComponentsInChildren<Button>(true);
            updateButtons(buttons);
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
        if (l == 0) {
            deathStat.updateDeathStats();
        }
        gm.setDeathCount(level.getActiveDeaths(l));
        SceneManager.LoadScene(l);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

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
