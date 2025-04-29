using Unity.Netcode;
using UnityEngine;

public class MultiplayerInteractor : NetworkBehaviour
{ 
    public void Interact()
    {
        if (IsOwner) InteractServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    
    
    
    
    
    [ServerRpc(RequireOwnership = false)]
    void InteractServerRpc(ulong senderClientId)
    {
        ShowMessageClientRpc(senderClientId);
    }
    
    
    
    
    
    [ClientRpc]
    void ShowMessageClientRpc(ulong actorClientId)
    {
        ulong localClientId = NetworkManager.Singleton.LocalClientId;

        string message = localClientId == actorClientId ? "You won" : "You lose";

        FindObjectOfType<UIManager>().DisplayResult(message);
    }
}
