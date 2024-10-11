using UnityEngine;

public class Goal : MonoBehaviour
{
    public int scoreValue; // Set this in the Inspector for different goals
    public ScoreManager scoreManager;
    public Transform Spawn;

    public float minForce = 5f; // Minimum force to apply
    public float maxForce = 10f; // Maximum force to apply

    private void OnCollisionEnter(Collision collision)
    {
        // Print the name of any object that enters the collision zone
        Debug.Log($"Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("yellow"))
        {
            scoreManager.AddPoints("yellow", scoreValue);
        }
        else if (collision.gameObject.CompareTag("red"))
        {
            scoreManager.AddPoints("red", scoreValue);
        }
        else if (collision.gameObject.CompareTag("blue"))
        {
            scoreManager.AddPoints("blue", scoreValue);
        }
        else if (collision.gameObject.CompareTag("green"))
        {
            scoreManager.AddPoints("green", scoreValue);
        }
        collision.transform.position = Spawn.position;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Set the velocity to zero
            rb.angularVelocity = Vector3.zero; // Optionally set angular velocity to zero

            // Generate a random force in the range specified
            float randomForce = Random.Range(minForce, maxForce);
            // Randomly choose a direction (1 for right, -1 for left)
            int direction = Random.Range(0, 2) * 2 - 1; // Generates either -1 or 1
            // Apply the force in the global X direction
            rb.AddForce(new Vector3(direction * randomForce, 0, 0), ForceMode.Impulse);
        }
    }
}
