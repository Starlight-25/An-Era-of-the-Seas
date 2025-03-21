using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUICanvas;

    public void ReturnButtonClicked()
    {
        PlayerUICanvas.SetActive(true);
        transform.GameObject().SetActive(false);
        transform.GetComponent<ShopManager>().ShopContent("");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }
}