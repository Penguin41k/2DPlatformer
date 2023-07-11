using UnityEngine;

public class PleyerController : MonoBehaviour
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

    private int amountCollectible;

    public void AddCollectibleEvent()
    {
        amountCollectible++;
    }

    public void TeleportToStart()
    {
        transform.position = _startPoint.position;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _isGrounded = false;
        _isJumpKeyPress = false;
        amountCollectible = 0;
    }

    private void Update()
    {
        _xAxisMoveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpKeyPress = true;
        }

    }

    private void FixedUpdate()
    {
        _isGrounded = _groundSensor.IsGrounded;

        if (_xAxisMoveDirection > 0)
        {
            _sprite.flipX = false;
        }
        else if (_xAxisMoveDirection < 0)
        {
            _sprite.flipX = true;
        }

        Vector2 velocity = new Vector2(_xAxisMoveDirection * _speed, _rigidbody2D.velocity.y);

        if (_isJumpKeyPress && _isGrounded)
        {
            velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _isJumpKeyPress = false;
        }

        _rigidbody2D.velocity = velocity;

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

    private enum AnimationState
    {
        Player_Idel,
        Player_Run,
        Player_Jump,
        Player_Fall
    }

}
