using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public bool isBump1 = true;
    public float speed = 5f;
    public Rigidbody myRigid;
    


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isBump1)
        {
            float MoveP1 = Input.GetAxis("VerticalP1");
            Debug.Log(MoveP1);
            if (MoveP1 != 0)
            {
                Vector3 movementP1 = new Vector3(0, MoveP1, 0);

                myRigid.velocity = movementP1 * speed * Time.deltaTime;
            }
            
        }
        else
        {
            float MoveP2 = Input.GetAxis("VerticalP2");
            Debug.Log(MoveP2);
            if (MoveP2 != 0)
            {
                Vector3 movementP2 = new Vector3(0, MoveP2, 0);

                myRigid.velocity = movementP2 * speed * Time.deltaTime;
            }

        }
    }
}
