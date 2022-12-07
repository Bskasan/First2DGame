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
        gameObject.SetActive(false);
    }
}
