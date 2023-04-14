using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    // get the platform id player landed
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameTag.Platform.ToString()))
        {
            //isOnGround = true;
            var platformLand = collision.gameObject.GetComponent<Platform>();
            GameManager.instance.player.PlatformLanded = platformLand;

        }
    }


}
