using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra using statement to allow us to use the scene managament functions
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    // Variable to keep a reference to the lives display object.
    public Lives livesObject;


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

        // Jumping

        // Detect if we are touching the ground
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");

        // Ask layer collider if we are touching the LayerMask
        bool TouchingGround = playerCollider.IsTouchingLayers(groundLayerMask);
        



        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if(jumpButtonPressed == true && TouchingGround == true)
        {
            // We have pressed jump, so we should set our upward velocity to jumpSpeed
            velocity.y = jumpSpeed;

            // Give the velocity to rigidbody
            physicsBody.velocity = velocity;


        }



    }


    // Our own function for handling player death
    public void Kill()
    {
        // Take away a life and save that change.
        livesObject.LoseLife();
        livesObject.SaveLives();

        // Check if the game is over.
        bool gameOver = livesObject.isGameOver();

        
        if (gameOver == true)
        {
            //If the game is over...
            // Load the the Game over scene.
            SceneManager.LoadScene("GameOverScreen");

        }
        else
        {
            // If the game is not over...
            // Reset the current leel to restart

            // Reset the current level to reset from the beggining.

            // First, ask unity what the current level is
            Scene currentLevel = SceneManager.GetActiveScene();

            // Second, tell unity to load the current level again by passing the build index of our level
            SceneManager.LoadScene(currentLevel.buildIndex);

        }
        



    }

    
}
