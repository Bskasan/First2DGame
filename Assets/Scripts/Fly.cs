using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Vector2 _startingPosition;
    [SerializeField] private Vector2 _direction = Vector2.up;
    [SerializeField] private float _maxDistance = 2;
    [SerializeField] private float _speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        Debug.Log(new Vector3(0,2,0).normalized);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction.normalized * Time.deltaTime * _speed);
        var distance = Vector2.Distance(_startingPosition, transform.position);
        if (distance >= _maxDistance)
        {
            transform.position = _startingPosition + (_direction.normalized * _maxDistance);
            _direction *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Collider>();
    }
}
