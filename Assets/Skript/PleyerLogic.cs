using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PleyerLogic : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private Transform _startPoint;

    private Animator _animator;
    private string _currentAnimationState;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprite;
    private bool _isGrounded;
    private float _xAxisMoveDirection;
    private bool _isJumpKeyPress;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _isJumpKeyPress = false;
        TeleportToStart(_startPoint);
    }

    private void Update()
    {
        _xAxisMoveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJumpKeyPress = true;
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = _groundSensor.IsGrounded;

        _sprite.flipX = (_xAxisMoveDirection == 0) ? _sprite.flipX : (_xAxisMoveDirection < 0);

        Vector2 velocity = new Vector2(_xAxisMoveDirection * _speed, _rigidbody2D.velocity.y);

        if (_isJumpKeyPress && _isGrounded)
        {
            velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _isJumpKeyPress = false;
        }

        _rigidbody2D.velocity = velocity;

        AnimatePlayer();
    }

    private enum AnimationState
    {
        Player_Idel,
        Player_Run,
        Player_Jump,
        Player_Fall
    }

    public void TeleportToStart(Transform teleportPoint)
    {
        transform.position = teleportPoint.position;
    }

    private void AnimatePlayer()
    {
        if (_isGrounded == true)
        {
            if (_xAxisMoveDirection != 0)
            {
                ChangeAnimationState(AnimationState.Player_Run);
            }
            else
            {
                ChangeAnimationState(AnimationState.Player_Idel);
            }
        }
        else
        {
            if (_rigidbody2D.velocity.y >= 0)
            {
                ChangeAnimationState(AnimationState.Player_Jump);
            }
            else
            {
                ChangeAnimationState(AnimationState.Player_Fall);
            }
        }
    }

    private void ChangeAnimationState(AnimationState newAnimationState)
    {
        string state = newAnimationState.ToString();

        if (state == _currentAnimationState)
            return;

        _animator.Play(state);
        _currentAnimationState = state;
    }
}
