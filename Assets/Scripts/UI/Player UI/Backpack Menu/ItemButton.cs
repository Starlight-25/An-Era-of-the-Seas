using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI Level;

    private Item Item;



    
    public void Init(Item item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        Level.text = "Lvl " + item.Level;
    }
}
