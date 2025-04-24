using UnityEngine;

public class Interactor : MonoBehaviour
{
    public bool Finished { get; private set; } = false;
    public string interactableTag = "Chest";

    
    public void Interact()
    {
        if (!Finished)
        {
            Finished = true;
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("Should not happen");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag(interactableTag))
            {
                Interactor interactor = other.GetComponent<Interactor>();
                if (interactor != null)
                {
                    interactor.Interact();
                }
            }
        }
    }

}
