using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpForce;
    public float gravityScale;

    private Vector3 moveDirection;

    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Store the Y component of moveDirection (to preserve jump and gravity effects)
        float yStore = moveDirection.y;

        // Reset moveDirection to zero before applying movement input
        moveDirection = Vector3.zero;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle and smooth rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate the movement direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection = moveDir.normalized * speed;
        }

        // Restore the Y component (gravity/jump effect)
        moveDirection.y = yStore;

        // Apply gravity and check for jump
        if (controller.isGrounded)
        {
            moveDirection.y = 0f; // Reset Y direction when grounded

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce; // Apply jump force when jumping
            }
        }
        else
        {
            // Apply gravity when not grounded
            moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        }

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);
    }
}