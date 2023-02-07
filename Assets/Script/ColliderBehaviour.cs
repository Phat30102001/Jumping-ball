using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehaviour : MonoBehaviour
{

    private GameObject ball;
    private Collider2D platformCollider;

    private void Awake()
    {
        platformCollider = GetComponent<Collider2D>();
        ball = GameObject.Find("Ball");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private float DisToBall()
    //{
    //    float dis=transform.position.y- ball.transform.position.y;
    //    return dis;
    //}
    //private void IsTriggerCollider()
    //{
    //    //if collider is higher than ball => ball can get through
    //    if(DisToBall()>=0f)
    //        platformCollider.isTrigger= true;
    //    else
    //        platformCollider.isTrigger= false;

    //}
}
