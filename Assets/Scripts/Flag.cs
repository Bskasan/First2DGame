using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            return;

        // play flag wave
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Raise");
        // load new level
    }
}
