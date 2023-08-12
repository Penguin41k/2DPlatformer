using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private GameObject _movePointA;
    [SerializeField] private GameObject _movePointB;
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent _hero;

    private GameObject _targetPoint;
    private float _minDistanceToMovePoint;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _minDistanceToMovePoint = 0.5f;

        if (_movePointA.transform.position.x<_movePointB.transform.position.x) 
        {
            GameObject tempPoint = _movePointB;
            _movePointB = _movePointA;
            _movePointA = tempPoint;
        }

        _targetPoint = _movePointA;
    }

    private void FixedUpdate()
    {
        _spriteRenderer.flipX = _targetPoint != _movePointA;
        
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint.transform.position, _speed*Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, _targetPoint.transform.position) < _minDistanceToMovePoint && _targetPoint==_movePointA )
        {
            _targetPoint= _movePointB;
        }

        if (Vector2.Distance(transform.position, _targetPoint.transform.position) < _minDistanceToMovePoint && _targetPoint == _movePointB)
        {
            _targetPoint = _movePointA;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PleyerLogic pleyer))
        {
            _hero?.Invoke();
        }
    }
}