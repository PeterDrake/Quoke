using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMain : MonoBehaviour
{
    private bool trig;
    // Start is called before the first frame update
    void Start()
    {    
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }

    
    /// <summary>
    /// if there is a wrench then the player can shut gas off disalowing the explosion
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {                //Debug.Log("check o up");
        trig = true;

    }

    private void OnTriggerExit()
    {
        trig = false;
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Managers.Inventory.GetItemList().Contains("wrench")&&trig)
        {               // Debug.Log("checkk i up");

            Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
            halo.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Debug.Log("shut up");
                Messenger.Broadcast(GameEvent.G_MAIN_SHUT);
            }
        }
    }
}
