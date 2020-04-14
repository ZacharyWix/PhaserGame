using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class deathStats : MonoBehaviour
{
    public TextMeshProUGUI W1L1, W1L2, W1L3, W1L4, W1L5, W1L6, W1L7, W1L8, W1L9, W1L10;
    public TextMeshProUGUI W2L1, W2L2, W2L3, W2L4, W2L5, W2L6, W2L7, W2L8, W2L9, W2L10;
    public TextMeshProUGUI W3L1, W3L2, W3L3, W3L4, W3L5, W3L6, W3L7, W3L8, W3L9, W3L10;
    public TextMeshProUGUI W1T1, W1T2, W1T3, W1T4, W1T5, W1T6, W1T7, W1T8, W1T9, W1T10;
    public TextMeshProUGUI W2T1, W2T2, W2T3, W2T4, W2T5, W2T6, W2T7, W2T8, W2T9, W2T10;
    public TextMeshProUGUI W3T1, W3T2, W3T3, W3T4, W3T5, W3T6, W3T7, W3T8, W3T9, W3T10;
    // Start is called before the first frame update
    void Start()
    {
        updateDeathStats();
    }

    public void updateDeathStats(){
        W1L1.text = getDeathText(1);
        W1L2.text = getDeathText(2);
        W1L3.text = getDeathText(3);
        W1L4.text = getDeathText(4);
        W1L5.text = getDeathText(5);
        W1L6.text = getDeathText(6);
        W1L7.text = getDeathText(7);
        W1L8.text = getDeathText(8);
        W1L9.text = getDeathText(9);
        W1L10.text = getDeathText(10);
        W2L1.text = getDeathText(11);
        W2L2.text = getDeathText(12);
        W2L3.text = getDeathText(13);
        W2L4.text = getDeathText(14);
        W2L5.text = getDeathText(15);
        W2L6.text = getDeathText(16);
        W2L7.text = getDeathText(17);
        W2L8.text = getDeathText(18);
        W2L9.text = getDeathText(19);
        W2L10.text = getDeathText(20);
        W3L1.text = getDeathText(21);
        W3L2.text = getDeathText(22);
        W3L3.text = getDeathText(23);
        W3L4.text = getDeathText(24);
        W3L5.text = getDeathText(25);
        W3L6.text = getDeathText(26);
        W3L7.text = getDeathText(27);
        W3L8.text = getDeathText(28);
        W3L9.text = getDeathText(29);
        W3L10.text = getDeathText(30);
        W1T1.text = getTimeText(1);
        W1T2.text = getTimeText(2);
        W1T3.text = getTimeText(3);
        W1T4.text = getTimeText(4);
        W1T5.text = getTimeText(5);
        W1T6.text = getTimeText(6);
        W1T7.text = getTimeText(7);
        W1T8.text = getTimeText(8);
        W1T9.text = getTimeText(9);
        W1T10.text = getTimeText(10);
        W2T1.text = getTimeText(11);
        W2T2.text = getTimeText(12);
        W2T3.text = getTimeText(13);
        W2T4.text = getTimeText(14);
        W2T5.text = getTimeText(15);
        W2T6.text = getTimeText(16);
        W2T7.text = getTimeText(17);
        W2T8.text = getTimeText(18);
        W2T9.text = getTimeText(19);
        W2T10.text = getTimeText(20);
        W3T1.text = getTimeText(21);
        W3T2.text = getTimeText(22);
        W3T3.text = getTimeText(23);
        W3T4.text = getTimeText(24);
        W3T5.text = getTimeText(25);
        W3T6.text = getTimeText(26);
        W3T7.text = getTimeText(27);
        W3T8.text = getTimeText(28);
        W3T9.text = getTimeText(29);
        W3T10.text = getTimeText(30);
    }

    public string getDeathText(int num) {
        string text = "X";
        if(level.getLevelDeaths(num) != -1) {
            text = level.getLevelDeaths(num).ToString();
        }
        return text;
    }

    public string getTimeText(int num)
    {
        string text = "X";
        if (level.getLevelTime(num) != -1)
        {
            text = setupTimeString(level.getLevelTime(num));
        }
        return text;
    }

    public string setupTimeString(float timeIn)
    {
        int timeInt = (int)timeIn;
        float seconds = timeIn % 60;
        seconds = (float)Math.Round(seconds * 100f) / 100f;
        int minutes = (timeInt / 60) % 60;
        int hours = (timeInt / 3600);
        string second;
        string temp;
        if (seconds < 10)
        {
            if (hours < 1)
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
            if (hours < 1)
            {
                second = seconds.ToString();
            }
            else
            {
                int secInt = (int)seconds;
                second = secInt.ToString();
            }
        }
        string min;
        if (minutes < 10 && hours > 0)
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
}
