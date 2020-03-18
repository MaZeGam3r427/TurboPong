using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public float timer;
    public GameObject player;
    public GameObject ennemi;
    private float goodMultiplier = 1.4f;
    private float badMultiplier = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;

        if(timer <= 0)
        {
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    Power1();
                    break;
                case 1:
                    Power2();
                    break;
                case 2:
                    Power3();
                    break;
                default: break;
            }

            timer = 10f;
        }

    }

    void Power1()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            player.transform.localScale *= goodMultiplier;
            float timerBis = 10f;
            timerBis -= 1 * Time.deltaTime;
            if (timerBis <= 0)
            {
                player.transform.localScale *= badMultiplier;
            }
        }        
    }

    void Power2()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ennemi.transform.localScale *= badMultiplier;
            float timerBis = 10f;
            timerBis -= 1 * Time.deltaTime;
            if (timerBis <= 0)
            {
                ennemi.transform.localScale *= goodMultiplier;
            }
        }
        
    }

    void Power3()
    {
        Debug.Log("hello");
    }

}
