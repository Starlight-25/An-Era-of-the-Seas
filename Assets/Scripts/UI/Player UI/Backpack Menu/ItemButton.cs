using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private Image Rarity;
    [SerializeField] private TextMeshProUGUI Text;



    
    public void InitItem(Item item)
    {
        Rarity.sprite = item.RaritySprite;
        Icon.sprite = item.ItemSprite;
        Text.text = "Lvl " + item.Level;
    }

    public void InitMaterial(Material material)
    {
        Rarity.sprite = material.RaritySprite;
        Icon.sprite = material.MaterialSprite;
        Text.text = material.Number.ToString();
    }
}