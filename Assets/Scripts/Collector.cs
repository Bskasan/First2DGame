using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Events;
using System;

public class Collector : MonoBehaviour
{

    //List of Collectibles
    [SerializeField] private List<Collectible> _collectibles;
    [SerializeField] private UnityEvent _onCollectionComplete;


    private TMP_Text _remainingText;
    private int _countCollected;

    void Start()
    {
        _remainingText = GetComponentInChildren<TMP_Text>();
        foreach (var collectible in _collectibles) 
        {
            collectible.SetCollector(this);
        }

        int countRemaining = _collectibles.Count - _countCollected;
        _remainingText?.SetText(countRemaining.ToString());
    }

    
    public void ItemPickedUp()
    {
        _countCollected++;
        int countRemaining = _collectibles.Count - _countCollected;

        //Recommended way
        _remainingText?.SetText(countRemaining.ToString());
        // Other way;
        //_remainingText.text = countRemaining.ToString();

        if (countRemaining > 0)
            return;
                            
        Debug.Log("Got All Gems");
        _onCollectionComplete.Invoke();
    }


    private void OnValidate()
    {
        //Linq -- Distinct() will find only unique references.
        _collectibles = _collectibles.Distinct().ToList();
    }

   
}
