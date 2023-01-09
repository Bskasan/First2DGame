using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Collector : MonoBehaviour
{

    //Array of Collectibles
    [SerializeField] private Collectible[] _collectibles;
    

    void Start()
    {
        
    }

    
    void Update()
    {

        // it is better to use this foreach for performance.
        foreach (var collectible in _collectibles) 
        {
            if (collectible.isActiveAndEnabled)
                return;
        }
        //for every item in this collection, look at them. check them they're true.
        //if (_collectibles.Any(t => t.gameObject.activeSelf == true))
        //    return;
                            
        Debug.Log("Got All Gems");
    }
}
