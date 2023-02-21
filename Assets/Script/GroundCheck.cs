using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //public bool isOnGround;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameTag.Platform.ToString()))
        {
            //isOnGround = true;
            var platformLand = collision.gameObject.GetComponent<Platform>();
            GameManager.instance.player.PlatformLanded = platformLand;


            //if (GameManager.instance.state != GameState.PLAYABLE) return;
            //Debug.Log("jumping");
        }
    }


}
