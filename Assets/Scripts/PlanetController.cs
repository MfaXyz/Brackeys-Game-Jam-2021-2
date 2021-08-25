using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlanetController : MonoBehaviour
{
    [Header("Components")]
    public PathCreator pathCreator;
    [Header("Variables")]
    [SerializeField] private float speedMovement;
    public float maxSpeed;
    public float distanceTravelled;
    public bool isReverse;

    private void Awake()
    {
        speedMovement = maxSpeed;
    }

    private void FixedUpdate()
    {
        distanceTravelled += speedMovement;

        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LaserGun"))
        {
            speedMovement = 0;
        }

        if (col.gameObject.CompareTag("Planet"))
        {
            Destroy(col.transform.parent.gameObject);
            Destroy(transform.parent.gameObject);
            
            GameManager.Instance.CollisionPlanets(transform.position);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LaserGun"))
        {
            if (isReverse)
            {
                speedMovement = maxSpeed;
                isReverse = false;
            }
            else
            {
                speedMovement = -maxSpeed; 
                isReverse = true;
            }
        }
    }
}