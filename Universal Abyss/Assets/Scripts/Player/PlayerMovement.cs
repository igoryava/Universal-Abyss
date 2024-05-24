using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private int _extraJumpsValue;
    [SerializeField] private Transform _groundChecker;

    [SerializeField] private KeyCode _jumpKey = (KeyCode.Space);

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AudioSource _playerWalk;
    [SerializeField] private AudioSource _playerJump;

    private int _extraJumps;
    private IsAttachedPlatform _isAttached;
    private float _horizontal;
    private bool _isFacingRight = true;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _extraJumps = _extraJumpsValue;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Walk();
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (!_isFacingRight && _horizontal > 0)
        {
            Flip();

        }
        else if (_isFacingRight && _horizontal < 0)
        {
            Flip();
        }
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, _checkRadius, _whatIsGround);

        if (_isGrounded == true)
        {
            _extraJumps = _extraJumpsValue;
        }

        if (_extraJumps > 0 && Input.GetKeyDown(_jumpKey))
        {
            Jump();
        }

        if(_isGrounded == true)
        {
            _animator.SetBool("Jumping", false);
        }
        else
        {
            _animator.SetBool("Jumping", true);
        }

        _animator.SetFloat("HorizontalMove", Mathf.Abs(_horizontal));
        
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        if (_isFacingRight)
        {
            _spriteRenderer.flipX = false;
        }
        else if(! _isFacingRight)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
        _extraJumps--;
        _playerJump.Play();
    }

    private void Walk()
    {
        _rigidbody.velocity = new Vector2(_horizontal * _movementSpeed, _rigidbody.velocity.y);
        _playerWalk.Play();
    }
}
