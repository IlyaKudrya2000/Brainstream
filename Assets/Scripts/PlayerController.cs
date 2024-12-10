using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float gravity = -9.81f;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Vector3 velocity;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    [Header("Jump")]
    public float jumpHeight = 3f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        IsGrounded();
        MyInput();
        MovePlayer();
        Gravity();
        Jump();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= 1.5f;
        }

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);
    }


    private void Gravity()
    {
        velocity.y += 3 * gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
