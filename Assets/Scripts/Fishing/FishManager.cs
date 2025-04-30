using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishManager : MonoBehaviour
{
    private FishingMenuManager FishingMenuManager;
    private RectTransform ParentRectTransform;
    private float x;
    private float y;





    private void Start()
    {
        FishingMenuManager = transform.parent.parent.GetComponent<FishingMenuManager>();
        ParentRectTransform = transform.parent.GetComponent<RectTransform>();
        (x, y) = (transform.position.x, transform.position.y);
    }

    
    
    

    private void Update()
    {
        transform.position = new Vector3(x, y, transform.position.z);

        x += 10;
        y += Mathf.Sin(x/50) * 10;

        if (x > ParentRectTransform.rect.width)
        {
            x = 0;
            y = Random.Range(100, ParentRectTransform.rect.height - 100);
        }
    }

    
    
    
    
    public void FishClicked()
    {
        FishingMenuManager.AddFishToInventory();
        Destroy(gameObject);
    }
}