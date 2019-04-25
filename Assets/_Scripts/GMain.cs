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
    {                Debug.Log("check o up");

        if (Managers.Inventory.GetItemList().Contains("wrench"))
        {                Debug.Log("checkk i up");

            Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
            halo.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("shut up");
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
