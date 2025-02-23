using System;
using TMPro;
using UnityEngine;

public class InteractorHandler : MonoBehaviour
{
    public LayerMask interactableLayer;
    [SerializeField] private TextMeshProUGUI infoText;

    
    
    
    
    private void Update()
    {
        ShowInteractorText(3f);
        ShowInteractorText(10f);
        
        if (Input.GetKeyDown(KeyCode.E)) HandleInteractorPressed();
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
            case "Capstan" when !BoatState.isAnchored:
                return "E to Enable anchor";
            case "Capstan" when BoatState.isAnchored:
                return "E to Disable anchor";
            case "Helm" when !BoatState.inHelm:
                return "E to enter Helm mode";
            case "Helm" when BoatState.inHelm:
                return "E to exit Helm mode";
            case "Boat Interactor" when !BoatState.inBoat:
                return "E to enter in the Boat";
            case "Boat Interactor" when BoatState.inBoat:
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
        if (Physics.Raycast(ray, out hit, 10f, interactableLayer)) HandleAction(hit.collider.gameObject, 10f);
        else HandleExitHelm();
    }
    
    
    
    
    
    private void HandleAction(GameObject hitedGameObject, float distance)
    {
        if (distance == 3f)
        {
            switch (hitedGameObject.name)
            {
                case "Capstan":
                    BoatState.isAnchored = !BoatState.isAnchored;
                    break;
                case "Helm":
                    HelmInteractor1.Init(transform.parent, GameObject.Find("BoatWSail").transform);
                    HelmInteractor1.SwitchCameras();
                    break;
            }
        }
        else if (distance == 10f)
        {
            switch (hitedGameObject.name)
            {
                case "Boat Interactor" when !BoatState.inBoat:
                    BoatState.inBoat = true;
                    EnterBoat(hitedGameObject);
                    break;
            }
        }
    }

    
    
    
    
    private void HandleExitHelm()
    {
        if (Input.GetKeyDown(KeyCode.E) && BoatState.inHelm) HelmInteractor1.SwitchCameras();
    }

    
    
    

    private void EnterBoat(GameObject boatInteractor)
    {
        Transform boat = boatInteractor.transform.parent;
        Transform player = infoText.transform.parent.parent;
        player.GetComponent<CharacterController>().enabled = false;
        player.position = boat.position + new Vector3(0, 4, 0);
        player.GetComponent<CharacterController>().enabled = true;
    }

    public static void ExitBoat(Transform boat, Transform player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = boat.position + new Vector3(10, 4, 10);
        player.GetComponent<CharacterController>().enabled = true;
    }
}
