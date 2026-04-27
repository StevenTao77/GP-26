using UnityEngine;

public class SpikeTrap : Hazard
{
    
    protected override void ApplyDamage(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();

        if (stats !=null)
        {
            stats.AddScore(-damageAmount);
            Debug.Log($"Player loses {damageAmount} score from SpikeTrap.");
        }
        
        
    }

    protected override void TriggerVisualFeedback()
        {
        base.TriggerVisualFeedback();
        Debug.Log($"SpikeTrap triggered! playing spike trap animation.");
    }

}
