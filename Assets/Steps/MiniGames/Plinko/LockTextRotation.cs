using UnityEngine;

public class LockTextRotation : MonoBehaviour
{
    public Transform ballTransform;  // Reference to the ball (the sphere)
    private Vector3 offset;          // To store the initial position offset

    void Start()
    {
        // Calculate and store the initial offset between the text and the ball
        offset = transform.position - ballTransform.position;
    }

    void LateUpdate()
    {
        // Update the position with the initial offset but lock the rotation
        transform.position = ballTransform.position + offset;

        // Lock the rotation to zero (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
