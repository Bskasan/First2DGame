using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool PlayerInside;
    
    private HashSet<Player> _playersInTrigger = new HashSet<Player>();
    private Coroutine _coroutine;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null)
            return;

        _playersInTrigger.Add(player); //to add player to the collection

        PlayerInside = true;

        if(_playersInTrigger.Count == 1)
            _coroutine = StartCoroutine(WiggleAndFall());

    }

    private IEnumerator WiggleAndFall()
    {
        Debug.Log("Waiting to wiggle");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Wiggling");

        float wiggleTimer = 0;

        while (wiggleTimer < 1f) 
        {
            float randomX = UnityEngine.Random.Range(-0.01f, 0.01f);
            float randomY = UnityEngine.Random.Range(-0.01f, 0.01f);
            transform.position = _initialPosition + new Vector3(randomX, randomY);
            // We should use the Vector3 to not get error.
            float randomDelay = UnityEngine.Random.Range(0.005f, 0.01f);
            //yield return null; -->  That means it will wait for us to leave the platform.
            yield return new WaitForSeconds(randomDelay);
            wiggleTimer += randomDelay;
        }

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

        if (_playersInTrigger.Count == 0) 
        {
            PlayerInside = false;
            StopCoroutine(_coroutine);
        }
           
    }
}
