using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Float value that is used to determine the players movement
    public float moveSpeed;
    // Rigid body used to give our player physics and collision
    public Rigidbody theRB;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
