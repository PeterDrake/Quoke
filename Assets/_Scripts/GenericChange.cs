using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericChange : MonoBehaviour
{

    //public Canvas message;
    public string StreetScene;
    private Scene[] scenes;
    void Start()
    {  scenes = new Scene[SceneManager.sceneCount];
    
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            scenes[i] = SceneManager.GetSceneAt(i);
            Debug.Log(scenes[i]);
        }
    }

    //void OnMouseOver()
  void OnTriggerStay()
    {
        //message.gameObject.SetActive(true);

        //   [E] TO ENTER HOUSE

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(StreetScene,LoadSceneMode.Additive);
           


           // this.gameObject.get
        }
    }

    private void OnTriggerExit()
    {
       // message.gameObject.SetActive(false);
    }   
}