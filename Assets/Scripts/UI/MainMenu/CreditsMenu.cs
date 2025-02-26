using UnityEngine;

public class CreditsScrips : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject CreditsCanvas;
    
    public void ReturnButtonClicked()
    {
        CreditsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnButtonClicked();
        }
    }
}
