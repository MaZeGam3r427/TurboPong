using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUpPowerup : MonoBehaviour
{

    public GameObject Ball;
    public float multiplier = 2f;

    private float timer = 5f;
    private bool isTall = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTall == false)
        {
            Ball.transform.localScale *= multiplier;
            isTall = true;
        }

            if (isTall == true)
            {
                timer -= 1 * Time.deltaTime;
                if (timer <= 0)
                {
                    isTall = false;
                    timer = 5f;
                    Ball.transform.localScale /= multiplier;
                }
            }
    }
}
