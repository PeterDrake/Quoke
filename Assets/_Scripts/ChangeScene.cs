using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public GameObject enterText;
    public string StreetScene;

    void Start()
    {
        enterText.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider Door_02)
    {
        if (Door_02.gameObject.tag == "DoorToStreet")
        {
            enterText.SetActive(true);
            if (Input.GetButtonDown("Use"))
            {
                SceneManager.LoadScene(StreetScene);
            }
        }
    }
    void OnTriggerExit(Collider Door_02)
    {
        if (Door_02.gameObject.tag == "DoorToStreet")
        {
            enterText.SetActive(false);
        }
    }
}