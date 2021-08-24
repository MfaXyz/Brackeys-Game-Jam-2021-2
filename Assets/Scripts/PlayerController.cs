using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Values")] 
    public Vector2 speedMovement;

    [Header("Components")] 
    public Rigidbody2D rb;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        var movement = new Vector2(Input.GetAxis("Horizontal") * speedMovement.x, Input.GetAxis("Vertical") * speedMovement.y);
        rb.AddForce(movement, ForceMode2D.Impulse);
    }
}
