using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [SerializeField] private UnityEvent _onUnlocked;

    public void Unlock() 
    {
        Debug.Log("Unlocked");

        _onUnlocked.Invoke();
    }

    
    
}
