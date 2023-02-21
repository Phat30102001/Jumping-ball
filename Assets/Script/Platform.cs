using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int _id;
    protected Rigidbody2D _rb;
    protected Player _player;

    public int Id { get => _id; set => _id = value; }

    protected virtual void Awake()
    {
        _rb= GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject;
        //player.GetComponent<Rigidbody2D>().velocity = new Vector2(_rb.velocity.x,0);
        if (GameManager.instance.state != GameState.PLAYABLE) return;
        if (player.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            //player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up*GameManager.instance.player.JumpingForce;
        }
    }



    public virtual void PlatformAction()
    {

    }
}
