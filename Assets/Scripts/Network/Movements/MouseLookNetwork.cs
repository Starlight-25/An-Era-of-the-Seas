using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookNetwork : MonoBehaviour
{
    
    [SerializeField] private float mouseSensitivity = 100;    
    
    private Transform playerBody;
    private Camera playerCamera;
    
    [SerializeField] private Camera[] otherCamera;
    
    float xRotation = 0f;

    //private BoatState BoatState;
    
    
    
    
    
    void Start()
    {
        playerBody = transform.parent;
        playerCamera = GetComponent<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera.enabled = true;

        foreach (Camera camera in otherCamera)
        {
            camera.enabled = false;
        }

        //BoatState = playerBody.GetComponent<BoatInitHandler>().BoatState;
    }
    
    
    
    
    
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
            xRotation -= mouseY; // Rotate the CAMERA on the Y axis
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // So that the player doesn't become an owl (can't move the camera more than 90°)
        
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX); // Rotate the CHARACTER on the X axis
        }
    }
}
