using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 5f;
    float compteur;

    [Header("Ball")]
    public Rigidbody m_Rigidbody;
    public GameObject Balle; 
    Vector3 BallSP;

    [Header("ScoreUI")]
    public TextMeshProUGUI ScoreP1;
    public TextMeshProUGUI ScoreP2;
    public int var_ScoreP1 = 0;
    int var_ScoreP2 = 0;

    [Header("SFX")]
    public AudioSource SFXAudioSource;
    public AudioClip Engagement;
    public AudioClip ImpactBarre;
    public AudioClip PointMarque;
    public static Ball Singleton;

    // Start is called before the first frame update
    void Awake()
    {
        if(Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }

        StartCoroutine(BallCoroutine());

        var_ScoreP1 = 0;
        var_ScoreP2 = 0;
        ScoreP1.text = var_ScoreP1.ToString();
        ScoreP2.text = var_ScoreP2.ToString();

        BallSP = Balle.transform.position;

        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        compteur += Time.deltaTime;
        //Debug.Log(compteur);

        //If the ball touchs nothins during 5f, it comes back at its spawnpoint
        if (compteur >= 3f)
        {
            compteur = 0f;
            Balle.transform.position = BallSP;
            Spawn();
        }

        if(var_ScoreP1 == 11 || var_ScoreP2 == 11)
        {
            var_ScoreP1 = 0;
            var_ScoreP2 = 0;
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("EndMenu", LoadSceneMode.Single);
        }
        
    }

    //Give speed and a random direction to the ball 
    public void Spawn()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        if (Random.Range(0, 2) == 0)
            sx = -1;
        else
            sx = 1;

        m_Rigidbody.velocity = new Vector3(speed * sx, speed * sy, 0f);
    }

    //Add 1 to the score when the ball reachs the goal
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1")
        {
            compteur = 0f;
            var_ScoreP1 += 1;
            ScoreP1.text = var_ScoreP1.ToString();
            Balle.transform.position = BallSP;
            SFXAudioSource.clip = PointMarque;
            SFXAudioSource.Play();
        }

        if (other.tag == "P2")
        {
            compteur = 0f;
            var_ScoreP2 += 1;
            ScoreP2.text = var_ScoreP2.ToString();
            Balle.transform.position = BallSP;
            SFXAudioSource.clip = PointMarque;
            SFXAudioSource.Play();
        }

        StartCoroutine(BallCoroutine());

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumpers"))
        {
            compteur = 0f;
            SFXAudioSource.clip = ImpactBarre;
            SFXAudioSource.Play();
        }
    }

    //Break after a goal
    IEnumerator BallCoroutine()
    {
        //Block the ball
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        //Wait
        yield return  new WaitForSeconds(1f);
        //Release the ball
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        SFXAudioSource.clip = Engagement;
        SFXAudioSource.Play();
        Spawn();
    }

    public IEnumerator RestartGame()
    {
        StartCoroutine(BallCoroutine());
        yield return null;
    }
}
