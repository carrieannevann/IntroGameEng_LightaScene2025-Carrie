using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    [Header("References")]
    public PlayableDirector director;   // assign Event01_Timeline's director here
    public string playerTag = "Player"; // tag on your player

    [Header("Options")]
    public bool playOnce = true;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        if (playOnce && hasPlayed)
            return;

        if (director != null)
        {
            director.Play();
            hasPlayed = true;
        }
        else
        {
            Debug.LogWarning("[TimelineTrigger] No PlayableDirector assigned on " + name);
        }
    }
}
