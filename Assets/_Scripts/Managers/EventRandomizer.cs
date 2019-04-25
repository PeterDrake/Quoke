﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventRandomizer : MonoBehaviour, IGameManager
{
    private float gasLeak;

    private  float gasExplosion;

    private float RainBucket;
    private float fall;
    private int waterLevel;
    private double storeStable;
    private double houseStable;
    //if ture then explosion will happen
    private bool Gexpo=true;

    // Start is called before the first frame update
    void Start()
    {
      Messenger.AddListener(GameEvent.ACTION_TAKEN,rollExpo);  
      Messenger.AddListener(GameEvent.ACTION_TAKEN,rollHouse);
      Messenger.AddListener(GameEvent.G_MAIN_SHUT,stopExpo);
    }

    private void stopExpo()
    {
        Gexpo = false;
    }

/// <summary>
/// called every action after the quake if the houese is unstable there is a 10% of its collapse if palyer is in it 
/// </summary>
    private void rollHouse()
    {
        if ((!Managers.quake || !(houseStable < .5))){ 
            Messenger.Broadcast(GameEvent.SHELTER);
            return;
        }
        fall = Random.value;
        if (fall < .1)
        {
            Messenger.Broadcast(GameEvent.COLLAPSE);
        }
    }

    public  void rollExpo()
    {
        if (!Managers.quake || !(gasLeak < .5) || !Gexpo) return;
        
        gasExplosion = Random.value;
        if (gasExplosion < .1)
        {
            Debug.Log("bloe:");
            Messenger.Broadcast(GameEvent.G_MAIN_EXPO);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    void inspect()
    {
        if (gasLeak < .5)
        {
            Messenger.Broadcast(GameEvent.SMELL);
        }

        if (houseStable < .5)
        {
            Messenger.Broadcast(GameEvent.SAFE);
        }
    }
    public ManagerStatus status { get; private set; }

    /// <summary>
    /// assigns the random values  for the stability of the house and likley hood of gas main
    /// </summary>
    public void Startup()
    {
        gasLeak = Random.value;
        Debug.Log("gass "+ gasLeak);
        houseStable= Random.value;
        status = ManagerStatus.Started;

       // throw new System.NotImplementedException();
    }
}
