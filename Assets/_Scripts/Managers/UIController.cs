
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{   //conditional display of win conditions
  // [SerializeField] private Text winConditions;
   [SerializeField] public  EventInventory popup;
    // Start is called before the first frame update
    public static EventInventory pop;
    public Text statusText;

    void Start()
    {
        pop = popup;
        popup.gameObject.SetActive(false);
        SetText();  
    }

    // Update is called once per frame
    void Update()
    {  // Managers.Player.S
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isOpen = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isOpen);
            //popup.Refresh();
        }
        SetText();
    }

    private void OnConditionUpdate()
    {
        string message = "Health: " + Managers.Player.health;
        //winConditions.text = message;
    }

    public void SetText()
    {
        statusText.text = "WATER: " + Managers.Player.water.ToString() + " \n"+
                          "HEALTH: " + Managers.Player.health.ToString() + " \n"+
                          "SHELTER: " + Managers.Player.shelter.ToString() +" \n"+
                          "CASH: " + Managers.Player.cash+ " \n" +
                          "OWNER: "+ Managers.Player.homeOwner + "\n";

    }
}
