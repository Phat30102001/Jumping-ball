using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayfabManager:MonoBehaviour
{
    public static PlayfabManager instance;

    public GameObject leaderboardWindow;
    public GameObject rowPrefab;
    public Transform rowsParent;
    public TMP_InputField nameInput;


    private void Awake()
    {
        instance = this;    
    }

    // auto login when lanch the game
    void Start()
    {
        Login();
    }

    //if the device haven't has a account, create it with that device id (unique)
    private void Login()
    {
        //call api
        var request = new LoginWithCustomIDRequest {
            CustomId=SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request,OnDisplayNameUpdate, OnError);
    }

    //update highscore when game over
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName=PlayfabKey.Score.ToString(),Value= score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboard, OnError);
    }

    //get 5 best player display on leaderboard
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = PlayfabKey.Score.ToString(),
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);

    }

    //public void GetPlayerStatistics()
    //{
    //    PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest
    //    {
    //        StatisticNames = new List<string> { PlayfabKey.Score.ToString() } 
    //    }, OnGetPlayerStatisticsSuccess, OnGetPlayerStatisticsFailure);
    //}

    // get account's name on successful login
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Success login/account created");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        //if (name == null)
        //    nameWindow.SetActive(true);
        //else
        //{
        //    leaderboardWindow.SetActive(true);
        //    GetLeaderboard();
        //}


    }

    //display in console if something failed
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/ creating account");
        Debug.Log(error.GenerateErrorReport());
    }

    //void OnGetPlayerStatisticsSuccess(GetPlayerStatisticsResult result)
    //{

    //    var playerScoreStat = result.Statistics.Find(x => x.StatisticName == PlayfabKey.Score.ToString());
    //    if (playerScoreStat != null)
    //    {

    //        int playerScore = playerScoreStat.Value;
    //        Debug.Log("Player Score: " + playerScore);
    //    }
    //    else
    //    {

    //        Debug.Log("Player does not have a score yet.");
    //    }
    //}

    //void OnGetPlayerStatisticsFailure(PlayFabError error)
    //{
    //    Debug.Log("Get Player Statistics failed: " + error.ErrorMessage);
    //}

    void OnLeaderboard(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Success update leaderboard");
    }

    void OnLeaderboardGet(GetLeaderboardResult leaderboardResult)
    {
        foreach(var item in leaderboardResult.Leaderboard)
        {
            GameObject row = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] text = row.GetComponentsInChildren<TextMeshProUGUI>();
            text[0].text=(item.Position+1).ToString();

            string name;
            if(item.DisplayName!= null)
                name = item.DisplayName;
            else
                name=item.PlayFabId.ToString();

            text[1].text=name;
            text[2].text=item.StatValue.ToString();


            //Debug.Log(string.Format("Rank: {0},ID: {1}, Score: {2}", item.Position, item.PlayFabId, item.StatValue));
            //Debug.Log( item.Position + "\t " + item.PlayFabId + "\t " + item.StatValue);
        }
    }   

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name");
    }


}
