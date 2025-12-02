using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeline : MonoBehaviour
{
    [Header("Timeline to Play")]
    public PlayableDirector timeline;   // Drag your ZombieMover here in Inspector

    [Header("Trigger Settings")]
    public string playerTag = "Player"; // Make sure your player is tagged "Player"

    private bool hasPlayed = false;     // Optional: only play once

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (other.CompareTag(playerTag))
        {
            if (timeline != null)
            {
                timeline.Play();
                hasPlayed = true;
            }
            else
            {
                Debug.LogWarning("TriggerTimeline: No timeline assigned on " + name);
            }
        }
    }
}
