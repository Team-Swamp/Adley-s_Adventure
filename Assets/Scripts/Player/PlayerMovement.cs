using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    
    [Header("Value's")]
    [SerializeField] private float walkSpeed;
    
    public void Move(Vector2 dir)
    {
        rb.velocity = new Vector3(dir.x * walkSpeed, rb.velocity.y, dir.y * walkSpeed);
    }
}
