using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;    
    
    public Transform playerBody;
    
    float xRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY; // Rotate the CAMERA on the Y axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // So that the player doesn't become an owl (can't move the camera more than 90°)
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); // Rotate the CHARACTER on the X axis
    }
}
