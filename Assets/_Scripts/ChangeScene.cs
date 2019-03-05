using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

       public GameObject enterText;
       public string StreetScene;

    // void Start()
    // {
    //     enterText.SetActive(false);
    // }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(StreetScene);
        }
    }
}