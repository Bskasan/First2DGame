using UnityEngine;

public class Player : MonoBehaviour
{
    //SerializedField attribute to see our variable on Inspector,Unity.
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpVelocity = 200;
    [SerializeField] private int _maxJumps;
    [SerializeField] Transform _feet;
    [SerializeField] float _downPull = 5;
    [SerializeField] float _maxJumpDuration = 0.1f;

    private Vector3 _startingPosition;
    private int _jumpsRemaining;
    private float _fallTimer;
    private float _jumpTimer;
    

    void Start()
    {
        _startingPosition = transform.position;
        _jumpsRemaining = _maxJumps;
        
    }

    void Update()
    {
        var hit = Physics2D.OverlapCircle(_feet.position, 0.1f, LayerMask.GetMask("Default"));
        bool isGrounded = hit != null;

        // A float value from -1 to 1 to control our player.
        var horizontal = Input.GetAxis("Horizontal") * _speed;

        // Assigning to rigidbody component of our player, to reference, access and modify.
        var rigidbody2D = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(horizontal) >= 1) // Abs gives us absolute value.
        {
            rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
            // Velocity : the speed at which someting happens or moves. Hiz.
        }

        //Walking Animation
        var animator = GetComponent<Animator>();
        bool isWalkingActivated = horizontal != 0;
        animator.SetBool("isWalking", isWalkingActivated);

        //Changing Conditional Statement for Sprite Direction
        if (horizontal != 0) 
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }

        //Jumping 
        if (Input.GetButtonDown("Jump") && _jumpsRemaining > 0)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpVelocity);
            _jumpsRemaining--;
            _fallTimer = 0;
            _jumpTimer = 0;

        } else if(Input.GetButton("Jump") && _jumpTimer <= _maxJumpDuration)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpVelocity);
            _fallTimer = 0;
            _jumpTimer += Time.deltaTime;
        }

        if (isGrounded)
        {
            _fallTimer = 0;
            _jumpsRemaining = _maxJumps;
        }
        else 
        {
            _fallTimer += Time.deltaTime;
            var downForce = _downPull * _fallTimer * _fallTimer;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y - downForce);
        }

    }

    internal void ResetToStart()
    {
        // Internal means that we can call this method out of our script.
        transform.position = _startingPosition;
    }
}
