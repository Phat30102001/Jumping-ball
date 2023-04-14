using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : Platform
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject;
        if (GameManager.instance.state != GameState.PLAYABLE) return;
        if (player.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            AudioManager.instance.PlaySound(SoundName.Jump.ToString());
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * GameManager.instance.player.JumpingForce;


            //deactive the platform after player land on it
            gameObject.SetActive(false);
        }
    }
}
