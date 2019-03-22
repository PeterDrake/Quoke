using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
//.using UnityEngine.SceneManagement;
//using UnityEngine.UI;

[RequireComponent(typeof(InventoryManager))]

/*
 * Main manger for both payer and inventory systmes
 * all code taken from thw Unity In Action book 2nd Ed J.Hocking
 */
public class StoreManager: MonoBehaviour
{
    public static InventoryManager SInventory { get; private set; } //player inventory manager
    private string[] recs = new string[] { "iodine tablets", "bleach", "tent", "wrench", "tools", "bucket", "bags", "shovel", "pick", "sawdust" };



    private void Awake()//earlist call function
    {
        SInventory = GetComponent<InventoryManager>();
        SInventory.Startup();
        while (SInventory.status.Equals("Started"))
        {
            //wait until inventory is started
        }
        populate();
    }   

    void populate()
    {

        for (int i = 0; i < recs.Length; i++)
        {
            SInventory.AddItem(recs[i]);
        }
    }


}