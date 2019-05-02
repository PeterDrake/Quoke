using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour
{
    /// <summary>
    /// Quits application. Called when "Quit" button is pressed in GameOverScene.
    /// </summary>
    public void Quit() //actually, this is the quit function
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    /// <summary>
    /// Starts the game by loading SystemsScene. Called when "Start" button is pressed in StartScene.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("SystemsScene");
    }
}
