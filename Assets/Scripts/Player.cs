using UnityEngine;

public class Player : MonoBehaviour
{
    //SerializedField attribute to see our variable on Inspector,Unity.
    [SerializeField] float _speed = 1;

    // Update is called once per frame
    void Update()
    {
        // A float value from -1 to 1 to control our player.
        var horizontal = Input.GetAxis("Horizontal") * _speed;

        // Assigning to rigidbody component of our player, to reference, access and modify.
        var rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y); 
        // Velocity : the speed at which someting happens or moves. Hiz.

    }
}
