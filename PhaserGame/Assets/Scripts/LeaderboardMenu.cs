using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LeaderboardMenu : MonoBehaviour
{
    public deathStats deathStat;
    public TextMeshProUGUI rank, score, user;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        SteamLeaderboards.DownloadLeaderBoard();
        string obj = this.gameObject.name;
        char[] MyChar = { 'R', 'a', 'n', 'k'};
        obj = obj.TrimStart(MyChar);
        rank.text = obj;
        num = Int32.Parse(obj) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        updateStats();
    }

    public void updateStats()
    {
        string[] hi = SteamLeaderboards.getLeaderBoardIndex(num);
        if (hi[0].Length > 0)
        {
            user.text = hi[0];
            score.text = deathStat.setupTimeString(Int32.Parse(hi[2]));
        }
    }
}
