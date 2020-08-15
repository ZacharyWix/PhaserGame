using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Steamworks;
using UnityEngine.UI;


public class LeaderboardMenu : MonoBehaviour
{
    public Sprite normal;
    public Sprite highlight;
    Image image;
    public TextMeshProUGUI rank, score, user;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        string obj = this.gameObject.name;
        char[] MyChar = { 'R', 'a', 'n', 'k'};
        obj = obj.TrimStart(MyChar);
        num = Int32.Parse(obj) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamManager.getActive())
        {
            updateStats();
        }
    }

    public void updateStats()
    {
        string[] hi = { };
        if (UserBoard.getType() == 0)
        {
            hi = SteamLeaderboards.getLeaderBoardIndex(num);
        }
        if(UserBoard.getType() == 1)
        {
            hi = SpeedRunTimeLB.getLeaderBoardIndex(num);
        }
        if (UserBoard.getType() == 2)
        {
            hi = SpeedRunDeathsLB.getLeaderBoardIndex(num);
        }
        if (hi[0].Length > 0)
        {
            user.text = hi[0];
            if (user.text == SteamFriends.GetPersonaName())
            {
                image.sprite = highlight;
            }
            else
            {
                image.sprite = normal;
            }
            rank.text = hi[1];
            if (UserBoard.getType() != 2)
            {
                score.text = deathStats.setupTimeString(Int32.Parse(hi[2]));
            }
            else
            {
                score.text = hi[2];
            }
        }
        else
        {
            rank.text = (num + 1).ToString();
            score.text = "X";
            user.text = "Username";
            image.sprite = normal;
        }
    }
}
