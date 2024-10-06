using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private CharacterController controller;
    private float moveSpeedY = 0;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        if (Input.GetKey(KeyCode.Space))
        {
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= 3; // ¡Â„
        }
       // √–¿¬»“¿÷»ﬂ?

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
