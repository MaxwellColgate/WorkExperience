using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public  Rigidbody body;

    [Tooltip("The player's camera manager")]
    [SerializeField] CameraManager cameraMan;

    public float forwardforce = 300;

    [Tooltip("How long you have to wait (in seconds) after turning before you can turn again")]
    public float waitBetweenTurns = 0.2f;

    public float jumpforce = 5f;

    public bool isGrounded; // Is the player grounded?

    float currentTurnWait; // How long the player has waited since their last turn

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.drag = 0f;
    }

    private void Update()
    {
        body.velocity = new Vector3(transform.forward.x * forwardforce * Time.deltaTime, body.velocity.y, transform.forward.z * forwardforce * Time.deltaTime);

        //jump input
        if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            isGrounded = false;
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        //Rotate left (A key)
        if (Input.GetKeyDown(KeyCode.A) && currentTurnWait >= waitBetweenTurns) 
        {
            transform.Rotate(0, -90f, 0);
            cameraMan.SwitchCameraPos(CameraManager.cameraPositions.defaultLeft, 0.02f);
            currentTurnWait = 0;
        }

        //Rotate Right (D key )
        if (Input.GetKeyDown(KeyCode.D) && currentTurnWait >= waitBetweenTurns)
        {
            transform.Rotate(0, 90f, 0);
            cameraMan.SwitchCameraPos(CameraManager.cameraPositions.defaultRight, 0.02f);
            currentTurnWait = 0;
        }

        // If the player is recharging their turn, continue the recharge
        if(currentTurnWait < waitBetweenTurns) { currentTurnWait += Time.deltaTime; }

    }
}
