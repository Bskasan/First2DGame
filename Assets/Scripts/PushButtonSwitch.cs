using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] private Sprite _pressedSprite;
    [SerializeField] private UnityEvent _onPressed;
    [SerializeField] private UnityEvent _onReleased;
    [SerializeField] private int _playerNumber = 1;

    private Sprite _releasedSprite;
    private SpriteRenderer _spriteRenderer;
    

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _releasedSprite = _spriteRenderer.sprite;

        BecomeReleased();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null || player.PlayerNumber != _playerNumber)
            return;

        BecomePressed();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null || player.PlayerNumber != _playerNumber)
            return;

        BecomeReleased();
    }

    private void BecomeReleased()
    {
        _spriteRenderer.sprite = _releasedSprite;
        _onReleased?.Invoke();
    }
    private void BecomePressed()
    {
        _spriteRenderer.sprite = _pressedSprite;
        _onPressed?.Invoke(); // to execute registered event
    }
}
