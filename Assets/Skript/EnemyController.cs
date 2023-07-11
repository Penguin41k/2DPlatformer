using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _movePointA;
    [SerializeField] private Transform _movePointB;
    [SerializeField] private int _speed;

    private Transform _targetPoint;
    private float _minDistanceToMovePoint;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _minDistanceToMovePoint = 0.5f;


        if (_movePointA.position.x<_movePointB.position.x) 
        {
            Transform tempPoint = _movePointB;
            _movePointB = _movePointA;
            _movePointA = tempPoint;
        }

        _targetPoint = _movePointA;
    }

    private void FixedUpdate()
    {
        if (_targetPoint==_movePointA)
        {
            _rigidbody2D.velocity= new Vector2(_speed,0);
            _sprite.flipX= false;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(-_speed,0);
            _sprite.flipX = true;
        }

        if (Vector2.Distance(transform.position, _targetPoint.position) < _minDistanceToMovePoint && _targetPoint==_movePointA )
        {
            _targetPoint= _movePointB;
        }

        if (Vector2.Distance(transform.position, _targetPoint.position) < _minDistanceToMovePoint && _targetPoint == _movePointB)
        {
            _targetPoint = _movePointA;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_movePointA.position, 0.5f);
        Gizmos.DrawWireSphere(_movePointB.position, 0.5f);
    }
}