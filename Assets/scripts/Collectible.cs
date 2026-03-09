using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.AddScore(pointValue);
                Destroy(gameObject);
            }
        }
    }
}