using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Variables are private as default.
    public static int CoinsCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null)
            return;
        //Do not continue to run the code below.

        gameObject.SetActive(false);
        CoinsCollected++;
        Debug.Log($"Coins collected: {CoinsCollected}");

    }
}
