using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savemanager : MonoBehaviour
{
    private int nbDestroyed = 0;
    public Transform TargetsParent;

    public static savemanager s_singleton;

    private void Awake()
    {
        if(s_singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_singleton = this;
        }
        //PlayerPrefs.DeleteAll();
    }
    // Start is called before the first frame update
    void Start()
    {
        int tmpDestr = PlayerPrefs.GetInt("Detruits");
        for (int i = 0; i < tmpDestr; i++)
        {
            Destroy(TargetsParent.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestructibleDestroyed ()
    {
        nbDestroyed++;
        PlayerPrefs.SetInt("Detruits", nbDestroyed);
        Debug.Log(nbDestroyed);
    }
}
