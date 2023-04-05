using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    public List<Transform> pointList;
    private float _movingSpeed=3;
    int currentWaypointIndex = 0;

    [SerializeField]private Transform _movingPoint;
    private void Awake()
    {
        pointList[0] = GameManager.instance.leftPoint;
        pointList[1]= GameManager.instance.rightPoint;
    }

    private void FixedUpdate()
    {
        Move();

    }

    public void Move()
    {   
        _movingPoint.position = new Vector2(pointList[currentWaypointIndex].transform.position.x, transform.position.y);
        if (Vector2.Distance(_movingPoint.position, transform.position)<0.1f)
        {
            //Debug.Log("swtich point");
            currentWaypointIndex++;
            if (currentWaypointIndex >= pointList.Count)
            {
                currentWaypointIndex = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position,_movingPoint.position, Time.deltaTime * _movingSpeed);
    }
}
