using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] hi = SteamLeaderboards.getLeaderBoardIndex(1);
        for (int i = 0; i < hi.Length; i++)
        {
            print("hi: " + hi[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
