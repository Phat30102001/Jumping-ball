using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    //public GameObject rowPrefab;
    //public Transform rowsParent;

    private void Start()
    {
        DisplayLeaderboardInfo();
    }

    public void DisplayLeaderboardInfo()
    {
        PlayfabManager.instance.GetLeaderboard();
    }
}
