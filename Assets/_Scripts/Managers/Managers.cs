using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerManager))] //makes sure that these class/files are present before 
// starting to avoid errors
[RequireComponent(typeof(InventoryManager))]

[RequireComponent(typeof(LevelManager))]

[RequireComponent(typeof(EventRandomizer))]
[RequireComponent(typeof(Perminace))]

/*
 * Main manger for both payer and inventory systmes
 * all code taken from thw Unity In Action book 2nd Ed J.Hocking
 */
public class Managers : MonoBehaviour
{
    public bool testing;
    public bool gasOff;
    public static PlayerManager Player { get; private set; } //player systems manager
    public static InventoryManager Inventory { get; private set; } //player inventory manager

    private EventRandomizer RandomEvents;//{ get; private set; } //player inventory manager
    private Perminace p;
    public static LevelManager Level { get; private set; }

    //  public string scene;
    private List<IGameManager> startSeq; //list of managers to spool up in start. A

    public static bool quake { get; private set; }
    public static string[] recs { get; private set; }
    public static int[] recsp { get; private set; }
    //public static Dictionary<string><int> rec;// { get; private set;}



    private void Awake()//earlist call function
    {
        DontDestroyOnLoad(gameObject);
        
        
    recs = new string[] { "iodine tablets", "bleach", "jug", "tent", "wrench", "tools", "bucket", "bags", "shovel", "pick", "sawdust", "hand sanitizer", "hose" };
        recsp = new int[] { 7, 4, 13, 100, 10, 35, 5, 15, 10, 20, 15, 3, 7 };
        //	EditorSceneManager.preventCrossSceneReferences = false;
        //SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        Inventory = GetComponent<InventoryManager>();
        Player = GetComponent<PlayerManager>();
        Level = GetComponent<LevelManager>();
        RandomEvents = GetComponent<EventRandomizer>();
        startSeq = new List<IGameManager>();
        quake = false;
        p = GetComponent<Perminace>();
        startSeq.Add(Inventory);
        startSeq.Add(Player);
        startSeq.Add(Level);
        startSeq.Add(RandomEvents);
        startSeq.Add(p);
        StartCoroutine(StartUpManagers());//inits all manager states
    }

   public static string[] getRec()
    {
        //rec.getKeys.toArray
        
        return recs;
    }
   public static int[] getRecp()
    {
        return recsp;
    }

    public bool isGasMainOff()
    {
        return gasOff;
    }

   public  static void Quake()
   {
       quake = true;
   }
    /*
     * this calls the StatUp method on all managers then countinues to check status until all are started  
     */
    private IEnumerator StartUpManagers()
    {
        foreach (IGameManager manager in startSeq)
        {
            manager.Startup();
        }

        yield return null;
        int numMods = startSeq.Count;//number of manager modules to be loaded
        int numGo = 0;//num modules loaded

        while (numGo < numMods)// runs until all modules are loaded
        {
            int lastReady = numGo;
            numGo = 0;
            foreach (IGameManager manager in startSeq)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numGo++;
                }
            }
            //load progress
            if (numGo > lastReady)
            {
                Debug.Log("loaded " + numGo + "/" + numMods);
                yield return null;

            }

            Debug.Log("all managers loaded");

        }
       // Inventory.AddItem(("tent"));
       Inventory.AddItem("tools");

       //Level.GoToScene(4);
        if (!testing)
        {
            Level.GoToNext();
        }
    }

  
}