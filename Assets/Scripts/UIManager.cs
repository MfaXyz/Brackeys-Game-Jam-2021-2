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
    public GameObject gameOverExplosion;
    public Text planetText;

    [Header("Variables")] 
    public bool isLose;

    private void FixedUpdate()
    {
        if (playerController.storageValue >= 0)
        {
            imageBar.fillAmount = playerController.storageValue/100;
        }
        else
        {
            StartCoroutine(GameOverEnergy());
        }

        planetText.text = GameManager.Instance.destroyedPlanets + "/" + GameManager.Instance.maxPlanets;
    }
    private IEnumerator GameOverEnergy()
    {
        if (!isLose)
        {
            playerController.gameObject.SetActive(false);
            Instantiate(gameOverExplosion, playerController.transform.position, playerController.transform.rotation);
            isLose = true;
            yield return new WaitForSeconds(3);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

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

    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel"), LoadSceneMode.Single);
        Time.timeScale = 1;
        GameManager.Instance.destroyedPlanets = 0;
    }
    public void StartVictory()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
