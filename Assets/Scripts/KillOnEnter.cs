using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.ResetToStart();
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.ResetToStart();
        }
    }
}
