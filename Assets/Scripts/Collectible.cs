using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Collector _collector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        gameObject.SetActive(false);
        _collector.ItemPickedUp();
        
    }

    public void SetCollector(Collector collector)
    {
        _collector = collector;
    }
}