using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private Transform _leftSensor;
    [SerializeField] private Transform _rightSensor;

    private Rigidbody2D _rigidbody2D;
    private float _direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var desiredVelocity = new Vector2(_direction, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = desiredVelocity;
        
       
        if (_direction < 0)
        {
            ScanSensor(_leftSensor);
        }
        else
        {
            ScanSensor(_rightSensor);
        }

    }

    private void ScanSensor(Transform sensor)
    {
        Debug.DrawRay(sensor.position, Vector2.down * 0.1f, Color.red);
        

        var result = Physics2D.Raycast(sensor.position, Vector2.down, 0.1f);
        if (result.collider == null)
            TurnAround();

        Debug.DrawRay(sensor.position, new Vector2(_direction, 0) * 0.1f, Color.red);
        var sideResult = Physics2D.Raycast(sensor.position, new Vector2(_direction, 0), 0.1f);
        if (sideResult.collider != null)
            TurnAround();
    }

    private void TurnAround()   
    {
        _direction *= -1;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = _direction > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        var contact = collision.contacts[0];
        Vector2 normal = contact.normal; // To get contact point 2d
        Debug.Log($"Normal = {normal}");

        if (normal.y <= -0.5f)
        {
            Die();
        }
        else 
        {
            player.ResetToStart();
        }

            
    }

    private void Die()
    {
        GameObject.Destroy(gameObject);
    }
}
