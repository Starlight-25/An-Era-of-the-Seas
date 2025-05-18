using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    private GameObject chest;
    
    
    
    
    
    private void Update()
    {
        chest = GameObject.FindGameObjectWithTag("Chest");
        if (chest != null)
        {
            float distance = Vector3.Distance(transform.position, chest.transform.position);
            distanceText.text = $"Distance to chest: {distance:F2} m";
        }
        else distanceText.text = "";
    }
}