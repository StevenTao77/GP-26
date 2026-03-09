using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int score = 0;



    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score updated! Current score is: " + score);
    }
}