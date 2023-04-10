using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu, leaderboard;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        

    }
    public void OpenLeaderboard()
    {
        leaderboard.SetActive(true);

    }
    public void Resume()
    {
        leaderboard.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void Play()
    {
        GameManager.instance.UpdateGameState(GameState.PLAYABLE);
        GameManager.instance.mainMenu.SetActive(false);
    }
}
