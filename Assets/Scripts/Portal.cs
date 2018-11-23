using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra using statement to allow us to use the scene managament functions
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    // Variable to let us save the score.
    public Score scoreObject;

    // Designer variables
    public string sceneToLoad;

    // Unity calls this function automatically
    // When our enemy touch any other object
    private void OnCollisionEnter2D(Collision2D collsion)
    {

        //Check if the thing that we collided with is the player (aka has a Player script)
        Player playerScript = collsion.collider.GetComponent<Player>();
        // Only do something if the thing we run into was in fact the player (aka playerScript is not null)

        if (playerScript != null)
        {
            // We DID hit the player!

            // Save the score using our score object references.
            scoreObject.saveScore();

            // Load the next level
            SceneManager.LoadScene(sceneToLoad);
           
        }

    }

}
