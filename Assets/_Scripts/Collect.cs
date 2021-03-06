﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Collect script to be given to all collectable objects adds them to player inventory via Manager System.
/// </summary>
//script for all collectable items to add them to inventory
public class Collect : MonoBehaviour
{
    /// <summary>
    /// name of item this is set in the inspector when the scripts is added to an object
    /// </summary>
    //[SerializeField] private string itemName;
    private Sprite sprite;

    private bool triggered;
    private string itemName;
     private void Start()
    {
        itemName = this.gameObject.name;
        DontDestroyOnLoad(this.gameObject);
       // itemName=itemName.Substring(0,itemName.IndexOf('('));
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }

    public void setName(string n)
    {
        this.itemName = n;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& triggered)
        {
            Debug.Log("picked up");

            Managers.Inventory.AddItem(itemName);

            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// when the mouse is over the object it is glowed and if the user presses action button 'E' the item is picked up
    /// </summary>
    private void OnTriggerEnter()
    {
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = true;
        triggered = true;

    }
    /// <summary>
    /// On the mouse exit shuts off the back glow
    /// </summary>
    private void OnTriggerExit()
    {
        triggered = false;
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }
}
