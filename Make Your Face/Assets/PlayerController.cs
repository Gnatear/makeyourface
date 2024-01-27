using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;

    private Vector2 moveInput;

    public float speed;

    private Vector3 playerVelocity;

    private bool grounded;

    public float gravity = -9.8f;

    public float jumpForce = 2f;

    public Camera cam;
    
    private Vector2 lookPos;

    private float xRotation = 0f;

    public float xSens = 30f;

    public float ySens = 30f;

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
    public void onJump(InputAction.CallbackContext context)
    {
        jump();
    }
    
    public void onLook(InputAction.CallbackContext context)
    {
        lookPos=context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent < CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        movePlayer();
        playerlook();
    }

    public void movePlayer()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void jump()
    {
        if (grounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3f * gravity);
        }
    }

    public void playerlook()
    {
        xRotation = (lookPos.y * Time.deltaTime) * ySens;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        transform.Rotate(Vector3.up * (lookPos.x * Time.deltaTime) * xSens);
    }
    
}
