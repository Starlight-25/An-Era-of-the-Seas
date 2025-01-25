using UnityEngine;

public class CaptureSprite : MonoBehaviour
{
    public string fileName = "C:/Users/linje/Documents/capturedSprite.png";

    void Start()
    {
        ScreenCapture.CaptureScreenshot(fileName);
    }
}