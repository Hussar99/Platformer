using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code.

using UnityEngine.UI;

public class Score : MonoBehaviour {

    // variable to tracvk the visable text score.
    // Public to let us drag and drop in the editor.
    public Text scoreText;


    // Variabler to track the numberical score.
    // Private because other scripts should not change the script directly.
    //change it directly
    // Defoult to 0 since we should have no score when we are starting.
    private int numericalScore = 0;
    





	// Use this for initialization
	void Start () {
        // Get the score from the prefs database.
        // Use a default of 0 of no score was saved.
        // Store the result in our numerical score variable.
        numericalScore = PlayerPrefs.GetInt("score", 0);

        // Update the visual score.
        scoreText.text = numericalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Function will increase the score.
    // public  so other scripts can use it such as the coin.
    public void AddScore(int _toAdd)
    {
        //Add the ammount to the numerical score.
        numericalScore = numericalScore + _toAdd;

        //Updarte the visual score.
        scoreText.text = numericalScore.ToString();
    }

    // Function to save the score to the player preferences.
    // Pulic so it can be triggered form another script (aka door/portal)
    public void saveScore()
    {
        PlayerPrefs.SetInt("score", numericalScore);
    }
}
