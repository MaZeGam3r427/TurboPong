using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject MenuVideo;
    public Animator myAnims;

    /*private void OnMouseUp()
    {
        myAnims.SetTrigger("Transit");
    }

    public void DisableVideo()
    {
        MenuVideo.SetActive(false);
    }*/

    public void OnMouseUp()
    {
        MenuVideo.SetActive(false);
    }

}
