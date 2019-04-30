using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour
{
    public void Continue() //actually, this is the quit function
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SystemsScene");
    }
}
