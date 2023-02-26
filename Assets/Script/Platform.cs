using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int _id;
    //protected Rigidbody2D _rb;
    protected Player _player;

    public int Id { get => _id; set => _id = value; }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject;
        //player.GetComponent<Rigidbody2D>().velocity = new Vector2(_rb.velocity.x,0);
        if (GameManager.instance.state != GameState.PLAYABLE) return;
        if (player.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            if (AudioManager.instance)
                AudioManager.instance.PlaySound(SoundName.Jump.ToString());
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up*GameManager.instance.player.JumpingForce;
            
        }
    }



    public virtual void PlatformAction()
    {

    }
}
public class Song
{
    private string name;
    public Song NextSong { get; set; }
    public Song(string name)
    {
        this.name = name;
    }
    public bool IsRepeatingPlaylist()
    {
        if (this.NextSong == null) return false;
        else
            return true;
    }
    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Take me to your heart");
        first.NextSong = second;
        second.NextSong = first;
        Debug.Log(first.IsRepeatingPlaylist());
    }
}