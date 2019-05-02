using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBucketWater : MonoBehaviour
{
    private Behaviour halo;
    private bool trig;
    /// <summary>
    /// creates a text box
    /// trig - checks if player is inside a trigger
    /// waterCollectionMethod - boolean check if jug in inventory
    /// </summary>
    [SerializeField] public Text prompt;
    private List<string> items;
    private bool waterCollectionMethod;

    // Start is called before the first frame update
    void Start()
    {
        items = Managers.Inventory.GetItemList();
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        prompt.gameObject.SetActive(false);
        trig = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        waterCollectionMethod = items.Contains("jug");
        prompt.gameObject.SetActive(true);
        halo.enabled = true;
        trig = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trig = false;
        prompt.gameObject.SetActive(false);
        halo.enabled = false;
    }
    /// <summary>
    /// when the mouse is over the object it is glowed and if the user presses action button 'E' the item is picked up
    /// </summary>

    private void Update()
    {
        // if randomization put water in bucket and player is in the trigger
        if (Managers.Player.bucketFill && trig)
        {
            if (waterCollectionMethod)
            {
                prompt.text = "The bucket is full! Press [E] to collect water."; //add else if statements to fix text
                // replaces empty jug with jug filled with dirty water in inventory
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Managers.Inventory.removeItem("jug");
                    Managers.Inventory.AddItem("jug(DIRTY)");
                }
            }
            else
            {
                prompt.text = "The bucket is full, but you don't have a way to store the water!";
            }
        }
        else
        {
            prompt.text = "This bucket is empty. Check back later!";
        }
        //print bucket is empty
    }
}