using UnityEngine;

public static class ShopInteractor
{
    private static PlayerUIManager playerUIManager = GameObject.Find("UI").transform.Find("Player UI Menu").GetComponent<PlayerUIManager>();
    private static GameObject ShopCanvas = GameObject.Find("UI").transform.Find("Shop Menu").gameObject;

    public static void ShowShop(string type)
    {
        ShopCanvas.GetComponent<ShopManager>().ShopContent(type);
        playerUIManager.ShopCanvasShow();
    }
}