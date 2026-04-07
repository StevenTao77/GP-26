using UnityEngine;

public class Coin : Collectible
{
    public int coinValue = 10;

    // Must implement abstract method
    protected override void ApplyEffect(GameObject player)
    {
        Debug.Log($"Collected a Coin! Added {coinValue} to score.");
        //   add score to player goes here
    }

     
}