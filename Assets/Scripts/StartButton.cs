using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This allows to use the scene loading function.
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    // This will be called by the button component when the button will be clicked.
    public void StartGame()
    {
        //Reset the Lives
        PlayerPrefs.DeleteKey("lives");


        // Resets the score.
        PlayerPrefs.DeleteKey("score");




        // Load the first level.
        SceneManager.LoadScene("LVL 1");
    }

}
