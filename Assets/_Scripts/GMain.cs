using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMain : MonoBehaviour
{
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
    private void OnTriggerStay(Collider other)
    {
        if (Managers.Inventory.GetItemList().Contains("wrench"))
        {
            Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
            halo.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("picked up");
                Messenger.Broadcast(GameEvent.G_MAIN_SHUT);
            }
        }
    }

    private void OnTriggerExit()
    {
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
