using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    //public Camera mainCamera;
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;
    private float _dx;
    [SerializeField] private float moveSpeed;
    private float _range;

    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _circleCollider=GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

        //_range = GetCamWidth()-_circleCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        //dx=Input.acceleration.x*moveSpeed;
    }

    private void FixedUpdate()
    {   
        if (GameManager.instance.state != GameState.PLAYABLE) return;
        _range = GameManager.instance.player.GetCamWidth() - _circleCollider.radius;

        _dx = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -_range, _range), transform.position.y);
        _rb.velocity = new Vector2(_dx, _rb.velocity.y);
    }
    //public float GetCamWidth()
    //{
        
    //    float halfWidth = mainCamera.orthographicSize;
    //    return mainCamera.aspect * halfWidth;
    //}
}
