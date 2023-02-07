using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dx;
    [SerializeField] private float moveSpeed;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //dx=Input.acceleration.x*moveSpeed;
    }

    private void FixedUpdate()
    {
        dx = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -range, range), transform.position.y);
        rb.velocity = new Vector2(dx, rb.velocity.y);
    }
}
