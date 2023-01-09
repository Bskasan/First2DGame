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
        //for every item in this collection, look at them. check them they're true.
        if (_collectibles.Any(t => t.gameObject.activeSelf == true))
            return;
                            
        Debug.Log("Got All Gems");
    }
}
