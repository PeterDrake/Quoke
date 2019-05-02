using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quake : MonoBehaviour
{

    private GameObject environment;
    private float countdown;

    void Awake()
    {
        gameObject.GetComponent<Quake>().enabled = false;
        countdown = 3;
    }

    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            GameObject.Find("ToPostQuake").GetComponent<BlackoutToPost>().enabled = true;
        } else if (countdown <= 0)
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
