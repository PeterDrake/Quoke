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

    public static string[] recs;// { get;}
    public static int[] recsp;//{ get; }

    private void Awake()//earlist call function
    {
         recs = Managers.getRec();
        recsp = Managers.getRecp(); 
        SInventory = GetComponent<InventoryManager>();
        SInventory.Startup();
        while (SInventory.status.Equals("Started"))
        {
            //wait until inventory is started
        }
        populate();
    }   
   public int[] getPrices()
    {
        return recsp;
    }
    void populate()
    {

        for (int i = 0; i < recs.Length; i++)
        {
            SInventory.AddItem(recs[i],recsp[i]);
        }
    }




}