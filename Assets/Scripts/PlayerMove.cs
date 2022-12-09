using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    CharacterController controller;

    public float speed;

    public Transform cam;
    double gravity = 0;
    public Vector3 movement;


    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;

        movement = cam.transform.right * Horizontal + cam.transform.forward * Vertical;
        movement.y = 0;
        gravity -= 9.81 * Time.deltaTime;
        if (controller.isGrounded)
        {
            gravity = 0;
        }


        controller.Move(movement * Time.deltaTime + Vector3.up * (float)gravity);

        if (movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cam.GetComponent<CameraMove>().sensivity * Time.deltaTime);


            Quaternion camRotation = cam.rotation;
            camRotation.x = 0f;
            camRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, camRotation, 0.1f);

        }
    }

}
