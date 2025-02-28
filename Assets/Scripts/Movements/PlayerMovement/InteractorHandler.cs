using System;
using TMPro;
using UnityEngine;

public class InteractorHandler : MonoBehaviour
{
    private LayerMask interactableLayer;
    private TextMeshProUGUI infoText;
    private Transform Camera;
    private BoatState BoatState;





    private void Start()
    {
        interactableLayer = LayerMask.GetMask("Interactable");
        infoText = transform.Find("Interactor Text").Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        Camera = transform.Find("Camera");
        BoatState = transform.GetComponent<BoatInitHandler>().BoatState;
    }


    
    
    
    private void Update()
    {
        ShowInteractorText(3f);
        ShowInteractorText(10f);
        
        if (Input.GetKeyDown(KeyCode.E)) HandleInteractorPressed();
        //if (Input.GetKeyDown(KeyCode.X) && BoatState.inBoat && !BoatState.inHelm) ExitBoat(GameObject.Find("BoatTest").transform);
        if (Input.GetKeyDown(KeyCode.X) && BoatState.inBoat && !BoatState.inHelm) ExitBoat(transform.GetComponent<BoatInitHandler>().Boat);
    }

    
    
    
    
    private void ShowInteractorText(float distance)
    {
        Ray ray = new Ray(Camera.position, Camera.forward);
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
        Ray ray = new Ray(Camera.position, Camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, interactableLayer)) HandleAction(hit.collider.gameObject, 3f);
        else
        {
            if (BoatState.inHelm)
            {
                HelmInteractor.SwitchCameras();
                EnterBoat(transform.GetComponent<BoatInitHandler>().Boat);
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
                    BoatState.isAnchored = !BoatState.isAnchored;
                    break;
                case "Helm":
                    HelmInteractor.Init(transform, transform.GetComponent<BoatInitHandler>().Boat);
                    HelmInteractor.SwitchCameras();
                    EnterBoat(hitedGameObject.transform.parent);
                    break;
            }
        }
        else if (distance == 10f)
        {
            switch (hitedGameObject.name)
            {
                case "Boat Interactor" when !BoatState.inBoat:
                    BoatState.inBoat = true;
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
        BoatState.inBoat = false;
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = boat.position + boat.forward * -10f + boat.up * 5f;
        transform.GetComponent<CharacterController>().enabled = true;
    }
}
