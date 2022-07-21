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

    [Header("Bool's")]
    private bool _isStartMoving = true;

    [Header("Event Variables")]
    [SerializeField] private UnityEvent onStartMoving = new UnityEvent();
    
    public void Move(Vector2 dir)
    {
        rb.velocity = new Vector3(dir.x * walkSpeed, rb.velocity.y, dir.y * walkSpeed);

        if (rb.velocity == startMoveThreshold) _isStartMoving = true;
        
        if (rb.velocity != startMoveThreshold && _isStartMoving)
        {
            onStartMoving?.Invoke();
            _isStartMoving = false;
        }
    }
}
