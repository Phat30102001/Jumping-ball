using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyboardControl : TiltControl
{
    //[SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        Move();
        //    float horizontal = Input.GetAxisRaw("Horizontal");
        //    _range = GameManager.instance.player.GetCamWidth() - _circleCollider.radius;
        //    transform.position=new Vector3(Mathf.Clamp(transform.position.x + (horizontal * moveSpeed) * Time.deltaTime, -_range, _range) , transform.position.y, 0);
        
    
    }
    private void Move()
    {
        if (GameManager.instance.state != GameState.PLAYABLE) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        _range = GameManager.instance.player.GetCamWidth() - _circleCollider.radius;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + (horizontal * moveSpeed) * Time.deltaTime, -_range, _range), transform.position.y, 0);
    }
}
