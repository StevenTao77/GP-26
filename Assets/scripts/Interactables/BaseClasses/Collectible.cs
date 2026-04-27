using UnityEngine;

public abstract class Collectible : MonoBehaviour, IInteractable
{
    public string itemName;
     
    public void Interact(GameObject player)
    {
        ApplyEffect(player);
        PlayEffect();
        Destroy(gameObject); // Destroy the object after collection
    }

    
    protected abstract void ApplyEffect(GameObject player);

    
    protected virtual void PlayEffect()
    {
        Debug.Log($"[{itemName}] Default sparkle effect played.");
    }
}