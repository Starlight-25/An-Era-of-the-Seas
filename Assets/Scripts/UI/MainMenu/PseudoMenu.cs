using TMPro;
using UnityEngine;
using Input = UnityEngine.Input;
using Newtonsoft.Json.Linq;

public class PseudoMenu : MonoBehaviour
{
    [SerializeField] private GameObject PseudoCanvas;
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private TMP_InputField PseudoInputField;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnButtonClicked();
        }
    }


    public void ReturnButtonClicked()
    {
        PseudoCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    public void ConfirmButtonClicked()
    {
        string pseudoinput = PseudoInputField.text;
        if (pseudoinput == "")
        {
            return;
        }
        string savepath = Application.persistentDataPath + "/playerData.json";
        string modelcontent = Resources.Load<TextAsset>("saveModel").text;
        System.IO.File.WriteAllText(savepath, modelcontent);
        string settingsPath = Application.persistentDataPath + "/settings.json";
        string settingsModelContent = Resources.Load<TextAsset>("settingsModel").text;
        System.IO.File.WriteAllText(settingsPath, settingsModelContent);

        InitPseudo(savepath, pseudoinput);
        
        ReturnButtonClicked();
    }

    private void InitPseudo(string savepath, string pseudo)
    {
        JObject jsonData = JObject.Parse(System.IO.File.ReadAllText(savepath));
        jsonData["Pseudo"] = pseudo;
        System.IO.File.WriteAllText(savepath, jsonData.ToString());
    }
}
