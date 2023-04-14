using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//unuse
public class UnfollowCamera : MonoBehaviour
{

    private Vector3 _startingPos;

    private void Awake()
    {
        _startingPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= _startingPos;
    }
}
