 using UnityEngine;

public class SpeedBoost : Collectible
{
    public float boostMultiplier = 2.0f;
    public float boostDuration = 5.0f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.ApplySpeedBoost(boostMultiplier, boostDuration);
        }
        Debug.Log($"Collected a Speed Boost! Player speed multiplied by {boostMultiplier}.");
        // increase player speed goes here!!! yes
    }

     
    protected override void PlayEffect()
    {
        base.PlayEffect();  
        Debug.Log($"[{itemName}] Ywaaaaaa!");
    }
}