using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button QuitButton;
    public Button RestartButton;
    public GameObject EndMenuUI;
    public GameObject GameWindow;
    [HideInInspector] public IEnumerator EndGame;

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
    }
}
