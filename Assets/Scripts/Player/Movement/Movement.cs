using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public  Rigidbody body;

    [Tooltip("The player's camera manager")]
    [SerializeField] CameraManager cameraMan;

    public float forwardforce = 300;
    public float jumpforce = 5f;

    public bool isGrounded;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.drag = 0f;
    }

    private void Update()
    {
        body.velocity = new Vector3(transform.forward.x * forwardforce * Time.deltaTime, body.velocity.y, transform.forward.z * forwardforce * Time.deltaTime);

        //jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            isGrounded = false;
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        //Rotate left (A key)
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.Rotate(0, -90f, 0);
            cameraMan.SwitchCameraPos(CameraManager.cameraPositions.defaultLeft, 0.02f);
        }

        //Rotate Right (D key )
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90f, 0);
            cameraMan.SwitchCameraPos(CameraManager.cameraPositions.defaultRight, 0.02f);
        }

    }
}
