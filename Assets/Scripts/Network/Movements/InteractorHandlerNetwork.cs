using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class InteractorHandlerNetwork : NetworkBehaviour
{
    private LayerMask interactableLayer;
    private TextMeshProUGUI infoText;
    private Transform Boat;
    private Transform Camera;
    private BoatStateNetwork BoatStateNetwork;

    
    
    

    private void Start()
    {
        Camera = transform.Find("Camera");
        interactableLayer = LayerMask.GetMask("Interactable");
        infoText = transform.Find("Interactor Text").Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }


    
    
    
    private void Update()
    {
        if (!IsOwner) return;
        
        ShowInteractorText(3f);
        ShowInteractorText(10f);
        
        if (Input.GetKeyDown(KeyCode.E)) HandleInteractorPressed();
        if (Input.GetKeyDown(KeyCode.X) && Boat is not null && !BoatStateNetwork.inHelm) ExitBoat(Boat);
    }

    
    
    
    
    private void ShowInteractorText(float distance)
    {
        Ray ray = new Ray(Camera.position, Camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, interactableLayer))
            infoText.text = GetInteractorText(hit.collider.name);
        else infoText.text = "";
    }


    private string GetInteractorText(string name)
    {
        switch (name)
        {
            case "Boat Interactor" when Boat is null:
                return "E to enter in the Boat";
            case "Boat Interactor" when Boat is not null:
                return "";
            case "Capstan" when Boat is not null && !BoatStateNetwork.isAnchored:
                return "E to Enable anchor";
            case "Capstan" when Boat is not null && BoatStateNetwork.isAnchored:
                return "E to Disable anchor";
            case "Helm" when Boat is not null && !BoatStateNetwork.inHelm:
                return "E to enter Helm mode";
            case "Helm" when Boat is not null && BoatStateNetwork.inHelm:
                return "E to exit Helm mode";
            default:
                return "";
        }
    }

    
    
    
    private void HandleInteractorPressed()
    {
        Ray ray = new Ray(Camera.position, Camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, interactableLayer)) HandleAction(hit.collider.gameObject, 3f);
        else
        {
            if (Boat is not null && BoatStateNetwork.inHelm)
            {
                SwitchCameraHelm(Camera.GetComponent<Camera>(), Boat.Find("HelmCamera").GetComponent<Camera>());
                EnterBoat(Boat);
            }
        }
        if (Physics.Raycast(ray, out hit, 10f, interactableLayer)) HandleAction(hit.collider.gameObject, 10f);
    }
    
    
    
    
    
    private void HandleAction(GameObject hitedGameObject, float distance)
    {
        if (distance == 3f)
        {
            switch (hitedGameObject.name)
            {
                case "Capstan":
                    BoatStateNetwork.isAnchored = !BoatStateNetwork.isAnchored;
                    break;
                case "Helm":
                    SwitchCameraHelm(Camera.GetComponent<Camera>(), Boat.Find("HelmCamera").GetComponent<Camera>());
                    EnterBoat(hitedGameObject.transform.parent);
                    break;
            }
        }
        else if (distance == 10f)
        {
            switch (hitedGameObject.name)
            {
                case "Boat Interactor" when Boat is null:
                    EnterBoat(hitedGameObject.transform.parent);
                    break;
            }
        }
    }

    
    
    

    private void EnterBoat(Transform boat)
    {
        Boat = boat;
        BoatStateNetwork = Boat.GetComponent<BoatStateNetwork>();
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = boat.position + new Vector3(0, 4, 0);
        transform.GetComponent<CharacterController>().enabled = true;
    }

    public void ExitBoat(Transform boat)
    {
        Boat = null;
        BoatStateNetwork = null;
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = boat.position + new Vector3(10, 4, 10);
        transform.GetComponent<CharacterController>().enabled = true;
    }









    private void SwitchCameraHelm(Camera playerCam, Camera helmCam)
    {
        BoatStateNetwork.inHelm = !BoatStateNetwork.inHelm;
        playerCam.enabled = !playerCam.enabled;
        helmCam.enabled = !helmCam.enabled;
        transform.SetParent(BoatStateNetwork.inHelm ? Boat : null);
    }
}
