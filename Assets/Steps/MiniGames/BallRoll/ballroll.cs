using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballroll : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public float maxAngularVelocity;
    public Transform camera;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        theRB.maxAngularVelocity = maxAngularVelocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Capture movement input relative to the camera's orientation
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moveDirection = (camera.forward * Input.GetAxis("Vertical")) + (camera.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            theRB.AddForce(Physics.gravity * gravityScale);
            // Add force for horizontal movement (on x and z axes)
            theRB.AddForce(new Vector3(moveDirection.x, 0f, moveDirection.z), ForceMode.Force);
        }
            

        

    }
}
