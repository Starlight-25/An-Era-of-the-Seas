using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestMenu : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    [SerializeField] private TextMeshProUGUI QuestText;
    private float displayduration= 10f;




    
    public void ShowQuestMessage(List<string> msg) => StartCoroutine(ShowQuestMessageCoroutine(msg));

    private IEnumerator ShowQuestMessageCoroutine(List<string> msg)
    {
        Background.SetActive(true);
        foreach (var message in msg)
        {
            QuestText.text = message;
            yield return new WaitForSeconds(displayduration);
        }
        QuestText.text = "";
        Background.SetActive(false);
    }
}