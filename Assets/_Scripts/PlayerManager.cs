using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour,IGameManager
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


    /// <summary>
    /// Startup this instance 
    /// sets all atribut values 
    /// TODO add randomizer to shift additional values
    /// </summary>
    public void Startup()
    {
        Debug.Log("Inventory starting ");
        health = 100;
        water = false;
        shelter = false;
        actionCount = 0;
        status = ManagerStatus.Started;
    }

    /// <summary>
    /// Sets health to 0 if Player takes a hit.
    /// </summary>
     
    public void takeHit()
    {
        health = 0;
        Debug.Log("YOU DIED");
    }

    /// <summary>
    ///inceases the action count by 1
    /// </summary>
    public void action()
    {
        actionCount++;
    }

    /// <summary>
    /// Changes the water status.
    /// </summary>
    public void ChangeWater()
    {
        water = !water;
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
    /// not written
    /// TODO complete
    /// </summary>
    private void Randomize()
    {
        //TODO finsih
    }


}