using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Music")]
    public AudioSource AudioSource;
    public AudioClip EndMusic;
    public AudioClip Lvl2_Music;

    /*[Header("UI")]
    public GameObject EndMenuUI;
    public GameObject GameWindow;*/

    [HideInInspector] public IEnumerator EndGame;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        DontDestroyOnLoad(gameObject);
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

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    public void SwitchMenu()
    {
        SceneManager.LoadScene("CharacterMenu", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 2")
        {
            AudioSource.clip = Lvl2_Music;
            AudioSource.Play();
        }
        if (scene.name == "EndMenu")
        {
            AudioSource.clip = EndMusic;
            AudioSource.Play();
            
            GameObject.Find("ButtonRestart").GetComponent<Button>().onClick.AddListener(RestartGame);
            GameObject.Find("ButtonChange").GetComponent<Button>().onClick.AddListener(SwitchMenu);
            GameObject.Find("ButtonMenu").GetComponent<Button>().onClick.AddListener(LoadMainMenu);

        }
    }

    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. 
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}
