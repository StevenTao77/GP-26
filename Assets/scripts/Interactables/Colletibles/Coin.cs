using UnityEngine;

public class Coin : Collectible
{
    public int coinValue = 10;

    // Must implement abstract method
    protected override void ApplyEffect(GameObject player)
    {

        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.AddScore(coinValue);
            Debug.Log($"Collected a Coin! Added {coinValue} to score.");
        }
       
        
    }

     
}