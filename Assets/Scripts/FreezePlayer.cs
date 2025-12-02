using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public float freezeDuration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Freeze all movement scripts on the player
            MonoBehaviour[] scripts = other.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false; // Disable everything on Player
            }

            StartCoroutine(UnfreezeAfterDelay(other));
        }
    }

    private System.Collections.IEnumerator UnfreezeAfterDelay(Collider player)
    {
        yield return new WaitForSeconds(freezeDuration);

        // Re-enable all movement scripts on the player
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
    }
}
