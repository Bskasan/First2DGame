using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : HittableFromBelow
{
    [SerializeField] private int _totalCoins = 3;
    

    private int _remainingCoins;

    protected override bool CanUse => _remainingCoins > 0;

    private void Start()
    {
        _remainingCoins = _totalCoins;
    }

    protected override void Use()
    {
        base.Use();

        _remainingCoins--;
        Coin.CoinsCollected++;
        
    }

   
}
