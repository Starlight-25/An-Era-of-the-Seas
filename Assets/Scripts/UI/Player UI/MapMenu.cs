using System;
using UnityEngine;


public class MapMenu : MonoBehaviour
{
    [SerializeField] private GameObject MapCanvas;
    private GameObject PreviousCanvas;

    
    public void SetPreviousCanvas(GameObject previousCanvas) => PreviousCanvas = previousCanvas;
    
    
    public void ReturnButtonClicked()
    {
        MapCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
        PreviousCanvas = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnButtonClicked();
        }
    }
}