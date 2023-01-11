using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private Sprite _openMid;
    [SerializeField] private Sprite _openTop;

    [SerializeField] private SpriteRenderer _rendererTop;
    [SerializeField] private SpriteRenderer _rendererMid;
    [SerializeField] private int _requiredCoins = 3;
    [SerializeField] private Door _exit;
    [SerializeField] private Canvas _canvas;


    private bool _open;

    [ContextMenu("Open Door")] // Great for testing your code/methods.

    public void Open() 
    {
        if (_canvas != null)
            _canvas.enabled = false;

        _open = true;
        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
    }

    void Update()
    {
       
        if (_open == false && Coin.CoinsCollected >= _requiredCoins)
            Open();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_open == false)
            return;

        var player = collision.GetComponent<Player>();
        if (player != null && _exit != null) 
        {
            player.TeleportTo(_exit.transform.position);
        }
    }
}
