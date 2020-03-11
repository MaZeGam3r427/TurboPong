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

    private Button Level1Button;
    private Button Level2Button;
    private Button Level3Button;

    private TextMeshProUGUI Level1Txt;
    private TextMeshProUGUI Level2Txt;
    private TextMeshProUGUI Level3Txt;

    private int Level;


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

    //Quitting the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    //Start a new game directly, without changing map
    public void RestartGame()
    {
      switch(Level)
      {
            case 1:
                SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
                break;


      }
    }

    //Load the map and start the game
    public void LoadLevelOne()
    {
        if(Level1Button.name == "Level_1Button")
        {
            if(Level1Txt.text == "LEVEL 1")
            {
                //Debug.Log("Loading Level 1");
                SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
                Level = 1;
            }

        }
    }

    public void LoadLevelTwo()
    {
        if (Level2Button.name == "Level_2Button")
        {
            if (Level2Txt.text == "LEVEL 2")
            {
                //Debug.Log("Loading Level 2");
                SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
                Level = 2;
            }
        }
    }

    public void LoadLevelThree()
    {
        if (Level3Button.name == "Level_3Button")
        {
            if (Level3Txt.text == "LEVEL 3")
            {
                //Debug.Log("CA MARCHE !");
                SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
                Level = 3;
            }
        }
    }

    public void LoadMapMenu()
    {
        SceneManager.LoadScene("ChooseMap", LoadSceneMode.Single);
    }

    public void ReloadMapMenu()
    {
        SceneManager.LoadScene("ChooseMap", LoadSceneMode.Single);
        AudioSource.clip = MusicMenu;
        AudioSource.Play();
    }

    //When click on the button, load the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    //Change the volume of the game
    public void SetVolume(float volume)
    {
        myMixer.SetFloat("Volume", volume);
    }


    //Execute this fonction when the level is loaded
    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        inGame_Ball = GameObject.Find("Ball");
        GameUI = GameObject.Find("GameUI");

        if(scene.name == "ChooseMap")
        {

            Level1Txt = GameObject.Find("Level1Text").GetComponent<TextMeshProUGUI>();
            Level2Txt = GameObject.Find("Level2Text").GetComponent<TextMeshProUGUI>();
            Level3Txt = GameObject.Find("Level3Text").GetComponent<TextMeshProUGUI>();

            Level1Button = GameObject.Find("Level_1Button").GetComponent<Button>();
            Level2Button = GameObject.Find("Level_2Button").GetComponent<Button>();
            Level3Button = GameObject.Find("Level_3Button").GetComponent<Button>();

            Level1Button.onClick.AddListener(LoadLevelOne);
            Level2Button.onClick.AddListener(LoadLevelTwo);
            Level3Button.onClick.AddListener(LoadLevelThree);
        }

        if(scene.name == "Level 1")
        {
            AudioSource.clip = null;
            AudioSource.Stop();
        }

        if (scene.name == "Level 2")
        {
            AudioSource.clip = Lvl2_Music;
            AudioSource.Play();
        }

        if (scene.name == "Level 3")
        {
            AudioSource.clip = null;
            AudioSource.Stop();
        }

        if (scene.name == "EndMenu")
        {
            AudioSource.clip = EndMusic;
            AudioSource.Play();
            
            GameObject.Find("ButtonRestart").GetComponent<Button>().onClick.AddListener(RestartGame);
            GameObject.Find("ButtonChange").GetComponent<Button>().onClick.AddListener(ReloadMapMenu);
            GameObject.Find("ButtonMenu").GetComponent<Button>().onClick.AddListener(LoadMainMenu);

        }
        if(scene.name == "MainMenu")
        {
            AudioSource.clip = MusicMenu;
            AudioSource.Play();

            Level = 0;
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
