using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secure : MonoBehaviour
{
    private bool trigg;
    [SerializeField] private Text promt;

    // Start is called before the first frame update
    void Start()
    {
        promt.gameObject.SetActive(false);
        promt.text = "press [E] to secure shelf";
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = true;
        trigg = true;
        promt.gameObject.SetActive(true);

    }
    private void OnTriggerExit()
    {
        promt.gameObject.SetActive(false);

        trigg = false;
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Managers.Player.homeOwner && Managers.Inventory.GetItemList().Contains("tools")&&trigg)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
             Messenger.Broadcast(GameEvent.ACTION_TAKEN);
            // gameObject.GetComponent<Damager>().
                Messenger.Broadcast(GameEvent.SEC);
            }
        }
    }
}
