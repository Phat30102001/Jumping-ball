using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Camera mainCamera;
    public GroundCheck groundCheck;

    private Rigidbody2D _rb;
    
    //public Transform groundCheck;
    //public LayerMask groundLayer;
    [SerializeField] private float _jumpingForce;

    private Platform _platformLanded;

    public Platform PlatformLanded { get => _platformLanded; set => _platformLanded = value; }

    


    private void Awake()
    {

        instance = this;
        _rb= GetComponent<Rigidbody2D>();
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

    public void Jumping()
    {
        if (!groundCheck.isOnGround || _rb.velocity.y > 0) return;
        if (GameManager.instance.state == GameState.PLAYABLE)
        {
            //if (PlayerBehaviour.instace.state != PlayerState.IDLE) return;
            Debug.Log("jump");
            //_rb.AddForce(Vector2.up * _jumpingForce, ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(rb.velocity.x,jumpingForce));
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingForce);
            groundCheck.isOnGround = false;
        }

    }

    public float GetCamWidth()
    {

        float halfWidth = mainCamera.orthographicSize;
        return mainCamera.aspect * halfWidth;
    }
}
