using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quake : MonoBehaviour
{

    private GameObject environment;
    private float countdown;

    // Sets countdown, turns script off
    void Awake()
    {
        gameObject.GetComponent<Quake>().enabled = false;
        countdown = 3;
    }

    // Every frame, checks for countdown until 0
    void Update()
    {   
        // Disables ChangeScene scripts
        if (SceneManager.GetActiveScene().name == "HouseInterior")
        {
            GameObject.Find("Door_02").GetComponent<ChangeScene>().enabled = false;
        } else if (SceneManager.GetActiveScene().name == "StreetScene")
        {
            GameObject.Find("SM_Bld_Shop_03").GetComponent<ChangeScene>().enabled = false;
            GameObject.Find("SM_Bld_House_Preset_07").GetComponent<ChangeScene>().enabled = false;
        }
        
        // Tracks countdown and activates BlackoutToPost script
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            GameObject.Find("ToPostQuake").GetComponent<BlackoutToPost>().enabled = true;
        }
        // Enables CameraShake, PushObject, and Damager.
        // Turns Quake off
        else if (countdown <= 0)
        {
            environment = GameObject.Find("Environment");
            environment.GetComponent<CameraShake>().enabled = true;
            if (SceneManager.GetActiveScene().name == "HouseInterior")
            {
               Messenger.Broadcast(GameEvent.QUAKE);
                
                GameObject.Find("Bookshelf").GetComponent<PushObject>().enabled = true;
                if (GameObject.Find("Bookshelf").GetComponent<Damager>() != null)
                {
                GameObject.Find("Bookshelf").GetComponent<Damager>().enabled = true;
                }
            }
            gameObject.GetComponent<Quake>().enabled = false;
        }
    }
}
