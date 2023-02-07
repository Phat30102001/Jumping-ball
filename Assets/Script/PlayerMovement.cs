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
        if (rb.velocity.y > 0f) return;
        if (IsGrounded()&&GameManager.instance.state==GameState.PLAYABLE)
            Jumping();

        
    }

    public void Jumping()
    {
        //if (PlayerBehaviour.instace.state != PlayerState.IDLE) return;
        Debug.Log("jump");
        //rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
        rb.AddForce(new Vector2(rb.velocity.x,jumpingForce));
    }

    public void JumpCancel()
    {
        rb.AddForce(Vector2.down * rb.velocity.y * 0.9f, ForceMode2D.Impulse);
    }


    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    //public void Move( InputAction.CallbackContext context)
    //{
    //    horizontal = context.ReadValue<Vector2>().x;
    //    //horizontal's always = 1
    //    animator.SetFloat("IsRun", Mathf.Abs(horizontal));
    //}
}
