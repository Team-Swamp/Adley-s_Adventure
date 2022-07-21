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
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 startMovingThreshold = Vector3.zero;
    [SerializeField] private Vector2 movingDir;

    [Header("Bools")]
    [SerializeField] private bool isMoving;
    private bool _mayStartMoving = true;
    private bool _mayStopMoving = true;

    [Header("Event Variables")]
    [SerializeField] private UnityEvent onStartMoving = new UnityEvent();
    [SerializeField] private UnityEvent moving = new UnityEvent();
    [SerializeField] private UnityEvent onStopMoving = new UnityEvent();

    private void FixedUpdate()
    {
        if (rb.velocity != startMovingThreshold && _mayStartMoving)
        {
            onStartMoving?.Invoke();
            _mayStartMoving = false;
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

    public void Move(Vector2 direction)
    {
        movingDir = direction;
        
        rb.velocity = new Vector3(direction.x * movementSpeed, rb.velocity.y, direction.y * movementSpeed);

        if (rb.velocity == startMovingThreshold) _mayStartMoving = true;
    }
}
