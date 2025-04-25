using UnityEngine;

public class MultiplayerUIManager : MonoBehaviour
{
    public GameObject winnerCanvas;
    public GameObject othersCanvas;

    public void ShowWinnerUI()
    {
        winnerCanvas.SetActive(true);
        othersCanvas.SetActive(false);
    }

    public void ShowOtherUI()
    {
        winnerCanvas.SetActive(false);
        othersCanvas.SetActive(true);
    }
}

