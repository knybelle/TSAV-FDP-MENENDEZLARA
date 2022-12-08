using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float velocidadGiro = 1.2f;
    public Vector3 move;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded; 
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        move = Vector3.ClampMagnitude(gameObject.transform.right * Input.GetAxis("Horizontal") + gameObject.transform.forward * Input.GetAxis("Vertical"), 1);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero && Input.GetAxis("Vertical") >= 0)
        {
            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, move, velocidadGiro * Time.deltaTime);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
