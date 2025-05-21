using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class CreditMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject CreditCanvas;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private TextMeshProUGUI CreditsText;


    
    
    
    private void Start()
    {
        CreditsText.text = Resources.Load<TextAsset>("credits").text;
    }

    
    
    
    
    public void ReturnButtonClicked()
    {
        CreditCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
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