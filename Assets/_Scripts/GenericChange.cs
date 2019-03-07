using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericChange : MonoBehaviour
{

    //public Canvas message;
    public string StreetScene;

    void Start()
    {
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;// message.gameObject.SetActive(false);
    }

    void OnMouseOver()
  // void OnTriggerStay()
    {
        //message.gameObject.SetActive(true);

        //   [E] TO ENTER HOUSE
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(StreetScene,LoadSceneMode.Additive);
            Scene []  s=SceneManager.GetAllScenes();
            SceneManager.UnloadScene(s[1]);
        }
    }

    private void OnTriggerExit()
    {
       // message.gameObject.SetActive(false);
    }   
}