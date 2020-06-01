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
    public TextMeshProUGUI W1D1, W1D2, W1D3, W1D4, W1D5, W1D6, W1D7, W1D8, W1D9, W1D10;
    public TextMeshProUGUI W2D1, W2D2, W2D3, W2D4, W2D5, W2D6, W2D7, W2D8, W2D9, W2D10;
    public TextMeshProUGUI W3D1, W3D2, W3D3, W3D4, W3D5, W3D6, W3D7, W3D8, W3D9, W3D10;
    public TextMeshProUGUI W1L, W2L, W3L;
    public TextMeshProUGUI W1T, W2T, W3T;
    public TextMeshProUGUI W1D, W2D, W3D;
    public TextMeshProUGUI TD, TT, TTD, Levels;
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
        W1D1.text = getDecimalText(1);
        W1D2.text = getDecimalText(2);
        W1D3.text = getDecimalText(3);
        W1D4.text = getDecimalText(4);
        W1D5.text = getDecimalText(5);
        W1D6.text = getDecimalText(6);
        W1D7.text = getDecimalText(7);
        W1D8.text = getDecimalText(8);
        W1D9.text = getDecimalText(9);
        W1D10.text = getDecimalText(10);
        W2D1.text = getDecimalText(11);
        W2D2.text = getDecimalText(12);
        W2D3.text = getDecimalText(13);
        W2D4.text = getDecimalText(14);
        W2D5.text = getDecimalText(15);
        W2D6.text = getDecimalText(16);
        W2D7.text = getDecimalText(17);
        W2D8.text = getDecimalText(18);
        W2D9.text = getDecimalText(19);
        W2D10.text = getDecimalText(20);
        W3D1.text = getDecimalText(21);
        W3D2.text = getDecimalText(22);
        W3D3.text = getDecimalText(23);
        W3D4.text = getDecimalText(24);
        W3D5.text = getDecimalText(25);
        W3D6.text = getDecimalText(26);
        W3D7.text = getDecimalText(27);
        W3D8.text = getDecimalText(28);
        W3D9.text = getDecimalText(29);
        W3D10.text = getDecimalText(30);
        W1L.text = getWorldDeathText(1);
        W2L.text = getWorldDeathText(2);
        W3L.text = getWorldDeathText(3);
        W1T.text = getWorldTimeText(1);
        W2T.text = getWorldTimeText(2);
        W3T.text = getWorldTimeText(3);
        W1D.text = getWorldDecimalText(1);
        W2D.text = getWorldDecimalText(2);
        W3D.text = getWorldDecimalText(3);
        TD.text = level.getTotalDeaths().ToString();
        TT.text = getTotalTime();
        TTD.text = getTotalDecimals();
        Levels.text = level.getMaxLevel(false).ToString() + "/30";
        
    }

    public string getDeathText(int num) {
        string text = "X";
        if(level.getLevelDeaths(num) != -1) {
            text = level.getLevelDeaths(num).ToString();
        }
        return text;
    }

    public string getWorldDeathText(int num)
    {
        string text = "X";
        text = level.getWorldDeaths(num).ToString();
        return text;
    }

    public string getWorldTimeText(int num)
    {
        return getTimeHelper(level.getWorldTime(num));
    }

    public string getWorldDecimalText(int num)
    {
        return getDecimalHelper(level.getWorldTime(num));
    }

    public string getTimeText(int num)
    {
        string seconds = "X" + "\u00A0\u00A0";
        if (level.getLevelTime(num) != -1)
        {
            return getTimeHelper(level.getLevelTime(num));
        }
        else
        {
            return seconds;
        }
    }

    public string getTotalTime()
    {
        float t = level.getTotalTime();
        string temp = getTimeHelper(t);
        if (temp == "X")
        {
            temp = "0:00";
        }
        return temp;
    }
    public string getTotalDecimals()
    {
        return getDecimalHelper(level.getTotalTime());
    }

    public string getTimeHelper(float num)
    {
        string text = "X";
        string seconds = "X" + "\u00A0\u00A0";
        text = setupTimeString(num);
        if (text.Contains("."))
        {
            int index = text.IndexOf(".");
            seconds = text.Substring(0, index + 1);
        }
        else if (num < 3600)
        {
            seconds = text + ".";
        }
        else
        {
            seconds = text;
        }
        return seconds;
    }

    public string getDecimalText(int num)
    {
        string decimals = "";
        if(level.getLevelTime(num) != -1)
        {
            return getDecimalHelper(level.getLevelTime(num));
        }
        else
        {
            return decimals;
        }
    }
    public string getDecimalHelper(float num)
    {
        string text = "X";
        string decimals = "";
        text = setupTimeString(num);
        if (text.Contains("."))
        {
            int index = text.IndexOf(".");
            decimals = text.Substring(index + 1);
            if (decimals.Length == 1)
            {
                decimals += "0";
            }
        }
        else if (num < 3600)
        {
            decimals = "00";
        }
        else
        {
            decimals = "";
        }
        return decimals;
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
