using UnityEngine;

public class Player : MonoBehaviour
{
    //SerializedField attribute to see our variable on Inspector,Unity.
    [SerializeField] private int _playerNumber = 1;
    [Header("Movement")]
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _slipFactor = 1;
    [Header("Jump")]
    [SerializeField] private float _jumpVelocity = 200;
    [SerializeField] private int _maxJumps;
    [SerializeField] Transform _feet;
    [SerializeField] float _downPull = 5;
    [SerializeField] float _maxJumpDuration = 0.1f;
    

    private Vector3 _startingPosition;
    private int _jumpsRemaining;
    private float _fallTimer;
    private float _jumpTimer;
    private float _horizontal;
    private bool _isGrounded;
    private bool _isOnSlipperySurface;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public int PlayerNumber { get { return _playerNumber; } }
    // Another way of doing it above -> public int PlayerNumber => _playerNumber;


    void Start()
    {
        // Assigning to rigidbody component of our player, to reference, access and modify.
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startingPosition = transform.position;
        _jumpsRemaining = _maxJumps;
        
    }

    void Update()
    {
        UpdateIsGrounded();
        ReadHorizontalInput();

        if (_isOnSlipperySurface)
            SlipHorizontal();
        else
            MoveHorizontal();

        UpdateAnimator();
        UpdateSpriteDirection();

        //Jumping 
        if (ShouldStartJump())
            Jump();
        else if(ShouldContinueJump())
            ContinueJump();

        _jumpTimer += Time.deltaTime;
        
        if (_isGrounded && _fallTimer > 0)
        {
            _fallTimer = 0;
            _jumpsRemaining = _maxJumps;
        }
        else 
        {
            _fallTimer += Time.deltaTime;
            var downForce = _downPull * _fallTimer * _fallTimer;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y - downForce);
        }

    }

    private void ContinueJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _fallTimer = 0;
    }
    private bool ShouldContinueJump()
    {
        return Input.GetButton($"P{_playerNumber}Jump") && _jumpTimer <= _maxJumpDuration;
    }
    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _jumpsRemaining--;
        Debug.Log($"Jumps remaining: {_jumpsRemaining}");
        _fallTimer = 0;
        _jumpTimer = 0;
    }
    private bool ShouldStartJump()
    {
        return Input.GetButtonDown($"P{_playerNumber}Jump") && _jumpsRemaining > 0;
    }
    private void MoveHorizontal()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
        // Velocity : the speed at which someting happens or moves. Hiz. 
    }
    private void SlipHorizontal()
    {
        var desiredVelocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
        var smoothedVelocity = Vector2.Lerp(
            _rigidbody2D.velocity, 
            desiredVelocity, 
            Time.deltaTime / _slipFactor);

        _rigidbody2D.velocity = smoothedVelocity;
        // Velocity : the speed at which someting happens or moves. Hiz. 
    }
    private void ReadHorizontalInput()
    {
        // A float value from -1 to 1 to control our player.
        _horizontal = Input.GetAxis($"P{_playerNumber}Horizontal") * _speed;
    }
    private void UpdateSpriteDirection()
    {
        //Changing Conditional Statement for Sprite Direction
        if (_horizontal != 0)
        { 
            _spriteRenderer.flipX = _horizontal < 0;
        }
    }
    private void UpdateAnimator()
    {
        //Walking Animation
        bool isWalkingActivated = _horizontal != 0;
        _animator.SetBool("isWalking", isWalkingActivated);
        _animator.SetBool("isJumping", ShouldContinueJump());
    }
    private void UpdateIsGrounded()
    {
        var hit = Physics2D.OverlapCircle(_feet.position, 0.1f, LayerMask.GetMask("Default"));
        _isGrounded = hit != null;

        if (hit != null)
            _isOnSlipperySurface = hit.CompareTag("Slippery");
            //hit.tag == "Slippery" is also work for it.
        else
            _isOnSlipperySurface = false;

        //_isOnSlipperySurface = hit?.CompareTag("Slippery") ?? false;
        // Short version of the code above
    }
    internal void ResetToStart()
    {
        // Internal means that we can call this method out of our script.
        transform.position = _startingPosition;
    }
}
