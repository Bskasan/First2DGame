using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null) 
        {
            transform.SetParent(player.transform);
            transform.localPosition = Vector2.up;
        }
            


    }

}
