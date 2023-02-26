using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Camera mainCamera;
    public GroundCheck groundCheck;

    private Rigidbody2D _rb;

    //public Transform groundCheck;
    //public LayerMask groundLayer;
    [SerializeField] private float _jumpingForce;

    private Platform _platformLanded;

    public Platform PlatformLanded { get => _platformLanded; set => _platformLanded = value; }
    public float JumpingForce { get => _jumpingForce;}

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public float GetCamWidth()
    {
        return mainCamera.aspect * GetCamHeight();
    }
    public float GetCamHeight()
    {
        return mainCamera.orthographicSize;
    }

}
