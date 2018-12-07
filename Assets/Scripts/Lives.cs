using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code.

using UnityEngine.UI;

public class Lives : MonoBehaviour {


    // variable to track the visable text score.
    // Public to let us drag and drop in the editor.
    public Text livesText;

    // Variabler to track the numberical lives.
    // Private because other scripts should not change the script directly.
    //change it directly
    // Default to 3 since we should have no score when we are starting.
    private int numericalLives = 3;



    // Use this for initialization
    void Start () {
        // Get the lives from the prefs database.
        // Use a default of 3 lives.
        // Store the result in our numerical lives variable.
        numericalLives = PlayerPrefs.GetInt("lives", 3);

        // Update the visual lives.
        livesText.text = numericalLives.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseLife()
    {
        // Subtract the live from your lives bar.
        numericalLives = numericalLives - 1;

        // Update the visaul text of Lives.
        livesText.text = numericalLives.ToString();
    }

    public void SaveLives()
    {
        PlayerPrefs.SetInt("lives", numericalLives);
    }


    public bool isGameOver()
    {
        if (numericalLives <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
