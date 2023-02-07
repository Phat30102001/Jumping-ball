using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { START,PLAYABLE,END}
public class GameManager : MonoBehaviour
{

    public GameState state;

    public static GameManager instance;

    private void Awake()
    {
        instance= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.START);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGameState(GameState newstate)
    {
        state= newstate;

        switch(state)
        {
            case GameState.START: 
                break;

            case GameState.PLAYABLE: 
                break;

            case GameState.END:
                break;


        }
    }

    public void PlayButton()
    {
        UpdateGameState(GameState.PLAYABLE);
    }
}
