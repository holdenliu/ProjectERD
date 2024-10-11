using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ballTag; // Set this to "yellow", "red", "blue", or "green" in the Inspector

    private void Start()
    {
        gameObject.tag = ballTag; // Assign the tag
    }
}
