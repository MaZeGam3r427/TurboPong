using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckGoal : MonoBehaviour
{
    public GameObject Ball;
    public TextMeshProUGUI ScoreP1;
    public TextMeshProUGUI ScoreP2;
    int var_ScoreP1 = 0;
    int var_ScoreP2 = 0;
    public Vector3 BallSP;



    // Start is called before the first frame update
    void Start()
    {
        ScoreP1.text = var_ScoreP1.ToString();
        ScoreP2.text = var_ScoreP2.ToString();

        BallSP = Ball.transform.position;

        GameObject.Find("Ball").GetComponent<Ball>().Spawn();
        
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "P1")
        {
            var_ScoreP1 += 1;
            ScoreP1.text = var_ScoreP1.ToString();
            Ball.transform.position = BallSP;
        }

        if (gameObject.tag == "P2")
        {
            var_ScoreP2 += 1;
            ScoreP2.text = var_ScoreP2.ToString();
            Ball.transform.position = BallSP;
        }
    }
}
