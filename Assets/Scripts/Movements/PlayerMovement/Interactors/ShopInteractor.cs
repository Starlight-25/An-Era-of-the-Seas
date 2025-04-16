using UnityEngine;

public static class ShopInteractor
{
    private static PlayerUIManager playerUIManager = GameObject.Find("UI").transform.Find("Player UI (Canvas)").GetComponent<PlayerUIManager>();
    private static GameObject ShopCanvas = GameObject.Find("UI").transform.Find("Shop (Canvas)").gameObject;

    public static void ShowShop(string type)
    {
        ShopCanvas.GetComponent<ShopManager>().ShopContent(type);
        playerUIManager.ShopCanvasShow();
    }
}