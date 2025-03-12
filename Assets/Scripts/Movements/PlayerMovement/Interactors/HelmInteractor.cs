using System;
using UnityEngine;

public static class HelmInteractor
{
    private static Transform Player;
    private static Camera PlayerCamera;
    private static Transform Boat;
    private static Camera HelmCamera;
    private static BoatState BoatState;


    public static void Init(Transform player, Transform boat)
    {
        Player = player;
        PlayerCamera = player.Find("Camera").gameObject.GetComponent<Camera>();
        Boat = boat;
        HelmCamera = boat.Find("HelmCamera").gameObject.GetComponent<Camera>();
        BoatState = Player.GetComponent<BoatInitHandler>().BoatState;
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