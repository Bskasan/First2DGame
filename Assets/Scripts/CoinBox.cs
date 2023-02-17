using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private int _totalCoins = 3;
    [SerializeField] private Sprite _usedSprite;

    private int _remainingCoins;

    private void Start()
    {
        _remainingCoins = _totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        if (collision.contacts[0].normal.y > 0 && _remainingCoins > 0)
        {
            _remainingCoins--;
            Coin.CoinsCollected++;
            if (_remainingCoins <= 0) 
            {
                GetComponent<SpriteRenderer>().sprite = _usedSprite;
            }
                
        }
            
    }
}
