using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerControls : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float moveSpeed = 3f;
    Vector2 moveInput;
    Vector3 movement;

    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] float jumpGravity = 0.75f;
    bool isJumping = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (characterController.isGrounded && !isJumping) isJumping = true;
    }

    private void FixedUpdate()
    {
        movement.x = moveInput.x * moveSpeed;

        movement.z = moveInput.y * moveSpeed;

        if (characterController.isGrounded)
        {
            movement.y = -jumpGravity * 0.1f;

            if (isJumping)
            {
                movement.y = jumpSpeed;
                isJumping = false; 
            }
        }
        else
        {
            movement.y -= jumpGravity * (movement.y > 0 ? 1 : 1.25f);
        }

        characterController.Move(movement * Time.fixedDeltaTime);
    }
}
