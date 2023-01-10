using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Collector : MonoBehaviour
{

    //Array of Collectibles
    [SerializeField] private List<Collectible> _collectibles;
    private TMP_Text _remainingText;

    void Start()
    {
        _remainingText = GetComponentInChildren<TMP_Text>();
    }

    
    void Update()
    {
        int countRemaining = 0;
        // it is better to use this foreach for performance.
        foreach (var collectible in _collectibles) 
        {
            if (collectible.isActiveAndEnabled)
                countRemaining++;
        }
        //for every item in this collection, look at them. check them they're true.
        //if (_collectibles.Any(t => t.gameObject.activeSelf == true))
        //    return;

        //Recommended way
        _remainingText?.SetText(countRemaining.ToString());
        // Other way;
        //_remainingText.text = countRemaining.ToString();

        if (countRemaining > 0)
            return;
                            
        Debug.Log("Got All Gems");
    }

    private void OnValidate()
    {
        //Linq -- Distinct() will find only unique references.
        _collectibles = _collectibles.Distinct().ToList();
    }
}
