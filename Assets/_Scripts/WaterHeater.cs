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


    /// <summary>
    /// if there is a wrench then the player can shut gas off disalowing the explosion
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {                //Debug.Log("check o up");
        Messenger.AddListener(GameEvent.W_MAIN_SHUT, isWater);
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
    void Update()
    {
        if (Managers.Inventory.GetItemList().Contains("hose") && Managers.Inventory.GetItemList().Contains("jug") && trig)
        {               // Debug.Log("checkk i up");
            prompt.text = "Press [E] to get water.";
            if (Input.GetKeyDown(KeyCode.E) && isWaterMainOff)
            {
                Managers.Inventory.removeItem("jug");
                Managers.Inventory.AddItem("jug(CLEAN)");
            }
            else if (Input.GetKeyDown(KeyCode.E) && !isWaterMainOff)
            {
                Managers.Inventory.removeItem("jug");
                Managers.Inventory.AddItem("jug(DIRTY)");     
            }
        }
        else
        {
            prompt.text = "You need a hose and jug to collect the water.";
        }
    }
}
