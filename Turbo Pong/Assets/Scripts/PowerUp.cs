using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    float timerJ1;
    float timerJ2;
    float timerPowerJ1 = 5f;
    float timerPowerJ2 = 5f;
    bool isPowerJ1 = false;
    bool isPowerJ2 = false;
    bool isGrow = false;
    bool isSlow = false;
    public GameObject Ball;
    public float multiplier = 1.4f;
    private bool isTall = false;

    [Space(5)]
    [Header("UI PowerUp")]
    public GameObject GrowUpJ1;
    public GameObject GrowUpJ2;
    public GameObject SlowMoJ1;
    public GameObject SlowMoJ2;

    [Space(5)]
    [Header("SFX")]
    public AudioClip PickUp;
    public AudioClip USePowerUp;
    private AudioSource AudioS;


    int PowerAvailableJ1 = -1;
    int PowerAvailableJ2 = -1;

    // Start is called before the first frame update
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
        timerJ1 = 10f;
        timerJ2 = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timerJ1);
        Debug.Log(timerJ2);


        if (PowerAvailableJ1 == -1)
        {
            timerJ1 -=  Time.deltaTime;
            
        }
        if(PowerAvailableJ2 == -1)
        {
            timerJ2 -= Time.deltaTime;
        }
        

        if (isPowerJ1 == true)
        {
            timerPowerJ1 -= Time.deltaTime;
        }

        if (isPowerJ2 == true)
        {
            timerPowerJ2 -= Time.deltaTime;
        }

        if (timerJ1 <= 0 && timerPowerJ1 == 5f)
        {
            AudioS.clip = PickUp;
            AudioS.Play();
            timerJ1 = 10f;
            int rand = Random.Range(0, 1);
            switch (rand)
            {
                case 0:
                    PowerAvailableJ1 = 0;
                    GrowUpJ1.SetActive(true);
                    break;
                /*case 1:
                    PowerAvailableJ1 = 1;
                    SlowMoJ1.SetActive(true);
                    break;*/
            }
        }

        if (timerJ2 <= 0 && timerPowerJ2 == 5f)
        {
            AudioS.clip = PickUp;
            AudioS.Play();
            timerJ2 = 10f;
            int rand = Random.Range(0, 1);
            switch (rand)
            {
                case 0:
                    PowerAvailableJ2 = 0;
                    GrowUpJ2.SetActive(true);
                    break;
                /*case 1:
                    PowerAvailableJ2 = 1;
                    SlowMoJ2.SetActive(true);
                    break;*/
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && isPowerJ2 == false)
        {
            AudioS.clip = USePowerUp;
            AudioS.Play();
            isPowerJ2 = true;
            switch (PowerAvailableJ2)
            {
                case 0:
                    Power1();
                    isGrow = true;
                    break;
                /*case 1:
                    Power2();
                    isSlow = true;
                    break;*/
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isPowerJ1 == false)
        {
            AudioS.clip = USePowerUp;
            AudioS.Play();
            isPowerJ1 = true;
            switch (PowerAvailableJ1)
            {
                case 0:
                    Power1();
                    isGrow = true;
                    break;
                /*case 1:
                    Power2();
                    isSlow = true;
                    break;*/
            }

        }

        if ((timerPowerJ1 <= 0) && (isPowerJ1) && isGrow == true)
        {
            Ball.transform.localScale /= multiplier;
            timerPowerJ1 = 5f;
            isPowerJ1 = false;
            isGrow = false;
            PowerAvailableJ1 = -1;
        }

        if ((timerPowerJ2 <= 0) && (isPowerJ2) && isGrow == true)
        {
            Ball.transform.localScale /= multiplier;
            timerPowerJ1 = 5f;
            isPowerJ2 = false;
            isGrow = false;
            PowerAvailableJ1 = -1;
        }


        /*if ((timerPowerJ1 <= 0) && (isPowerJ1) && isSlow == true)
        {
            Ball.GetComponent<Ball>().speed += 8f;
            timerPowerJ1 = 5f;
            isPowerJ1 = false;
            PowerAvailableJ1 = -1;
        }

        if ((timerPowerJ2 <= 0) && (isPowerJ2) && isSlow == true)
        {
            Ball.GetComponent<Ball>().speed += 8f;
            timerPowerJ1 = 5f;
            isPowerJ2 = false;
            PowerAvailableJ2 = -1;
        }*/

    }

    void Power1()
    {
        Ball.transform.localScale *= multiplier;

        if (isPowerJ1)
        {
            GrowUpJ1.SetActive(false);
        }
        else
        {
            GrowUpJ2.SetActive(false);
        }
    }


    /*void Power2()
    {
        Ball.GetComponent<Ball>().speed -= 8f;

        if (isPowerJ1)
        {
            SlowMoJ1.SetActive(false);
        }

        if(isPowerJ2)
        {
            SlowMoJ2.SetActive(false);
        }
    }*/

}
