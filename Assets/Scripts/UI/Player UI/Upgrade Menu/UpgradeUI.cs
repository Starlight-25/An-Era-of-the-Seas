using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeCanvas;
    public GameObject PreviousCanvas;

    
    public void ReturnButtonClicked()
    {
        UpgradeCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
    }
}
