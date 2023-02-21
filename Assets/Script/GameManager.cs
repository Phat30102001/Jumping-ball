using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public GameState state;

    public static GameManager instance;

    [SerializeField] private GameObject mainMenu,gameOver;
    [SerializeField] private TextMeshProUGUI _score;
    public Player player;
    public int startingPlatform;
    public Platform[] platformPref;
    [SerializeField] private float minYspawnPos, maxYspawnPos;
    public GameObject platformCollider, platformManager;

    [SerializeField] private Platform _lastPlatformSpawned;
    private List<int> _platformLandedId;
    private int _highgestPlatformLanded;
    private float _halfCamSizeX;

    [Range(0,2)]
    [SerializeField] private float time;

    public Platform LastPlatformSpawned { get => _lastPlatformSpawned; set => _lastPlatformSpawned = value; }
    public List<int> PlatformLandedId { get => _platformLandedId; set => _platformLandedId = value; }
    public int HighgestPlatformLanded { get => _highgestPlatformLanded; set => _highgestPlatformLanded = value; }

    private void Awake()
    {
        instance= this;
        PlatformLandedId= new List<int>();
    }
    // Start is called before the first frame update
    void Start()
    {
        HighgestPlatformLanded = 0;
        _halfCamSizeX=player.GetCamWidth()-(platformCollider.transform.localScale.x * platformCollider.GetComponent<BoxCollider2D>().size.x/2);
        UpdateGameState(GameState.START);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = time;
        _score.text = GetScore().ToString();
        //Debug.Log(GetScore());
    }
    public int GetScore()
    {
        if (!player.PlatformLanded || player.PlatformLanded.Id < HighgestPlatformLanded) return HighgestPlatformLanded;
        
        HighgestPlatformLanded = player.PlatformLanded.Id;
        return HighgestPlatformLanded;
    }
    public void UpdateGameState(GameState newstate)
    {
        state= newstate;

        switch(state)
        {
            case GameState.START:
                Invoke("PlatformInit", 0.2f);
                break;

            case GameState.PLAYABLE:
                //player.Jumping();
                //Debug.Log("first jump");
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameManager.instance.player.JumpingForce);
                break;

            case GameState.END:
                GameOver();
                break;


        }
    }

    public void PlayButton()
    {
        UpdateGameState(GameState.PLAYABLE);
        mainMenu.SetActive(false);   
    }

    public void SpawnPlatform()
    {
        if (!player || platformPref == null || platformPref.Length <= 0) return;
        float spawnPosX = Random.Range(-_halfCamSizeX,_halfCamSizeX);
        float disBetweenPlatform= Random.Range(minYspawnPos,maxYspawnPos);
        float spawnPosY = LastPlatformSpawned.transform.position.y + disBetweenPlatform;
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0f);

        int randomId=Random.Range(0,platformPref.Length);
        var platform = platformPref[randomId];
        
        if (!platform) return;
        
        var platformClone=Instantiate(platform,spawnPos,Quaternion.identity);
        platformClone.transform.parent= platformManager.transform;
        platformClone.Id = LastPlatformSpawned.Id + 1;
        LastPlatformSpawned =platformClone;
    }

    private void PlatformInit()
    {
        LastPlatformSpawned = player.PlatformLanded;
        for (int i = 0; i < startingPlatform; i++)
        {
            SpawnPlatform();
        }
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
    }
}
