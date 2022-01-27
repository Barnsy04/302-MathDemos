using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCamera : MonoBehaviour
{

    public float speed = 10;

    private float pitch = 0;
    private float yaw = 0;

    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    void Start()
    {
        
    }

    
    void Update()
    {
        // ===== UPDATE POSITION =====

        float v = Input.GetAxis("Vertical"); // forward / back
        float h = Input.GetAxis("Horizontal"); // left / right (strafe)

        //transform.position += transform.forward * v * Time.deltaTime;
        //transform.position += transform.right * h * Time.deltaTime;

        Vector3 dir = transform.forward * v + transform.right * h;
        if (dir.magnitude > 1) dir.Normalize();
        transform.position += dir * Time.deltaTime * speed;

        // ===== UPDATE ROTATION =====

        float mx = Input.GetAxis("Mouse X"); // yaw (Y)
        float my = Input.GetAxis("Mouse Y"); // pitch (X)

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;

        pitch = Mathf.Clamp(pitch, -89, 89);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

    }
}
