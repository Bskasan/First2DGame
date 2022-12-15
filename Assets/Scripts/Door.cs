using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private Sprite _openMid;
    [SerializeField] private Sprite _openTop;

    [SerializeField] private SpriteRenderer _rendererTop;
    [SerializeField] private SpriteRenderer _rendererMid;

    [ContextMenu("Open Door")] // Great for testing your code/methods.

    private void Open() 
    {
        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
