using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public GameState state;

    public static GameManager instance;

    public GameObject mainMenu;
    public Player player;
    public int startingPlatform;
    public Platform[] platformPref;
    public float minYspawnPos, maxYspawnPos;
    public GameObject platformCollider, platformManager;

    [SerializeField] private Platform _lastPlatformSpawned;
    private List<int> _platformLandedId;
    private int _score;
    private float _halfCamSizeX;

    public Platform LastPlatformSpawned { get => _lastPlatformSpawned; set => _lastPlatformSpawned = value; }
    public List<int> PlatformLandedId { get => _platformLandedId; set => _platformLandedId = value; }
    public int Score { get => _score;}

    private void Awake()
    {
        instance= this;
        PlatformLandedId= new List<int>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _halfCamSizeX=player.GetCamWidth()-(platformCollider.transform.localScale.x * platformCollider.GetComponent<BoxCollider2D>().size.x/2);
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
                Invoke("PlatformInit", 0.5f);
                break;

            case GameState.PLAYABLE:
                player.Jumping();
                //Debug.Log("first jump");
                break;

            case GameState.END:
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
        float disBetweenPlatform=Random.Range(minYspawnPos,maxYspawnPos);
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
        for(int i = 0; i < startingPlatform; i++)
        {
            SpawnPlatform();
        }
    }
}
