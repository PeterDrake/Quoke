using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secure : MonoBehaviour
{
    private bool trigg;
    private bool tool;
    [SerializeField] private Text promt;

    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener(GameEvent.QUAKE,des);
        promt.gameObject.SetActive(false);
        promt.text = "press [E] to secure shelf";
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
        tool = Managers.Inventory.GetItemList().Contains("tools");
    }

    void des()
    {
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            trigg = true;
        }

        if (trigg&&Managers.Player.homeOwner && Managers.Inventory.GetItemList().Contains("tools"))
            {
                Debug.Log("ONNNN");
                Behaviour halo = (Behaviour) this.gameObject.GetComponent("Halo");
                halo.enabled = true;
                promt.gameObject.SetActive(true);
            }

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
        if (Managers.Player.homeOwner&&trigg)
        {
           

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("SECURED SHELF");

                Messenger.Broadcast(GameEvent.ACTION_TAKEN);

                Messenger.Broadcast(GameEvent.SEC);

                Debug.Log("seced");
                //OnTriggerExit();
                promt.gameObject.SetActive(false);
                trigg = false;
                Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
                halo.enabled = false;
                Destroy(gameObject);
            }
        }

        if (Managers.quake)
        {
            Destroy(gameObject);

        }
        
    }
}
