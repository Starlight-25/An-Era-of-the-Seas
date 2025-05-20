using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsScrips : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject CreditsCanvas;
    [SerializeField] private TextMeshProUGUI CreditsText;

    
    
    

    private void Start()
    {
        CreditsText.text = Resources.Load<TextAsset>("credits").text;
    }

    
    
    
    
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

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(CreditsText, eventData.position, null);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = CreditsText.textInfo.linkInfo[linkIndex];
            string linkId = linkInfo.GetLinkID();
            Application.OpenURL(linkId);
        }
    }
}
