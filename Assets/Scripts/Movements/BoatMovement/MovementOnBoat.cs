using UnityEngine;

public class MovementOnBoat : MonoBehaviour
{
    public Transform Boat;
    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (HelmInteractor.inHelm && other.CompareTag(playerTag))
        {
            other.gameObject.transform.parent = Boat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (HelmInteractor.inHelm && other.CompareTag(playerTag))
        {
            other.gameObject.transform.parent = null;
        }
    }
}
