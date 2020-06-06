using UnityEngine;
using Steamworks;
using System.Collections;
using System.Threading;
using System;

public class SteamLeaderboards : MonoBehaviour
{
    private const string s_leaderboardName = "Time";
    private const ELeaderboardUploadScoreMethod s_leaderboardMethod = ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest;
    private const ELeaderboardDataRequest s_leaderboardRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal;

    private static SteamLeaderboard_t s_currentLeaderboard;
    private static SteamLeaderboardEntries_t s_leaderboardEntries;
    private static LeaderboardEntry_t s_leaderboard;
    private static bool s_initialized = false;
    private static CallResult<LeaderboardFindResult_t> m_findResult = new CallResult<LeaderboardFindResult_t>();
    private static CallResult<LeaderboardScoreUploaded_t> m_uploadResult = new CallResult<LeaderboardScoreUploaded_t>();
    private static CallResult<LeaderboardScoresDownloaded_t> m_downloadResult = new CallResult<LeaderboardScoresDownloaded_t>();

    public LeaderboardMenu lb;


    public static void UpdateScore(float score)
    {
        if (!s_initialized)
        {
            UnityEngine.Debug.Log("Can't upload to the leaderboard because isn't loaded yet");
        }
        else
        {
            UnityEngine.Debug.Log("uploading score(" + score + ") to steam leaderboard(" + s_leaderboardName + ")");
            SteamAPICall_t hSteamAPICall = SteamUserStats.UploadLeaderboardScore(s_currentLeaderboard, s_leaderboardMethod, (int)score, null, 0);
            m_uploadResult.Set(hSteamAPICall, OnLeaderboardUploadResult);
        }
    }

    public static void DownloadLeaderBoard()
    {
        SteamAPICall_t hSteamAPICall = SteamUserStats.DownloadLeaderboardEntries(s_currentLeaderboard, s_leaderboardRequest, 0, 25);
        m_downloadResult.Set(hSteamAPICall, OnLeaderBoardDownloadResult);
    }

    public static string[] getLeaderBoardIndex(int index)
    {
        int[] details = new int[5];
        string[] ret = new string[3];
        SteamUserStats.GetDownloadedLeaderboardEntry(s_leaderboardEntries, index, out s_leaderboard, details, 5);
        print("User ID: " + SteamFriends.GetFriendPersonaName(s_leaderboard.m_steamIDUser));
        SteamFriends.GetFriendPersonaName(s_leaderboard.m_steamIDUser);
        print("Rank: " + s_leaderboard.m_nGlobalRank);
        print("Score: " + s_leaderboard.m_nScore);
        print("Details: " + s_leaderboard.m_cDetails);
        print("huGC: " + s_leaderboard.m_hUGC);
        ret[0] = SteamFriends.GetFriendPersonaName(s_leaderboard.m_steamIDUser).ToString();
        ret[1] = s_leaderboard.m_nGlobalRank.ToString();
        ret[2] = s_leaderboard.m_nScore.ToString();
        return ret;
    }

    public static void Init()
    {
        SteamAPICall_t hSteamAPICall = SteamUserStats.FindLeaderboard(s_leaderboardName);
        m_findResult.Set(hSteamAPICall, OnLeaderboardFindResult);
        InitTimer();
    }

    static private void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool failure)
    {
        UnityEngine.Debug.Log("STEAM LEADERBOARDS: Found - " + pCallback.m_bLeaderboardFound + " leaderboardID - " + pCallback.m_hSteamLeaderboard.m_SteamLeaderboard);
        s_currentLeaderboard = pCallback.m_hSteamLeaderboard;
        s_initialized = true;
    }

    static private void OnLeaderboardUploadResult(LeaderboardScoreUploaded_t pCallback, bool failure)
    {
        UnityEngine.Debug.Log("STEAM LEADERBOARDS: failure - " + failure + " Completed - " + pCallback.m_bSuccess + " NewScore: " + pCallback.m_nGlobalRankNew + " Score " + pCallback.m_nScore + " HasChanged - " + pCallback.m_bScoreChanged);
    }

    static private void OnLeaderBoardDownloadResult(LeaderboardScoresDownloaded_t pCallback, bool failure)
    {
        s_leaderboardEntries = pCallback.m_hSteamLeaderboardEntries;
        print("Size: " + pCallback.m_cEntryCount);
        for (int i = 0; i < pCallback.m_cEntryCount; i++)
        {
            getLeaderBoardIndex(i);
        }
    }

    private static Timer timer1;
    public static void InitTimer()
    {
        timer1 = new Timer(timer1_Tick, null, 0, 1000);
    }

    private static void timer1_Tick(object state)
    {
        SteamAPI.RunCallbacks();
    }
}
