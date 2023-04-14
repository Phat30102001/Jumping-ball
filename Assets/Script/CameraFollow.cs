using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    public Transform target;
    public Vector3 offset;

    [Range(1f, 10f)]
    public float smoothFactor;

    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        Follow();
    }
    private void Follow()
    {
        if (target == null || target.transform.position.y < transform.position.y) return;
        //target is player
        Vector3 targetPos = new Vector3(0f, target.transform.position.y, 0f) + offset;
        Vector3 smoothedPos=Vector3.Lerp(transform.position, targetPos, smoothFactor*Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(smoothedPos.x, 0f, smoothedPos.x),
            Mathf.Clamp(smoothedPos.y, 0f, smoothedPos.y),
            -10f);
    }
}
