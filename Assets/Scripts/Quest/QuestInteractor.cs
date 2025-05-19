using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class QuestData
{
    public List<List<string>> Quest { get; set; }
}





public class QuestInteractor : MonoBehaviour
{
    private List<List<string>> QuestTexts;
    private Transform Camera;
    private TextMeshProUGUI infoText;
    private QuestMenu QuestMenu;





    private void Start()
    {
        QuestTexts = JsonConvert
            .DeserializeObject<QuestData>(Resources.Load<TextAsset>("Quest/Quest").text)
            .Quest;
        Camera = transform.Find("Camera");
        infoText = transform.Find("Interactor Text").Find("QuestText").GetComponent<TextMeshProUGUI>();
        QuestMenu = FindFirstObjectByType<QuestMenu>();
    }


    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, 3f) && hit.collider.CompareTag("Quest"))
        {
            infoText.text = "E to do Quest";
            if (Input.GetKeyDown(KeyCode.E))
                QuestMenu.ShowQuestMessage(QuestTexts[hit.transform.GetComponent<QuestNPC>().QuestLevel]);
        }
        else infoText.text = "";
    }
}