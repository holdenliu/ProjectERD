using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;

    public float raycastRadius = 0.5f; // Radius of the ring of raycasts
    public float raycastHeight = 0.1f; // Height above the ground for the raycasts
    public float raycastLength = 1f; // Length of the raycasts
    public bool isGrounded; // Public bool to indicate if the player is grounded

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Perform raycast checks to determine if grounded
        CheckGrounded();

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    // Method to check if the player is grounded using raycasts
    private void CheckGrounded()
    {
        // Center raycast
        isGrounded = Physics.Raycast(transform.position + Vector3.up * raycastHeight, Vector3.down, raycastLength);

        // Ring of raycasts around the player
        int numRays = 8; // Number of raycasts in the ring
        for (int i = 0; i < numRays; i++)
        {
            float angle = i * (360f / numRays);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            // Perform raycast at the calculated position
            if (Physics.Raycast(transform.position + Vector3.up * raycastHeight, direction, raycastLength))
            {
                isGrounded = true;
                break; // If any ray detects ground, we can exit early
            }
        }
    }

    // Draw raycasts in the Scene view for visibility
    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;

        // Draw center raycast
        Gizmos.DrawLine(transform.position + Vector3.up * raycastHeight, transform.position + Vector3.up * (raycastHeight - raycastLength));

        // Draw ring of raycasts
        int numRays = 8; // Number of raycasts in the ring
        for (int i = 0; i < numRays; i++)
        {
            float angle = i * (360f / numRays);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            Gizmos.DrawLine(transform.position + Vector3.up * raycastHeight, transform.position + Vector3.up * (raycastHeight - raycastLength) + direction * raycastRadius);
        }
    }
}
