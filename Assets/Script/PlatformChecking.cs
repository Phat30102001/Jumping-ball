using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChecking : MonoBehaviour
{

    //check if the final platform spawned touch this game object, the game will spawn more platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Platform.ToString()))
        {
            //Debug.Log("Detected");
            var platformTriggered = collision.GetComponent<Platform>();
            if(platformTriggered.Id<GameManager.instance.LastPlatformSpawned.Id) return;
            GameManager.instance.SpawnPlatform();
        }

        

    }
}
