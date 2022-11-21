using UnityEngine;

public class Player : MonoBehaviour
{
    //SerializedField attribute to see our variable on Inspector,Unity.
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce = 200;
    private Vector3 _startingPosition;

    void Start()
    {
        _startingPosition = transform.position;
        
    }

    void Update()
    {
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
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.AddForce(Vector2.up * _jumpForce);

        }

    }

    internal void ResetToStart()
    {
        // Internal means that we can call this method out of our script.
        transform.position = _startingPosition;
    }
}
