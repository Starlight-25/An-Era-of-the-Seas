using System;
using TMPro;
using UnityEngine;

public class TreasureInteractor : MonoBehaviour
{
    private LayerMask interactableLayer;
    private Transform Camera;
    private TextMeshProUGUI infoText;

    private void Start()
    {
        interactableLayer = LayerMask.GetMask("Interactable");
        Camera = transform.Find("Camera");
        infoText = transform.Find("Interactor Text").Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        Ray ray = new Ray(Camera.position, Camera.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f, interactableLayer) && hit.collider.CompareTag("Chest"))
        {
            infoText.text = "E to interact with the Chest";
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<MultiplayerInteractor>().Interact();
            }
        }
    }
}