using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    [Header("Music")]
    public AudioSource AudioSource;
    public AudioClip EndMusic;

    /*[Header("UI")]
    public GameObject EndMenuUI;
    public GameObject GameWindow;*/

    [HideInInspector] public IEnumerator EndGame;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        DontDestroyOnLoad(gameObject);
        if (Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        EndGame = GameObject.Find("Ball").GetComponent<Ball>().RestartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        StartCoroutine(EndGame);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EndMenu")
        {
            AudioSource.clip = EndMusic;
            AudioSource.Play();
            
            GameObject.Find("ButtonRestart").GetComponent<Button>().onClick.AddListener(RestartGame);
            GameObject.Find("QuitRestart").GetComponent<Button>().onClick.AddListener(QuitGame);

        }
    }

    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}
