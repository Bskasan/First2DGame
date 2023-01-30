using System;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Shorten up our event script by using event keyword.
    public event Action OnPickedUp;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        gameObject.SetActive(false);

        if (OnPickedUp != null)
            OnPickedUp.Invoke();
        //Other method-Same thing
        //OnPickedUp?.Invoke();
        
    }

   
}