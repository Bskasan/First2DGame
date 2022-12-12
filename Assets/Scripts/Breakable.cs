using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Player>() == null)
            return;

        if (collision.contacts[0].normal.y > 0)
            TakeHit();
    }

    void TakeHit()
    {
        ParticleSystem particleSytem = GetComponent<ParticleSystem>();
        particleSytem.Play();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
