using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyLock _keyLock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null) 
        {
            transform.SetParent(player.transform);
            transform.localPosition = Vector2.up;
        }

        var keyLock = collision.GetComponent<KeyLock>();

        if (keyLock != null && keyLock == _keyLock) // keyLock != null
        {
            keyLock.Unlock();
            Destroy(gameObject);
        } 
            

    }

}
