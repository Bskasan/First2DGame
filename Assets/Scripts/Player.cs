using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // A float value from -1 to 1 to control our player.
        var horizontal = Input.GetAxis("Horizontal");
        // Assigning to rigidbody component of our player, to reference, access and modify.
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y); 
        // Velocity : the speed at which someting happens or moves. Hiz.


    }
}
