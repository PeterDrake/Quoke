﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkWater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text promt;
    private bool triggered;
    void Start()
    {   
        promt.gameObject.SetActive(false);
        promt.text = "press [E] to get water";
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = true;
        triggered = true;
    }

    private void OnTriggerExit()
    {
        triggered = false;
        promt.gameObject.SetActive(false);

        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Managers.Inventory.GetItemList().Contains("jug")&&triggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Managers.Inventory.removeItem("jug");
                Managers.Inventory.AddItem("jug(CLEAN)");
                Messenger.Broadcast(GameEvent.WATER);
            }
        }
    }
}
