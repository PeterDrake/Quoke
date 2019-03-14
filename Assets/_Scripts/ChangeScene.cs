using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Canvas message;
    public string scene;

     void Start()
     {
        message.gameObject.SetActive(false);
     }

   // void OnMouseOver()
   void OnTriggerStay()
    {
        message.gameObject.SetActive(true);

     //   [E] TO ENTER HOUSE
        if (Input.GetKeyDown(KeyCode.E))
        {
            Managers.Level.GoToScene(scene);
        }
    }
    private void OnTriggerExit()
        {
        message.gameObject.SetActive(false);
        }
    }