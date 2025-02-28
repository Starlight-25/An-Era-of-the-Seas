using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class InteractorHandlerNetwork : NetworkBehaviour
{
    private LayerMask interactableLayer;
    private TextMeshProUGUI infoText;
    private BoatStateNetwork BoatStateNetwork;

    
    
    

    private void Start()
    {
        interactableLayer = LayerMask.GetMask("Interactable");
        infoText = transform.Find("Interactor Text").Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        BoatStateNetwork = transform.GetComponent<BoatInitHandlerNetwork>().BoatStateNetwork;
    }


    
    
    
    private void Update()
    {
        if (!IsOwner) return;
        
        ShowInteractorText(3f);
        ShowInteractorText(10f);
        
        if (Input.GetKeyDown(KeyCode.E)) HandleInteractorPressed();
        if (Input.GetKeyDown(KeyCode.X) && BoatStateNetwork.inBoat && !BoatStateNetwork.inHelm) ExitBoat(GameObject.Find("BoatTest").transform);
    }

    
    
    
    
    private void ShowInteractorText(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, interactableLayer))
        {
            if (distance == 10f && hit.collider.gameObject.name == "Boat Interactor")
            {
                infoText.gameObject.SetActive(true);
                infoText.text = GetInteractorText(hit.collider.gameObject.name, distance);
            }
            else if (distance == 3f && hit.collider.gameObject.name != "Boat Interactor")
            {
                infoText.gameObject.SetActive(true);
                infoText.text = GetInteractorText(hit.collider.gameObject.name, distance);
            }
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }
    }


    private string GetInteractorText(string name, float distance)
    {
        switch (name)
        {
            case "Capstan" when !BoatStateNetwork.isAnchored:
                return "E to Enable anchor";
            case "Capstan" when BoatStateNetwork.isAnchored:
                return "E to Disable anchor";
            case "Helm" when !BoatStateNetwork.inHelm:
                return "E to enter Helm mode";
            case "Helm" when BoatStateNetwork.inHelm:
                return "E to exit Helm mode";
            case "Boat Interactor" when !BoatStateNetwork.inBoat:
                return "E to enter in the Boat";
            case "Boat Interactor" when BoatStateNetwork.inBoat:
                return "";
            default:
                return "";
        }
    }

    
    
    
    private void HandleInteractorPressed()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, interactableLayer)) HandleAction(hit.collider.gameObject, 3f);
        else
        {
            if (BoatStateNetwork.inHelm)
            {
                HelmInteractor.SwitchCameras();
                EnterBoat(GameObject.Find("BoatTest").transform);
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
                    HelmInteractor.Init(transform.parent, GameObject.Find("BoatTest").transform);
                    HelmInteractor.SwitchCameras();
                    EnterBoat(hitedGameObject.transform.parent);
                    break;
            }
        }
        else if (distance == 10f)
        {
            switch (hitedGameObject.name)
            {
                case "Boat Interactor" when !BoatStateNetwork.inBoat:
                    BoatStateNetwork.inBoat = true;
                    EnterBoat(hitedGameObject.transform.parent);
                    break;
            }
        }
    }

    
    
    

    private void EnterBoat(Transform boat)
    {
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = boat.position + new Vector3(0, 4, 0);
        transform.GetComponent<CharacterController>().enabled = true;
    }

    public void ExitBoat(Transform boat)
    {
        BoatStateNetwork.inBoat = false;
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = boat.position + new Vector3(10, 4, 10);
        transform.GetComponent<CharacterController>().enabled = true;
    }
}
