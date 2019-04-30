using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour
{
    public void Continue()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
