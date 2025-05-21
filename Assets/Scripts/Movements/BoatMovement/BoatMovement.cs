using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    public Rigidbody BoatBody;
    public float speed = 1f; // Should change according to wind...
    private BoatState BoatState;
    private Transform HelmCamera;
    private float mouseSensitivity = 25f;
    private float yRotationHelm = 0f;
    
    

    private void Start()
    {
        BoatState = transform.GetComponent<BoatState>();
        HelmCamera = transform.Find("HelmCamera");
    }

    
    
    
    
    private void Update()
    {
        if (!BoatState.isAnchored) MoveBoatForward(speed); 
        
        if (BoatState.inHelm) // If the player IS in the helm menu, then he can be able to move the boat. and the camera of the helm
        {
            HandleKeyRotation();
            HandleMouseRotation();
        } 
    }

    
    
    
    
    private void HandleKeyRotation()
    {
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1;
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1;
            
        Quaternion deltaRotation = Quaternion.Euler(0f, horizontalInput * 50 * Time.fixedDeltaTime, 0f);
        BoatBody.MoveRotation(BoatBody.rotation * deltaRotation);
    }

    
    
    
    
    private void HandleMouseRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        yRotationHelm -= mouseX;
        yRotationHelm = Mathf.Clamp(yRotationHelm, -90f, 90f);
        HelmCamera.localRotation = Quaternion.Euler(0f, yRotationHelm, 0f);
    }
    
    
    
    
    
    private void MoveBoatForward(float movementSpeed)
    {
        Vector3 forwardMove = transform.forward * movementSpeed;
        BoatBody.linearVelocity = forwardMove;
    }
}

/* Trigonometry of sailing: https://www.youtube.com/watch?v=_zDF40XFWN4
Real life data for optimal angle between the wind and the sail, for optimal speed. (theta = 38°)
Conducted at the University of Miami (Rosenstiel School of Marine and Atmospheric Science)
To learn more, see pdf on Discord.
*/