using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlanet : MonoBehaviour
{
    [Header("Components")]
    public UIManager uiManager;
    public GameObject explosionObject;
    public GameObject playerShip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            uiManager.StartGameOver();
            playerShip.SetActive(false);
            other.gameObject.SetActive(false);
            Instantiate(explosionObject, transform.position, transform.rotation);
        }
    }
}
