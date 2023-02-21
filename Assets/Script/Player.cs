using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Camera mainCamera;
    public GroundCheck groundCheck;

    private Rigidbody2D _rb;

    //public Transform groundCheck;
    //public LayerMask groundLayer;
    [SerializeField] private float _jumpingForce;

    private Platform _platformLanded;

    public Platform PlatformLanded { get => _platformLanded; set => _platformLanded = value; }
    public float JumpingForce { get => _jumpingForce;}

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //kBCounter = unit.KBTotalTime;

        //// facing direction
        //if (!isFacingRight && horizontal > 0f)
        //{
        //    FlipSprite();
        //}
        //else if (isFacingRight && horizontal < 0f)
        //{
        //    FlipSprite();
        //}
        //if (rb.velocity.y > 0f) return;
        //if (IsGrounded()&&GameManager.instance.state==GameState.PLAYABLE)
        //Jumping();


    }






    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //var player = collision.gameObject;
    //    //player.GetComponent<Rigidbody2D>().velocity = new Vector2(_rb.velocity.x, 0);

    //    //if (GameManager.instance.state != GameState.PLAYABLE || !collision.gameObject.CompareTag(GameTag.Player.ToString())) return;
    //    //if (collision.relativeVelocity.y <= 0)
    //    {
    //        Jump();
    //        //player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);
    //    }
    //}


    //public void Jumping()
    //{

    //    if (GameManager.instance.state == GameState.PLAYABLE)
    //    {
    //        if (_rb.velocity.y < 0) return;
    //        if (!groundCheck.isOnGround) return;
    //        //if (PlayerBehaviour.instace.state != PlayerState.IDLE) return;
    //        //Debug.Log("jump");
    //        //_rb.AddForce(Vector2.up * _jumpingForce);
    //        //rb.AddForce(new Vector2(rb.velocity.x,jumpingForce));
    //        _rb.velocity = new Vector2(_rb.velocity.x, JumpingForce);
    //        groundCheck.isOnGround = false;
    //    }
    //    if (_rb.velocity.y <= 0)
    //    {
    //        _rb.velocity = Vector3.up *  JumpingForce;
    //        Debug.Log("jump");
    //    }

    //}


    public float GetCamWidth()
    {

        float halfWidth = mainCamera.orthographicSize;
        return mainCamera.aspect * halfWidth;
    }

}
