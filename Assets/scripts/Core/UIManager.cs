using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI speedText;

    [Header("player Reference")]
    public PlayerStats playerStats;
    public PlayerMovement playerMovement;

    private void OnEnable()
    {
        if(playerStats != null)
        {
            playerStats.OnScoreChanged += UpdateScoreDisplay;
        }
        else
        {
            Debug.LogError("PlayerStats reference is missing in UIManager!");
        }
        if (playerMovement != null)
        {
            playerMovement.OnSpeedChanged += UpdateSpeedDisplay;
        }
        else
        {
            Debug.LogError("PlayerMovement reference is missing in UIManager!");
        }
    }

    private void OnDisable()
    {
        if (playerStats != null)
        {
            playerStats.OnScoreChanged -= UpdateScoreDisplay;
        }
        if (playerMovement != null)
        {
            playerMovement.OnSpeedChanged -= UpdateSpeedDisplay;
        }
    }

    private void UpdateScoreDisplay(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore;
        }
    }

    private void UpdateSpeedDisplay(float newSpeed)
    {
        if (speedText != null)
        {
            speedText.text = "Speed: " + newSpeed.ToString("F1");
        }
    }
}   