using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    public void OptionMenu()
    {
        MainMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void BackButton()
    {
        MainMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}