using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private Outline myOutilne;
    // Start is called before the first frame update
    void Start()
    {
        myOutilne = GetComponent<Outline>();
    }

    private void OnMouseEnter()
    {
        myOutilne.enabled = true;
    }

    private void OnMouseExit()
    {
        myOutilne.enabled = false;
    }
}



