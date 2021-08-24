using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlanetPath : MonoBehaviour
{
    [Header("Components")]
    public PathCreator pathCreator;
    [Header("Variables")]
    public float speedMovement;
    public float distanceTravelled;

    private void FixedUpdate()
    {
        distanceTravelled += speedMovement;

        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
