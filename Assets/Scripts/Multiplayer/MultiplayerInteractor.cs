using Unity.Netcode;
using UnityEngine;

public class MultiplayerInteractor : NetworkBehaviour
{ 
    public void Interact()
    {
        InteractServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    
    
    
    
    
    [ServerRpc(RequireOwnership = false)]
    void InteractServerRpc(ulong senderClientId)
    {
        ShowMessageClientRpc(senderClientId);
    }
    
    
    
    
    
    [ClientRpc]
    void ShowMessageClientRpc(ulong actorClientId)
    {
        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            string message = client.ClientId == actorClientId ? "You won" : "You lose";
            NetworkObject playerObject = client.PlayerObject;
            playerObject.transform.Find("Player UI").GetComponent<UIManager>().DisplayResult(message);
        }
    }
}
