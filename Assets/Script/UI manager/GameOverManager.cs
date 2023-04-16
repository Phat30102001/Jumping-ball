using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI score,highScore;

    // Start is called before the first frame update
    void Start()
    {   
        // score is the current score in this run
        score.text = GameManager.instance.Score.text;
        UpdateHighScore();
        
        // display score to UI
        highScore.text = PlayerPrefs.GetInt(PrefKey.HighScore.ToString()).ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateHighScore() 
    { 
        //GameManager.instance.playfabManager.GetPlayerStatistics();

        GameManager.instance.playfabManager.SendLeaderboard(PlayerPrefs.GetInt(PrefKey.HighScore.ToString()));
        
        if (PlayerPrefs.GetInt(PrefKey.HighScore.ToString()) >= int.Parse(score.text)) return;

        // update highscore for offline mode
        PlayerPrefs.SetInt(PrefKey.HighScore.ToString(), int.Parse(score.text));
        // update highscore for online mode
        

       


    }
}
