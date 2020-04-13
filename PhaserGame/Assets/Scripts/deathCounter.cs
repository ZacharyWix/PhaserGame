﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class deathCounter : MonoBehaviour
{
    public TextMeshProUGUI deathCountText;
    public TextMeshProUGUI lowestDeathsText;
    public TextMeshProUGUI lowestDeathsText1;
    public TextMeshProUGUI totalDeathsText;
    public TextMeshProUGUI totalDeathsText1;
    public TextMeshProUGUI levelNum;

    private phaserManager gm;

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        updateDeathCounter();
    }

    public void updateDeathCounter()
    {
        deathCountText.text = gm.getDeathCount().ToString();
        if (level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex) != -1)
        {
            lowestDeathsText.text = level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex).ToString();
        }
        else
        {
            lowestDeathsText.text = "X";
        }
        totalDeathsText.text = level.getTotalDeaths().ToString();
        int d = 0;
        if (level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex) != -1)
        {
            d = level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex);
        }
        totalDeathsText.text = (level.getTotalDeaths() - d + gm.getDeathCount()).ToString();
        lowestDeathsText1.text = lowestDeathsText.text;
        totalDeathsText1.text = totalDeathsText.text;
        string number = SceneManager.GetActiveScene().buildIndex.ToString();
        char[] split = number.ToCharArray();

        if (split.Length == 2)
        {
            if (split[1] != '0')
            {
                levelNum.text = "World " + (Convert.ToInt32(split[0].ToString()) + 1) + " Level " + split[1];
            }
            else
            {
                levelNum.text = "World " + split[0] + " Level 10";
            }
        }
        else if (split.Length == 1)
        {
            levelNum.text = "World 1 Level " + split[0];
        }
    }
}
