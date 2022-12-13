using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private static int _coinsCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null)
            return;
        //Do not continue to run the code below.

        gameObject.SetActive(false);
        _coinsCollected++;
        Debug.Log($"Coins collected: {_coinsCollected}");

    }
}
