using UnityEngine;

public static class HelmInteractor1
{
    private static Transform Player;
    private static Camera PlayerCamera;
    private static Transform Boat;
    private static Camera HelmCamera;


    public static void Init(Transform player, Transform boat)
    {
        Player = player;
        PlayerCamera = player.Find("Camera").gameObject.GetComponent<Camera>();
        Boat = boat;
        HelmCamera = boat.Find("HelmCamera").gameObject.GetComponent<Camera>();
    }

    public static void SwitchCameras()
    {
        BoatState.inHelm = !BoatState.inHelm;

        PlayerCamera.enabled = !PlayerCamera.enabled;
        HelmCamera.enabled = !HelmCamera.enabled;
        LockPlayerOnBoat();
    }

    private static void LockPlayerOnBoat() => Player.transform.SetParent(BoatState.inHelm ? Boat : null);
}