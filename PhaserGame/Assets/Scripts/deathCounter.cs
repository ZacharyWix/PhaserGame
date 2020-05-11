using System.Collections;
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
    public TextMeshProUGUI timer;
    public TextMeshProUGUI decimals;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI bestDec;
    public TextMeshProUGUI bestTime1;
    public TextMeshProUGUI bestDec1;
    public TextMeshProUGUI complete;
    public pause pause;
    private bool paused = false;
    private bool finished;
    private float time;
    private int timeInt;
    private int hours;
    private int minutes;
    private float seconds;
    private phaserManager gm;

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        time = level.getActiveTime(SceneManager.GetActiveScene().buildIndex);
        finished = false;
        updateDeathCounter();
    }

    private void Update()
    {
        paused = pause.getPause();
        if (!paused && !finished)
        {
            time += Time.deltaTime;
        }
        string secondTemp = setupTimeString(time);
        if (secondTemp.Contains("."))
        {
            int index = secondTemp.IndexOf(".");
            timer.text = secondTemp.Substring(0, index + 1);
            decimals.text = secondTemp.Substring(index + 1);
            if (decimals.text.Length == 1)
            {
                decimals.text += "0";
            }
        }
        else if (time < 3600)
        {
            timer.text = secondTemp + ".";
            decimals.text = "00";
        }
        else
        {
            timer.text = secondTemp;
            decimals.text = "";
        }
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
        string thing = "";
        if (split.Length == 2)
        {
            if (split[1] != '0')
            {
                levelNum.text = "World " + (Convert.ToInt32(split[0].ToString()) + 1) + " Level " + split[1];
                thing = split[1].ToString();
            }
            else
            {
                levelNum.text = "World " + split[0] + " Level 10";
                thing = "10";
            }
        }
        else if (split.Length == 1)
        {
            levelNum.text = "World 1 Level " + split[0];
            thing = split[0].ToString();
        }
        complete.text = "Level " + thing + " Complete!";
        if (level.getLevelTime(SceneManager.GetActiveScene().buildIndex) != -1)
        {
            float preTime = level.getLevelTime(SceneManager.GetActiveScene().buildIndex);
            string thirdTemp = setupTimeString(preTime);
            if (thirdTemp.Contains("."))
            {
                int index = thirdTemp.IndexOf(".");
                bestTime.text = thirdTemp.Substring(0, index + 1);
                bestDec.text = thirdTemp.Substring(index + 1);
                if (bestDec.text.Length == 1)
                {
                    bestDec.text += "0";
                }
            }
            else if (time < 3600)
            {
                bestTime.text = thirdTemp + ".";
                bestDec.text = "00";
            }
            else
            {
                bestTime.text = thirdTemp;
                bestDec.text = "";
            }
        }
        else
        {
            bestTime.text = "X" + "\u00A0\u00A0\u00A0\u00A0";
            bestDec.text = "";
        }
        bestTime1.text = bestTime.text;
        bestDec1.text = bestDec.text;
    }

    public string setupTimeString(float timeIn)
    {
        timeInt = (int)timeIn;
        seconds = timeIn % 60;
        seconds = (float)Math.Round(seconds * 100f) / 100f;
        string second;
        minutes = (timeInt / 60) % 60;
        hours = (timeInt / 3600);
        string temp;
        if (seconds <  10)
        {
            if (time < 3600)
            {
                second = "0" + seconds;
            }
            else
            {
                second = "0" + (int)seconds;
            }
        }
        else
        {
            if (time < 3600)
            {
                second = seconds.ToString();
            }
            else
            {
                int secondInt = (int)seconds;
                second = secondInt.ToString();
            }
        }
        string min;
        if (minutes < 10)
        {
            min = "0" + minutes.ToString();
        }
        else
        {
            min = minutes.ToString();
        }
        
        if (hours > 0)
        {
            temp = hours.ToString() + ":" + min + ":" + second;
        }
        else
        {
            temp = min + ":" + second;
        }

        return temp;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            finished = true;
        }
    }

    public float getTime()
    {
        return time;
    }

    public void setTime(float timer)
    {
        time = timer;
    }
}
