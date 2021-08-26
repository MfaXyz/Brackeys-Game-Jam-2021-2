using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Values")] 
    public float storageValue;
    public Vector2 speedMovement;
    public float rotationSpeed;
    public float decreaseStorageValue;
    public float increaseStorageValue;
    public float maxGunParticleLifeTime;
    public float maxEngineParticleLifeTime;
    public bool isMove;

    [Header("Components")] 
    public Rigidbody2D rb;
    private ParticleSystem.MainModule _laserParticle;
    public ParticleSystem laserParticle;
    public CapsuleCollider2D laserCapsule;
    private ParticleSystem.MainModule[] _enginesParticles = new ParticleSystem.MainModule[5];
    public ParticleSystem[] enginesParticles;

    private void Awake()
    {
        _laserParticle = laserParticle.main;

        for (var i = 0; i < 5; i++)
        {
            _enginesParticles[i] = enginesParticles[i].main;
        }
    }

    private void FixedUpdate()
    {
        isMove = rb.velocity.magnitude > 0.5f;
        isMove = Mathf.Abs(rb.angularVelocity) > 0.1f;
        if (isMove)
        {
            storageValue -= decreaseStorageValue;
        }
        
        var movement = new Vector2(0, Input.GetAxis("Vertical") * speedMovement.y);
        rb.AddRelativeForce(movement, ForceMode2D.Impulse);
        rb.AddTorque(Input.GetAxis("Horizontal") * -rotationSpeed,ForceMode2D.Impulse);

        _enginesParticles[0].startLifetime = maxEngineParticleLifeTime * Input.GetAxis("Vertical");
        _enginesParticles[1].startLifetime = maxEngineParticleLifeTime * Input.GetAxis("Vertical");
        _enginesParticles[2].startLifetime = maxEngineParticleLifeTime * Input.GetAxis("Vertical");
        _enginesParticles[3].startLifetime = maxEngineParticleLifeTime * -Input.GetAxis("Horizontal");
        _enginesParticles[4].startLifetime = maxEngineParticleLifeTime * Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _laserParticle.startLifetime = maxGunParticleLifeTime;
            laserCapsule.enabled = true;
        }
        else
        {
            _laserParticle.startLifetime = 0;
            laserCapsule.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StoragePlace"))
        {
            if (storageValue <= 100)
            {
                storageValue += increaseStorageValue;
            }
            
        }
    }
}
