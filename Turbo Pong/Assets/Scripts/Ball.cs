using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 5f;
    float compteur;
    public GameObject EndMenuUI;
    public GameObject GameUI;

    [Header("Ball")]
    public Rigidbody m_Rigidbody;
    public GameObject Balle; 
    Vector3 BallSP;

    [Header("ScoreUI")]
    public TextMeshProUGUI ScoreP1;
    public TextMeshProUGUI ScoreP2;
    public int var_ScoreP1 = 0;
    int var_ScoreP2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();

        ScoreP1.text = var_ScoreP1.ToString();
        ScoreP2.text = var_ScoreP2.ToString();

        BallSP = Balle.transform.position;

        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        compteur += Time.deltaTime;
        Debug.Log(compteur);

        if (compteur >= 5f)
        {
            compteur = 0f;
            Balle.transform.position = BallSP;
            Spawn();
        }

        if(var_ScoreP1 == 11 || var_ScoreP2 == 11)
        {
            Time.timeScale = 0f;
            EndMenuUI.SetActive(true);
            GameUI.SetActive(false);
        }
        
    }

    public void Spawn()
    {

        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        if (Random.Range(0, 2) == 0)
            sx = -1;
        else
            sx = 1;

        m_Rigidbody.velocity = new Vector3(speed * sx, speed * sy, 0f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1")
        {
            compteur = 0f;
            var_ScoreP1 += 1;
            ScoreP1.text = var_ScoreP1.ToString();
            Balle.transform.position = BallSP;
        }

        if (other.tag == "P2")
        {
            compteur = 0f;
            var_ScoreP2 += 1;
            ScoreP2.text = var_ScoreP2.ToString();
            Balle.transform.position = BallSP;
        }

        StartCoroutine(BallCoroutine());

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumpers"))
        {
            compteur = 0f;
        }
    }

    IEnumerator BallCoroutine()
    {
        //Block the ball
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        //Wait
        yield return  new WaitForSeconds(1f);
        //Release the ball
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        Spawn();
    }

    IEnumerator EndGame()
    {
        EndMenuUI.SetActive(true);
        yield return null;
    }
}
