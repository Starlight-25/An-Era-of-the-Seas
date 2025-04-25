using UnityEngine;

public class Interactor : MonoBehaviour
{
    public bool Finished { get; private set; } = false;
    public string interactableTag = "Chest";
    
    public GameObject WinDisplay;
    
    public void Interact(GameObject interactingPlayer)
    {
        if (Finished) return;

        Finished = true;

        if (WinDisplay != null)
        {
            WinDisplay.SetActive(true);
        }

        Debug.Log("Interactor used by: " + interactingPlayer.name);

        DeclareWinner(interactingPlayer);

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                Interactor interactor = hit.collider.GetComponent<Interactor>();
                if (interactor != null)
                {
                    interactor.Interact(gameObject);
                }
            }
        }
    }
    
    void DeclareWinner(GameObject winningPlayer)
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in allPlayers)
        {
            MultiplayerUIManager ui = player.GetComponent<MultiplayerUIManager>();

            if (ui != null)
            {
                if (player == winningPlayer)
                    ui.ShowWinnerUI();
                else
                    ui.ShowOtherUI();
            }
        }
    }


}
