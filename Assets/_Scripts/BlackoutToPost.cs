using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackoutToPost : MonoBehaviour
{

    // name of current scene
    private string currentScene;
    
    // On awake, sets script to false and disables BlackScreen panel
    private void Awake()
    {
        gameObject.GetComponent<BlackoutToPost>().enabled = false;
        gameObject.transform.Find("BlackScreen").gameObject.SetActive(false);
    }

    // On start, gets scene name and invokes GoBlack method
    void Start()
    {
        //gameObject.transform.Find("BlackScreen").GetComponent<Image>().color = new Color(0,0,0,0);
        currentScene = SceneManager.GetActiveScene().name;
        Invoke("GoBlack", 6);
    }

    // Turns screen black and teleports player to post-quake scenes after
    void GoBlack()
    {
        gameObject.transform.Find("BlackScreen").gameObject.SetActive(true);
        gameObject.transform.Find("BlackScreen").GetComponent<Image>().color = new Color(0,0,0,255);
        if (currentScene == "HouseInterior")
        {
            Managers.Level.GoToScene("QuakeHouseInterior");
        } else if (currentScene == "StreetScene")
        {
            Managers.Level.GoToScene("QuakeStreetScene");
        }
        Invoke("ToPost",2);
        
    }

    
    // Disables BlackScreen and sets Quake boolean to true
    void ToPost()
    {
        Managers.Quake();
        gameObject.transform.Find("BlackScreen").gameObject.SetActive(false);
        gameObject.GetComponent<BlackoutToPost>().enabled = false;
    }
}
