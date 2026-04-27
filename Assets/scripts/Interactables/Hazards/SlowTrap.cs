using UnityEngine;

public class SlowTrap : Hazard
{
    [Header("Slow Trap Settings")]
    public float slowDuration = 3f; // Duration of the slow effect
    public float slowMultiplier = 0.5f; // Multiplier for the slow effect (e.g., 0.5 means 50% speed)

    protected override void ApplyDamage(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if(movement != null)
        {
            movement.ApplySpeedBoost(slowMultiplier, slowDuration);
            Debug.Log($"Applied slow effect: {slowMultiplier * 100}% speed for {slowDuration} seconds.");
        }
        Destroy(gameObject); // Destroy the trap after applying the effect

    }


    
}