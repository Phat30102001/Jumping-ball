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
        
        score.text = GameManager.instance.Score.text;
        UpdateHighScore();
        
        highScore.text = PlayerPrefs.GetInt(PrefKey.HighScore.ToString()).ToString();

        GameManager.instance.playfabManager.SendLeaderboard(int.Parse(highScore.text));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateHighScore() 
    { 

    //{Debug.Log(PlayerPrefs.GetInt(PrefKey.HighScore.ToString())+"     "+ int.Parse(score.text));
        if (PlayerPrefs.GetInt(PrefKey.HighScore.ToString()) >= int.Parse(score.text)) return;

        
        PlayerPrefs.SetInt(PrefKey.HighScore.ToString(), int.Parse(score.text));

        
    }
}
