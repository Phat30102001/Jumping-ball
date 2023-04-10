using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public GameState state;

    public static GameManager instance;

    public GameObject mainMenu,gameOver,gamePlay;
    [SerializeField] private TextMeshProUGUI score;
    public Player player;
    public int startingPlatform;
    public Platform[] platformPref;
    [SerializeField] private float minYspawnPos, maxYspawnPos;
    public GameObject platformCollider, platformManager;
    public Transform leftPoint,rightPoint;
    public PlayfabManager playfabManager;

    [SerializeField] private Platform _lastPlatformSpawned;
    
    private Platform groundPlatform;
    private List<int> _platformLandedId;
    private int _highgestPlatformLanded;


    //[Range(0,2)]
    //[SerializeField] private float time;

    public Platform LastPlatformSpawned { get => _lastPlatformSpawned; set => _lastPlatformSpawned = value; }
    public List<int> PlatformLandedId { get => _platformLandedId; set => _platformLandedId = value; }
    public int HighgestPlatformLanded { get => _highgestPlatformLanded; set => _highgestPlatformLanded = value; }
    public TextMeshProUGUI Score { get => score; set => score = value; }

    private void Awake()
    {
        instance= this;
        PlatformLandedId= new List<int>();
        groundPlatform = GameObject.Find("GroundPlatform").GetComponent<Platform>();

    }
    // Start is called before the first frame update
    void Start()
    {


        HighgestPlatformLanded = 0;

        groundPlatform.transform.position = new Vector3(0f,-player.GetCamHeight(),0) ;
        float platformSpawnablePoint=player.GetCamWidth()-(platformCollider.transform.localScale.x * platformCollider.GetComponent<BoxCollider2D>().size.x/2);
        leftPoint.position = new Vector3(-platformSpawnablePoint, transform.position.y, 0f);
        rightPoint.position = new Vector3(platformSpawnablePoint, transform.position.y, 0f);
        UpdateGameState(GameState.START);
    }

    // Update is called once per frame
    void Update()
    {

        //Time.timeScale = time;
        Score.text = GetScore().ToString();
        //Debug.Log(GetScore());
    }
    public int GetScore()
    {
        if (player.PlatformLanded && player.PlatformLanded.Id > HighgestPlatformLanded)
        {
            HighgestPlatformLanded = player.PlatformLanded.Id;
            if (HighgestPlatformLanded % 15 == 0 && HighgestPlatformLanded != 0&& Time.timeScale<=2f)
                Time.timeScale += 0.05f;
        }
        
        
        return HighgestPlatformLanded;
    }
    public void UpdateGameState(GameState newstate)
    {
        state= newstate;

        switch(state)
        {
            case GameState.START:
                //AudioManager.instance.PlaySound("Background");


                break;

            case GameState.PLAYABLE:
                gamePlay.SetActive(true);
                Invoke("PlatformInit", 0.2f);
                if (AudioManager.instance)
                    AudioManager.instance.PlaySound(SoundName.Theme.ToString());
                Score.gameObject.SetActive(true);
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
        if (state != GameState.PLAYABLE) return;
        if (!player || platformPref == null || platformPref.Length <= 0) return;
        float spawnPosX = Random.Range(leftPoint.position.x, rightPoint.position.x);
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
        if (!player.PlatformLanded)
        {
            LastPlatformSpawned = groundPlatform;
        }
        else
            LastPlatformSpawned = player.PlatformLanded;
        for (int i = 0; i < startingPlatform; i++)
        {
            SpawnPlatform();
        }
    }

    private void GameOver()
    {
        if (AudioManager.instance)
        {
            AudioManager.instance.StopSound(SoundName.Theme.ToString());
            AudioManager.instance.PlaySound(SoundName.Gameover.ToString());
        }
           
        gameOver.SetActive(true);
    }
}
