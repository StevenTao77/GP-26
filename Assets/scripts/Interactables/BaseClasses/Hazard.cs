using UnityEngine;

public abstract class Hazard: MonoBehaviour, IInteractable
{

    public int damageAmount = 1;

    public void Interact(GameObject player)
    {
        ApplyDamage(player);
    }

    protected abstract void ApplyDamage(GameObject player);

    protected virtual void TriggerVisualFeedback()
    {
         Debug.Log($"Hazard triggered! playing default hazard animation.");
    }
}
