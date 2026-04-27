using UnityEngine;

public class StorableItem : Collectible
{
    protected override void ApplyEffect(GameObject player)
    {
         
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            
            inventory.AddItem(itemName);
        }
        else
        {
            Debug.LogWarning("Player does not have an inventory!");
        }
    }

    protected override void PlayEffect()
    {
         
        Debug.Log($"[{itemName}] Picked up and stored. Play sound: *Rustle*");
    }
}