using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderLevel : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void TransitionMapMenu()
    {
        StartCoroutine(MapMenu(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public IEnumerator MapMenu (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}   

