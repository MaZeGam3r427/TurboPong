using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    [HideInInspector]public float compteur;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        compteur += Time.deltaTime;
    }

    public void Spawn()
    {

        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        if (Random.Range(0, 2) == 0)
            sx = -1;
        else
            sx = 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, speed * sy, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
