using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Collider platformCollider; // Public collider for the platform
    public Transform startPoint; // Reference to the starting point transform
    public Transform stopPoint; // Reference to the stopping point transform
    public float travelTime = 2f; // Time to travel from start to stop

    private Vector3 startPos; // Start position of the platform
    private Vector3 stopPos; // Stop position of the platform
    private float journeyLength; // Length of the journey
    private float startTime; // Time when the movement starts
    private bool isMovingToStop = true; // Indicates the direction of movement


    void Start()
    {
        // Initialize positions based on the assigned Transforms
        startPos = startPoint.position;
        stopPos = stopPoint.position;
        journeyLength = Vector3.Distance(startPos, stopPos);
        startTime = Time.time;
    }

    void Update()
    {

        // Calculate the distance traveled based on the time elapsed
        float distanceCovered = (Time.time - startTime) / travelTime * journeyLength;

        // Lerp the platform position based on the direction of movement
        if (isMovingToStop)
        {
            transform.position = Vector3.Lerp(startPos, stopPos, distanceCovered / journeyLength);
        }
        else
        {
            transform.position = Vector3.Lerp(stopPos, startPos, distanceCovered / journeyLength);
        }

        // Check if the platform has reached the end of its journey
        if (distanceCovered >= journeyLength)
        {
            // Reset the start time and toggle the direction
            startTime = Time.time;
            isMovingToStop = !isMovingToStop;
        }
    }
}
