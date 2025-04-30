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
                infoText.text = GetInteractorText(hit.collider.gameObject.name);
            }
            else if (distance == 3f && hit.collider.gameObject.name != "Boat Interactor")
            {
                infoText.text = GetInteractorText(hit.collider.gameObject.name);
            }
        }
        else
        {
            infoText.text = "";
        }
    }


    private string GetInteractorText(string name)
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
            case string shop when shop == "Armorer" || shop == "Mage" || shop == "Boat Salesman" || shop == "Crew Agent":
                return $"E to buy from the {shop}";
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
                case "Armorer":
                    ShopInteractor.ShowShop("Weapon");
                    break;
                case "Mage":
                    ShopInteractor.ShowShop("Stigmata");
                    break;
                case "Boat Salesman":
                    ShopInteractor.ShowShop("Boat");
                    break;
                case "Crew Agent":
                    ShopInteractor.ShowShop("Crew");
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
        BoatState.inBoat = true;

        // Disable CharacterController to manually set position
        var controller = GetComponent<CharacterController>();
        controller.enabled = false;

        // Position the player on the boat
        transform.position = boat.position + new Vector3(0, 2, 0);

        // Enable CharacterController
        controller.enabled = true;

        // Set the current boat in PlayerMovement to track its movement
        GetComponent<PlayerMovement>().SetBoat(boat);
    }

    public void ExitBoat(Transform boat)
    {

        BoatState.inBoat = false;

        // Disable CharacterController to manually set position
        var controller = GetComponent<CharacterController>();
        controller.enabled = false;

        // Clear the current boat in PlayerMovement
        GetComponent<PlayerMovement>().ClearBoat();

        // Position the player off the boat
        transform.position = boat.position + boat.forward * -10f + boat.up * 5f;

        // Enable CharacterController
        controller.enabled = true;
    
    }
}
