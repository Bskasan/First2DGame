using System;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    [SerializeField] private float _bounceVelocity = 10;
    [SerializeField] private Sprite _downSprite;

    private SpriteRenderer _spriteRenderer;
    private Sprite _upSprite;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _upSprite = _spriteRenderer.sprite; // to assign our default sprite for springboard.
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();
        if (player != null)
        {
            var rigidbody2D = player.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null) // Because there might not be rigidbody component on the player.
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _bounceVelocity);
                _spriteRenderer.sprite = _downSprite;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();
        if (player != null)
        {
            _spriteRenderer.sprite = _upSprite;
        }
    }
}
