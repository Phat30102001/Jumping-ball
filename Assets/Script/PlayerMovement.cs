using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    [SerializeField] private float jumpingForce;

    //check player facing side
    //private bool isFacingRight = true;


    private void Awake()
    {

        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jumping();

        
    }

    // auto jump once the game start (change state to PLAYABLE)
    public void Jumping()
    {
        if (rb.velocity.y > 0f) return;
        if (IsGrounded() && GameManager.instance.state == GameState.PLAYABLE)
        {
            //if (PlayerBehaviour.instace.state != PlayerState.IDLE) return;
            Debug.Log("jump");
            //rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(rb.velocity.x,jumpingForce));
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
            
        }
            
    }


    //player can jump when it touch to platform, prevent multi jump
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }


}
