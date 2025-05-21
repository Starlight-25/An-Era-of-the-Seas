using System;
using UnityEngine;

public class SellMenu : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUI;
    [SerializeField] private GameObject SellMenuObject;

    public void ReturnButtonClicked()
    {
        PlayerUI.SetActive(true);
        SellMenuObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }
}