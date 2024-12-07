using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;
using Directory = System.IO.Directory;
using File = UnityEngine.Windows.File;
using Input = UnityEngine.Input;

public class PseudoMenu : MonoBehaviour
{
    public GameObject PseudoCanvas;
    public GameObject MainMenuCanvas;
    public TMP_InputField PseudoInputField;


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
        
        StreamWriter sw = new StreamWriter(savepath);
        sw.Write(modelcontent);
        sw.Close();
        
        ReturnButtonClicked();
    }
}
