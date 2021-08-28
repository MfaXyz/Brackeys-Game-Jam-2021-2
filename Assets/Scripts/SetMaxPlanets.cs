using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxPlanets : MonoBehaviour
{
    public int maxPlanetsNumber;
    private void Start()
    {
        GameManager.Instance.maxPlanets = maxPlanetsNumber;
    }
}
