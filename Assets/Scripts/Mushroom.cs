using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private float _bounceVelocity = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();
        if (player != null)
        {
            var rigidbody2D = player.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null) // Because there might not be rigidbody component on the player.
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _bounceVelocity);
            }
        }
    }
}
