using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public string playerTag = "Player";
    
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;               // ⛔ Already triggered once
        if (!other.CompareTag(playerTag)) return;

        hasPlayed = true;                    // 🔒 Lock so it never triggers again
        timeline.Play();                     // ▶️ Play Timeline
    }
}
