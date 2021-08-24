using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Values")] 
    public float storageValue;
    public Vector2 speedMovement;
    public float decreaseStorageValue;
    public float maxParticleLifeTime;
    public bool isMove;

    [Header("Components")] 
    public Rigidbody2D rb;
    private ParticleSystem.MainModule _laserParticle;
    public ParticleSystem laserParticle;
    public CapsuleCollider2D laserCapsule;

    private void Awake()
    {
        _laserParticle = laserParticle.main;
    }

    private void FixedUpdate()
    {
        isMove = rb.velocity.magnitude > 0.5f;
        if (isMove)
        {
            storageValue -= decreaseStorageValue;
        }
        
        var movement = new Vector2(Input.GetAxis("Horizontal") * speedMovement.x, Input.GetAxis("Vertical") * speedMovement.y);
        rb.AddForce(movement, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _laserParticle.startLifetime = maxParticleLifeTime;
            laserCapsule.enabled = true;
        }
        else
        {
            _laserParticle.startLifetime = 0;
            laserCapsule.enabled = false;
        }
    }


}
