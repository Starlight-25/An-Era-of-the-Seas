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
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            infoText.gameObject.SetActive(true);
            infoText.text = "Vous regardez: " + hit.collider.gameObject.name;
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }
    }
}
