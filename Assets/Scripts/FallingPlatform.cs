using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool PlayerInside;
    
    private HashSet<Player> _playersInTrigger = new HashSet<Player>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null)
            return;

        _playersInTrigger.Add(player); //to add player to the collection

        PlayerInside = true;

        StartCoroutine(WiggleAndFall());
    }

    private IEnumerator WiggleAndFall()
    {
        Debug.Log("Waiting to wiggle");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Wiggling");
        yield return new WaitForSeconds(1f);
        Debug.Log("Falling");
        yield return new WaitForSeconds(3f);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null)
            return;

        _playersInTrigger.Remove(player); // to remove from the collection.

        if(_playersInTrigger.Count == 0)
            PlayerInside = false;
    }
}
