using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMovementTutorial : MonoBehaviour
{
    private float playerSpeed = 20.0f;
    private float playerSprintSpeed = 30f;
    private float jumpHeight = 3f;
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private Rigidbody playerBody;

    public Transform Orientation;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Input Actions")]
    public InputActionReference moveAction; // expects Vector2
    public InputActionReference jumpAction; // expects Button
    public InputActionReference sprintAction;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        sprintAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        sprintAction.action.Disable();
    }

    public void Start()
    {

        playerBody = GetComponent<Rigidbody>();
        playerBody.freezeRotation = true;

    }

    void Update()
    {

        Movement();
        Jump();

        

    }

    public void Jump()
    {

        // Jump
        if (jumpAction.action.triggered && controller.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

    }

    public void Movement()
    {

        if(sprintAction.action.IsPressed())
        {
            playerSpeed = playerSprintSpeed;
        }
        else
        {

            playerSpeed = 20f;

        }

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = (Orientation.forward * input.y + Orientation.right * input.x).normalized;

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }

    
}