using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBall : MonoBehaviour
{
    private float deltaX;
    //private float deltaY;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("touched");
            Touch touch= Input.GetTouch(0);

            Vector2 touchPos=Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX=touchPos.x-transform.position.x;
                    //deltaY=touchPos.y-transform.position.y;
                    break;
                case TouchPhase.Moved:
                    rb.velocity=new Vector2(touchPos.x - deltaX,rb.velocity.y);
                    break;
                    
                //case TouchPhase.Ended:
                //    rb.velocity = Vector2.zero;
                //    break;
            }
        }
    }
}
