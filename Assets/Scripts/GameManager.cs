using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Components")] public GameObject explosionObject;
    public UIManager uiManager;

    [Header("Variables")] public int maxPlanets;
    public int destroyedPlanets;
    
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        StartCoroutine(CheckUIManager());
    }
    private IEnumerator CheckUIManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }
    }
    public void CollisionPlanets (Vector3 location)
    {
        destroyedPlanets++;
        Instantiate(explosionObject, location, Quaternion.identity);
        if (destroyedPlanets == maxPlanets)
        {
            PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex + 1);
            uiManager.StartVictory();
        }
    }
}
