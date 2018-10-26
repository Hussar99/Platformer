using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get axis input from Unity
        float leftRight = Input.GetAxis(horizontalAxis);

        // Create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        // Make direction vector length 1
        direction = direction.normalized;

        // Calculate the velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // Give the velocity to the rigid body
        physicsBody.velocity = velocity;


        // Tell the animator our speed
        playerAnimator.SetFloat("walkspeed", Mathf.Abs(velocity.x));

        // Flip our sprite if we're moving backwards.
        if(velocity.x < 0)
        {
            playerSprite.flipX = true;

        }

        else
        {
            playerSprite.flipX = false;
        }

    }

    
}
