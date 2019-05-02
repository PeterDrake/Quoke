using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterHeater : MonoBehaviour
{
    private bool trig;
    private bool isWaterMainOff = false;
    private Behaviour halo;
    [SerializeField] public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        prompt.gameObject.SetActive(false);
    }

    private void isWater() {
        isWaterMainOff = true;
    }

    private void OnTriggerEnter(Collider other)
    {               
        Messenger.AddListener(GameEvent.W_MAIN_SHUT, isWater);
        trig = true;
        prompt.gameObject.SetActive(true);
        halo.enabled = true;
    }
    /// <summary>
    /// destroys scripts onces executed
    /// </summary>
    void des()
    {
        if (Managers.perm.wh)
        {
            OnTriggerExit();
            this.enabled = false;
            
        }
    }
    private void OnTriggerExit()
    {
        trig = false;
        halo.enabled = false;
        prompt.gameObject.SetActive(false);
    }
    // Update is called once per frame
    /// <summary>
    /// if there is a hose and jug, and player in trigger, player can collect water from water heater
    /// if the water main is off you get clean water, else you get dirty water
    /// alt message appears if no hose or jug in inventory
    /// </summary>
    void Update()
    {
        if (Managers.Inventory.GetItemList().Contains("hose") && Managers.Inventory.GetItemList().Contains("jug") && trig)
        {              
            prompt.text = "Press [E] to get water.";
            if (Input.GetKeyDown(KeyCode.E) && Managers.perm.fw)
            {
                Managers.Inventory.removeItem("jug");
                Managers.Inventory.AddItem("jug(CLEAN)");
                Messenger.Broadcast(GameEvent.WATER);
                Messenger.Broadcast(GameEvent.WH);
            }
            else if (Input.GetKeyDown(KeyCode.E) && !Managers.perm.fw)
            {
                Managers.Inventory.removeItem("jug");
                Managers.Inventory.AddItem("jug(DIRTY)");
                Messenger.Broadcast(GameEvent.WH);
            }
        }
        else
        {
            prompt.text = "You need a hose and jug to collect the water.";
        }

        des();
    }
}
