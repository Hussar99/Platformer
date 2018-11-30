using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {


    // Called when tiotle button  is clicked.
    public void GoToTitle()
    {

        //  Return to title screen.
        SceneManager.LoadScene("Title");

    }

}
