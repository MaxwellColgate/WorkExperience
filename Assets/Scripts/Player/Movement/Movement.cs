using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public  Rigidbody body;

    [Tooltip("The player's camera manager")]
    [SerializeField] CameraManager cameraMan;

    [Tooltip("The player's SFX audio source")]
    [SerializeField] AudioSource playerSFXSource;

    [Tooltip("The player's jump sound effect")]
    [SerializeField] AudioClip jumpSFX;

    public float forwardforce = 300;

    [Tooltip("How long you have to wait (in seconds) after turning before you can turn again")]
    public float waitBetweenTurns = 0.3f;

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
            body.velocity = new Vector2(body.velocity.x, jumpforce);
            playerSFXSource.PlayOneShot(jumpSFX);

        }

        //Rotate left (A key or left arrow)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            if(currentTurnWait < waitBetweenTurns) { return; }
            transform.Rotate(0, -90f, 0);
            cameraMan.SwitchCameraPos(CameraManager.cameraPositions.defaultLeft, 0.02f);
            currentTurnWait = 0;
        }

        //Rotate Right (D key or right arrow)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentTurnWait < waitBetweenTurns) { return; }
            transform.Rotate(0, 90f, 0);
            cameraMan.SwitchCameraPos(CameraManager.cameraPositions.defaultRight, 0.02f);
            currentTurnWait = 0;
        }

        // If the player is recharging their turn, continue the recharge
        if(currentTurnWait < waitBetweenTurns) { currentTurnWait += Time.deltaTime; }

    }
}
