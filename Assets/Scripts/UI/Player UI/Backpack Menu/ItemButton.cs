using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI Text;



    
    public void InitItem(Item item)
    {
        Icon.sprite = item.Icon;
        Text.text = "Lvl " + item.Level;
    }

    public void InitMaterial(Material material)
    {
        Icon.sprite = material.Icon;
        Text.text = material.Number.ToString();
    }
}