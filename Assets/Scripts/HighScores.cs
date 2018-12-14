using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Neededfor weorking with text componeents.
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    // Text components used to display the high scores.
    public List<Text> highScoreDisplays;

    // Internal data for score values.
    private List<int> highScoreData = new List<int>();



	// Use this for initialization
	void Start () {

        // Load the high score data from PlayerPrefs.
        LoadHighScoreData();


        int currentScore = PlayerPrefs.GetInt("score", 0);


        // Check if we got a new high score.
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore == true)


            // Add new score to the data.
            AddScoreToList(currentScore);

        // Save updated data.
        SaveHighScoreData();

        // Update the visual display.
        UpdateVisualDisplay();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void  LoadHighScoreData()
    {

        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Using the loop index, get the name for our PlyerPrefs key
            string prefsKey = "highScore" + i.ToString();


            // Use this key to get the high score value from PayerPrefs.
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);


            // Store this score  value in our internal data list.
            highScoreData.Add(highScoreValue);

        }

    }

    private void UpdateVisualDisplay()
    {

        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Find the specific text and numbers in our list.
            // Set the text to numerical value.
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }

    }

    private bool IsNewHighScore(int scoreToCheck)
    {

         for (int i = 0; i < highScoreDisplays.Count; ++i)
            {
            if (scoreToCheck > highScoreData[1])
            {
                // Our score is higher!
                // Return to the calling code that we DO have a new high score.
                return true;
            }

            }


                // defoult: false
                return false;
    }

    private void  AddScoreToList(int newScore)
    {

        // Loop through the high scores and find where the new score fits.
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {

            if (newScore > highScoreData[i])
            {
                // Our score IS higher.
                // Since we are going from highest to lowest, the first time pour score is higher, this is where it must go.


                // Insert the new score into the list here.
                highScoreData.Insert(i, newScore);

                // Trim the list item of the list.
                highScoreData.RemoveAt(highScoreData.Count - 1);


                // We are done, we must exit early.
                return;
            }


        }


    }

    private void SaveHighScoreData()
    {

        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Using the loop index, get the name for our PlyerPrefs key
            string prefsKey = "highScore" + i.ToString();

            // Get the current high score entry from the data.
            int highScoreEntry = highScoreData[i];


            // Save this data to the player prefs.
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
        }

        // Save the player prefs to disk.
        PlayerPrefs.Save();

    }

}
