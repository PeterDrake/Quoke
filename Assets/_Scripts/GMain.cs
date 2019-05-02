using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMain : MonoBehaviour
{
    // trig - checks if player is inside a trigger
    private bool trig;
    private bool off = false;
    private Behaviour halo;
    [SerializeField] public Text prompt;
    // Start is called before the first frame update
    void Start()

    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        prompt.gameObject.SetActive(false);
//>>>>>>> master
    }
    
    private void OnTriggerEnter(Collider other)

    {
       
            //Debug.Log("check o up");
            trig = true;
            prompt.gameObject.SetActive(true);
            halo.enabled = true;
       
//>>>>>>> master
    }

    void des()
    {
        
            OnTriggerExit();
            Destroy(gameObject);
            Destroy(this);
        
    }
    /// <summary>
    /// turns off the prompt screens
    /// </summary>
    private void OnTriggerExit()
    {
        trig = false;
        halo.enabled = false;
        prompt.gameObject.SetActive(false);
    }
//<<<<<<< HEAD
    // Update is called once per frame
    /// <summary>
    /// if there is a wrench and player is in trigger, player can shut gas off disalowing the explosion
    /// alt message appears if no wrench in inventory
    /// </summary>

    void Update()
    {
        if (Managers.Inventory.GetItemList().Contains("wrench") && trig)
        {              
                prompt.text = "Press [E] to shut off gas main.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                // broadcasts the game event that the gas main has been shut off
                Messenger.Broadcast(GameEvent.G_MAIN_SHUT);
            }
        }
        else
        {
            prompt.text = "You need a wrench to shut off the gas.";
        }

        if (Managers.perm.fg)
        {            OnTriggerExit();

            this.enabled = false;
        }
    }
}
