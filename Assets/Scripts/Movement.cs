using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public  Rigidbody body;
    public float forwardforce = 2000f;
    public float sidewaysforce = 1000f;
    public float jumpforce = 5f;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        body.AddForce(0, 0, forwardforce * Time.deltaTime);

        if (Input.GetKey("d")) 
        {
            body.AddForce(sidewaysforce*Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a")) 
        {
            body.AddForce(-sidewaysforce*Time.deltaTime,0,0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
}
