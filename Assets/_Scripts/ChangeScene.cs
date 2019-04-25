using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Canvas message;
    private bool isTriggered;
    public string scene;
    public string sceneb;
    void Start()
    {
        message.gameObject.SetActive(false);
        isTriggered = false;
        Debug.Log(scene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
            if (Managers.quake)
            {
                Managers.Level.GoToScene(sceneb);

            }
            else
            {
                Managers.Level.GoToScene(scene);

            }
        }
    }

    // void OnMouseOver()
    void OnTriggerStay()
    {
        message.gameObject.SetActive(true);
        isTriggered = true;
    }
    private void OnTriggerExit()
    {
        message.gameObject.SetActive(false);
        isTriggered = false;
    }

  
}