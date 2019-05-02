using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WMain : MonoBehaviour
{
    // trig - checks if player is inside a trigger
    private bool trig;
    private Behaviour halo;
    [SerializeField] public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        prompt.gameObject.SetActive(false);
    }


    void des()
    {
        if (Managers.perm.fw)
        {
            OnTriggerExit();
            Destroy(this);
        }
    }

    /// <summary>
    /// if there is a wrench then the player can shut gas off disalowing the explosion
    /// </summary>
    /// <param name="other"></param>
//>>>>>>> master
    private void OnTriggerEnter(Collider other)
    {               
        trig = true;
        prompt.gameObject.SetActive(true);
        halo.enabled = true;
    }

    private void OnTriggerExit()
    {
        trig = false;
        halo.enabled = false;
        prompt.gameObject.SetActive(false);
    }
    // Update is called once per frame
    /// <summary>
    /// if there is a wrench and player is in trigger, player can shut water off, disalowing dirty water from water heater
    /// alt message appears if no wrench in inventory
    /// </summary>
    void Update()
    {
        if (Managers.Inventory.GetItemList().Contains("wrench") && trig)
        {               
            prompt.text = "Press [E] to shut off water main.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                // broadcasts the game event that the water main has been shut off
                Messenger.Broadcast(GameEvent.W_MAIN_SHUT);
            }
        }
        else
        {
            prompt.text = "You need a wrench to shut off the water.";
        }
        des();
    }
}
