using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int _id;
    protected Rigidbody2D _rb;
    protected Player _player;

    public int Id { get => _id; set => _id = value; }

    protected virtual void Awake()
    {
        _rb= GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void PlatformAction()
    {

    }
}
