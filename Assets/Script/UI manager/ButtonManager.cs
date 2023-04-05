using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Resume()
    {
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
