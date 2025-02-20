using System;
using TMPro;
using UnityEngine;

public class InteractorHandler : MonoBehaviour
{
    private float rayDistance = 3f;

    public LayerMask interactableLayer;
    [SerializeField] private TextMeshProUGUI infoText;

    
    
    
    
    private void Update()
    {
        ShowInteractorText();
        
        if (Input.GetKeyDown(KeyCode.E)) HandleInteractorPressed();
    }

    
    
    
    
    private void ShowInteractorText()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            infoText.gameObject.SetActive(true);
            infoText.text = "E -> " + hit.collider.gameObject.name;
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }
    }


    
    
    
    private void HandleInteractorPressed()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer)) HandleAction(hit.collider.gameObject);
        else HandleExitHelm();
    }
    
    
    
    
    
    private void HandleAction(GameObject hitedGameObject)
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

    
    
    
    
    private void HandleExitHelm()
    {
        if (Input.GetKeyDown(KeyCode.E) && BoatState.inHelm) HelmInteractor1.SwitchCameras();
    }
}
