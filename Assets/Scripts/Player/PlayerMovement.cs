using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    
    [Header("Value's")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private Vector3 startMoveThreshold = new Vector3(0, 0, 0);
    [SerializeField] private Vector2 movingDir;

    [Header("Bool's")]
    [SerializeField] private bool isMoving;
    private bool _isStartMoving = true;
    private bool _mayStopMoving = true;

    [Header("Event Variables")]
    [SerializeField] private UnityEvent onStartMoving = new UnityEvent();
    [SerializeField] private UnityEvent moving = new UnityEvent();
    [SerializeField] private UnityEvent onStopMoving = new UnityEvent();

    private void FixedUpdate()
    {
        if (rb.velocity != startMoveThreshold && _isStartMoving)
        {
            onStartMoving?.Invoke();
            _isStartMoving = false;
        }

        if (rb.velocity != new Vector3(0, rb.velocity.y, 0))
        {
            isMoving = true;
            moving?.Invoke();
            _mayStopMoving = true;
        }else isMoving = false;

        if (movingDir == new Vector2(0, 0) && _mayStopMoving)
        {
            onStopMoving?.Invoke();
            _mayStopMoving = false;
        }
    }

    public void Move(Vector2 dir)
    {
        movingDir = dir;
        
        rb.velocity = new Vector3(dir.x * walkSpeed, rb.velocity.y, dir.y * walkSpeed);

        if (rb.velocity == startMoveThreshold) _isStartMoving = true;
    }

    public void EventTest()
    {
        Debug.Log("test");
    }
}
