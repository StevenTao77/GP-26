using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    private int score = 0;

    public event Action<int> OnScoreChanged;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score updated! Current score is: " + score);
        OnScoreChanged?.Invoke(score);
    }
}