using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public  Rigidbody body;
    public float forwardforce = 2000f;
    public float jumpforce = 5f;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.drag = 5f;
    }
    private void Update()
    {
        //jump input
        body.velocity = transform.forward * forwardforce * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        //Rotate left (A key)
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.Rotate(0, -90f, 0);
        }

        //Rotate Right (D key )
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90f, 0);
        }

    }


}
