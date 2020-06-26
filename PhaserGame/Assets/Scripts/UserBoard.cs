using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UserBoard : MonoBehaviour
{
    private bool x = true;
    string y;
    int index;
    public ScrollRect scroll;
    public GameObject complete;
    // Start is called before the first frame update
    void Start()
    {
        if(level.getLevelDeaths(30) != -1)
        {
            complete.SetActive(false);
        }
        else
        {
            complete.SetActive(true);
        }
        topRanked();
    }

    // Update is called once per frame
    void Update()
    {
        if (!x)
        {
            if (SteamLeaderboards.getUserBoard()[0].Length <= 0)
            {
                y = SteamLeaderboards.getUserBoard()[1];
                index = Int32.Parse(y);
                x = true;
                findRange(index);
            }
        }
    }

    public void userCentered()
    {
        print("centered");
        SteamLeaderboards.DownloadUserBoard();
        x = false;
    }
    
    public void topRanked()
    {
        print("top");
        SteamLeaderboards.DownloadLeaderBoard(0, 50);
        scroll.verticalNormalizedPosition = 1;
    }

    public void findRange(int n)
    {
        print(n);
        if (n < 25)
        {
            topRanked();
            if (n > 10)
            {
                scroll.verticalNormalizedPosition = 50 - n / 50;
            }
        }
        else
        {
            int min = n - 24;
            int max = n + 25;
            SteamLeaderboards.DownloadLeaderBoard(min, max);
            scroll.verticalNormalizedPosition = 0.5f;
        }
    }
}
