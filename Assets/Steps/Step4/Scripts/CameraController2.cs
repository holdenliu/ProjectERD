using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    public Transform Pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        Pivot.transform.position = target.transform.position;
        Pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Pivot.transform.position = target.transform.position;

        // Get the X position of the mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        Pivot.Rotate(0, horizontal, 0);

        // Get the Y position of the mouse & rotate the pivot (inverted if needed)
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertY)
        {
            Pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            Pivot.Rotate(-vertical, 0, 0);
        }

        // Clamping the up/down camera rotation to avoid flipping
        float currentXRotation = Pivot.eulerAngles.x;
        if (currentXRotation > 180) currentXRotation -= 360;  // Normalize angle to -180 to 180

        currentXRotation = Mathf.Clamp(currentXRotation, minViewAngle, maxViewAngle);
        Pivot.rotation = Quaternion.Euler(currentXRotation, Pivot.eulerAngles.y, 0);

        // Move the camera based on the current rotation of the target & the original offset
        float desiredYAngle = Pivot.eulerAngles.y;
        float desiredXAngle = Pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        // Ensure the camera doesn't go below the player's position
        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, target.position.y - 0.5f), transform.position.z);

        transform.LookAt(target);
    }
}
