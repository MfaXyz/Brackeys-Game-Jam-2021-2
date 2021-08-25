using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Components")] 
    public Image imageBar;
    public PlayerController playerController;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Text planetText;
    
    //[Header("Variables")] 
    

    private void FixedUpdate()
    {
        if (playerController.storageValue >= 0)
        {
            imageBar.fillAmount = playerController.storageValue/100;
        }
        else
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        planetText.text = GameManager.Instance.destroyedPlanets + "/" + GameManager.Instance.maxPlanets;
    }

    public void ResetGameBtn()
    {
        GameManager.Instance.destroyedPlanets = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private IEnumerator GameOverIE()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void StartGameOver()
    {
        StartCoroutine(GameOverIE());
    }

    public void StartVictory()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
