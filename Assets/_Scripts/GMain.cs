using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMain : MonoBehaviour
{
    private bool trig;
    private bool off = false;
    private Behaviour halo;
    [SerializeField] public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        prompt.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// if there is a wrench then the player can shut gas off disalowing the explosion
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {                //Debug.Log("check o up");
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
        if (Managers.Inventory.GetItemList().Contains("wrench") && trig)
        {               // Debug.Log("checkk i up");
                prompt.text = "Press [E] to shut off gas main.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Debug.Log("shut up");
                Messenger.Broadcast(GameEvent.G_MAIN_SHUT);
                gameObject.transform.Find("WaterMainCanvas").gameObject.SetActive(false);
                halo.enabled = false;
                Destroy(gameObject.GetComponent<GMain>()); // does not remain after scene change
            }
            //else if (off)
            //{
            //   prompt.text = "Gas is off.";
            //}
        }
        else
        {
            prompt.text = "You need a wrench to shut off the gas.";
        }
    }
}
