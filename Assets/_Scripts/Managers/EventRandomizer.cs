using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventRandomizer : MonoBehaviour, IGameManager
{
    private float gasLeak;
    
    private bool gasShut;

    private  float gasExplosion;

    private float RainBucket;

    private int waterLevel;

    private float storeStable;

    private float houseStable;

    private float roll;
    
    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener(GameEvent.ACTION_TAKEN,rollStore);
      Messenger.AddListener(GameEvent.ACTION_TAKEN,rollExpo);  
        Messenger.AddListener(GameEvent.ACTION_TAKEN,rollHouse);
    }

    private void rollStore()
    {
        if (Managers.quake && storeStable < .5)
        {
            Messenger.Broadcast(GameEvent.SAFE);
            gasExplosion = Random.value;
            if (gasExplosion < .1)
            {
                Messenger.Broadcast(GameEvent.COLLAPSE);
            }
        }    
    }

    private void rollHouse()
    {
        if (Managers.quake && houseStable < .5)
        {
            Messenger.Broadcast(GameEvent.SAFE);
            gasExplosion = Random.value;
            if (gasExplosion < .1)
            {
                Messenger.Broadcast(GameEvent.COLLAPSE);
            }
        }
     //   throw new NotImplementedException();
    }

    public  void rollExpo()
    {
        if (Managers.quake&& gasLeak <.5 && !gasShut)
        {    
            Messenger.Broadcast(GameEvent.GASLEAK);
            
            gasExplosion = Random.value;
            if (gasExplosion < .1)
            {
                Messenger.Broadcast(GameEvent.GASEXPO);
            }
            
        }

        // return gasExplosion;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public ManagerStatus status { get; }
    public void Startup()
    {
        gasLeak = Random.value;
        houseStable = Random.value;
        storeStable = Random.value;
        
        
       // throw new System.NotImplementedException();
    }
}