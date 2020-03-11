using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject PauseMenuUI;
    private GameObject GameUI;
    public static bool IsPaused = false;

    [Header("Music")]
    public AudioSource AudioSource;
    public AudioClip MusicMenu;
    public AudioClip EndMusic;
    public AudioClip Lvl2_Music;
    public AudioMixer myMixer;

    public GameObject Ball;
    private GameObject inGame_Ball;


    [HideInInspector] public IEnumerator EndGame;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        EndGame = Ball.GetComponent<Ball>().RestartGame();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }*/
    }

    /*public void Pause()
    {
        GameUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        inGame_Ball.SetActive(false);
    }

    public void Resume()
    {
        GameUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inGame_Ball.SetActive(true);
    }*/

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

    public void SetVolume(float volume)
    {
        myMixer.SetFloat("Volume", volume);
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        inGame_Ball = GameObject.Find("Ball");
        GameUI = GameObject.Find("GameUI");

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
        if(scene.name == "MainMenu")
        {
            AudioSource.clip = MusicMenu;
            AudioSource.Play();
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
