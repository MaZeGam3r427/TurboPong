using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUpPowerup : MonoBehaviour
{

    public GameObject tallBar;
    public GameObject normalBar;
    private Vector3 positionNormalBar;
    private Quaternion rotationNormalBar;

    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionNormalBar = normalBar.transform.position;
        rotationNormalBar = normalBar.transform.rotation;

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            Instantiate(tallBar, positionNormalBar, rotationNormalBar);
            Destroy(normalBar);
            Destroy(gameObject);
        }
    }

    
}
