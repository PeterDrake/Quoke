using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Canvas message;
    public string StreetScene;

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
            SceneManager.LoadScene(StreetScene);
        }
    }
    private void OnTriggerExit()
        {
        message.gameObject.SetActive(false);
        }
    }