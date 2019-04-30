using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackoutToPost : MonoBehaviour
{

    private string currentScene;
    
    private void Awake()
    {
        gameObject.GetComponent<BlackoutToPost>().enabled = false;
        gameObject.transform.Find("BlackScreen").gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.Find("BlackScreen").GetComponent<Image>().color = new Color(0,0,0,0);
        currentScene = SceneManager.GetActiveScene().name;
        Invoke("GoBlack", 6);
    }

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

    void ToPost()
    {
        gameObject.transform.Find("BlackScreen").gameObject.SetActive(false);
        gameObject.GetComponent<BlackoutToPost>().enabled = false;
    }
}
