using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitiateQuake : MonoBehaviour
{

    private int count;
    private int check;
    public float time;
    public GameObject player;


    // On awake, determines random amount of actions and time countdown for panel
    private void Awake()
    {
        check = Random.Range(10, 16);
        time = 5;
    }

    // On initial start, turns off panel
    void Start()
    {
        gameObject.transform.Find("Transition").gameObject.SetActive(false);
        count = Managers.Player.actionCount;
        
        // cautionary if statement to turns off panel after being activated
        if (count >= check)
        {
            gameObject.transform.Find("Transition").gameObject.SetActive(false);
            gameObject.GetComponent<InitiateQuake>().enabled = false;
        }
    }

    // Every frame, checks to see if action count is compared to check
    void Update()
    {   
        count = Managers.Player.actionCount;
        if (count >= check && time > 0)
        {
            // Disables ChangeScene scripts
            if (SceneManager.GetActiveScene().name == "HouseInterior")
            {
                GameObject.Find("Door_02").GetComponent<ChangeScene>().enabled = false;
            } else if (SceneManager.GetActiveScene().name == "StreetScene")
            {
                GameObject.Find("SM_Bld_Shop_03").GetComponent<ChangeScene>().enabled = false;
                GameObject.Find("SM_Bld_House_Preset_07").GetComponent<ChangeScene>().enabled = false;
            } else if (SceneManager.GetActiveScene().name == "Store")
            {
                GameObject.Find("SI_Prop_SecurityScanner_01").GetComponent<ChangeScene>().enabled = false;
            }
            
            // Turns on "Later that day" panel
            gameObject.transform.Find("Transition").gameObject.SetActive(true);
            time -= Time.deltaTime;

        } else if (time <= 0)
        {
            // Enables Teleport Script
            gameObject.transform.Find("Transition").gameObject.SetActive(false);
            player.GetComponent<Teleport>().enabled = true;
        }
    }
}
