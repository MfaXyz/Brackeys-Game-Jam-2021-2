using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoleController : MonoBehaviour
{
    [Header("Components")] 
    private Rigidbody2D _rb;
    
    
    [Header("Variables")]
    [SerializeField] private float randomDegree;
    [SerializeField] private float randomX;
    [SerializeField] private float randomY;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        randomDegree = Random.Range(0, 361);
        
        transform.rotation = Quaternion.Euler(0,0,randomDegree);

        StartCoroutine(RandomForce());
    }

    private void FixedUpdate()
    {
        var vector2 = new Vector2(randomX, randomY);
        _rb.AddRelativeForce(vector2,ForceMode2D.Impulse);
    }

    private IEnumerator RandomForce()
    {
        while (true)
        {
            randomX = Random.Range(-3, 4);
            randomY = Random.Range(-3, 4);
            yield return new WaitForSeconds(3);
        }
    }
}
