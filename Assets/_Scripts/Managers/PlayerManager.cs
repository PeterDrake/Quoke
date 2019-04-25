using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    //////// all player attributes 
    /// more can be added later 
    //health of the player 
    public int health { get; private set; }
    //boolean of shelter status
    public bool shelter { get; private set; }
    // water status
    public bool water { get; private set; }
    //number of actions taken by player
    public int actionCount { get; private set; }
    //randomly gerneated resource;
    public double cash { get;  set; }
    //randomly assigned true or false for water in outside gutter bucket
    public bool bucketFill { get; private set; }
    //randomly assigend atribute false for renter and true for owner
    public bool homeOwner { get; private set; }


    public string[] recs;
    public int[] recsp;

    
    /// <summary>
    /// Startup this instance 
    /// sets all atribut values 
   
    /// </summary>
    public void Startup()
    {
        recs = Managers.getRec();
        recsp = Managers.getRecp();
        Debug.Log("Inventory starting ");
        health = 100;
        water = false;
        shelter = false;
        Randomize();
        actionCount = 0;
        Messenger.AddListener(GameEvent.ACTION_TAKEN,takeAction);
        Messenger.AddListener(GameEvent.SHELTER,ChangeShelter);
        Messenger.AddListener(GameEvent.HEALTH_CHANGED, takeHit);
        Messenger.AddListener(GameEvent.WATER,ChangeWater);
       // Messenger.AddListener(GameEvent.WINNER,takeAction);


        status = ManagerStatus.Started;
        
    }


    /// <summary>
    /// Sets health to 0 if Player takes a hit.
    /// </summary>

    public void takeHit()
    {
        health = 0;
        Debug.Log("YOU DIED");
        //end game 
        //destory scene and draw black screen
    }

    /// <summary>
    ///inceases the action count by 1
    /// </summary>
    public void takeAction()
    {
        actionCount++;
        Debug.Log("AC==="+ actionCount);
    }

    /// <summary>
    /// Changes the water status.
    /// </summary>
    public void ChangeWater()
    {
        water = !water;
        //  SetText();
        Debug.Log("You have aquired water!!");


    }




    //changes the shelter status
    /// <summary>
    /// Changes the shelter status.
    /// </summary>
    public void ChangeShelter()
    {
        shelter = !shelter;
        Debug.Log("You have aquired shelter!!");
    }

    //check is all three win conditions are met
    public void WinCheck()
    {
        if (water && shelter && health == 100)
        {
            Debug.Log("YOU SURVIVED");
        }
    }
    /// <summary>
    /// used to set random values to various player attributes
    /// </summary>
    private void Randomize()
    {
        // recs = 
        cash = Random.Range(10, 200);
        int c= Random.Range(0, 100);
        homeOwner = c < 50;// 50/50 of owner less than 50 is an owner and vis virsa
        int num = Random.Range(1, 4);
        Debug.Log(num);
        for (int i = 0; i < num; i++)
        {
            int r = Random.Range(0, recs.Length);
            //int b = Random.Range(0, 10);
            bucketFill = true;
            Debug.Log(recs[r]);
            if (Managers.Inventory.items.Contains(recs[r]))
            {
                i--;continue;
            }
            Managers.Inventory.AddItem(recs[r]);
        }
    }
}