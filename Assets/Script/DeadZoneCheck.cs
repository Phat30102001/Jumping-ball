using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneCheck : MonoBehaviour
{
    private void Update()
    {
        
    }

    //destroy platform when it out of camera to reduce memory usage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Player.ToString()))
        {
            GameManager.instance.UpdateGameState(GameState.END);
        }
        if (collision.CompareTag(GameTag.Platform.ToString()))
        {
            Destroy(collision.gameObject);
        }
    }
}
