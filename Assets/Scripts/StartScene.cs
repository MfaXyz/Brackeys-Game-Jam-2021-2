using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [Header("Variables")]
    public int lastLevel;

    [Header("Components")] 
    public GameObject[] lockImages;
    public Button[] btnLevels;
    private void Awake()
    {
        lastLevel = PlayerPrefs.GetInt("lastLevel") - 1;
        for (var i = 0; i <= lastLevel; i++)
        {
            lockImages[i].SetActive(false);
            btnLevels[i].enabled = true;
        }
    }

    public void StartGame(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
