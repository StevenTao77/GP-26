using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        IInteractable interactableItem = other.GetComponent<IInteractable>();

        if (interactableItem != null)
        {
            interactableItem.Interact(this.gameObject);
        }
    }
}