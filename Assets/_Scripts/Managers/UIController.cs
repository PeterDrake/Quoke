<<<<<<< HEAD:Assets/_Scripts/Managers/UIController.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{   //conditional display of win conditions
  // [SerializeField] private Text winConditions;
   [SerializeField] private InventoryPopup popup;
    // Start is called before the first frame update
    public Text statusText;
    public Text statusUpdate;
    void Start()
    {
        popup.gameObject.SetActive(false);
        SetText();  
    }

    // Update is called once per frame
    void Update()
    {  // Managers.Player.S
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{   //conditional display of win conditions
   [SerializeField] private Text winConditions;
   [SerializeField] private InventoryPopup popup;
    // Start is called before the first frame update
   
    void Start()
    {
        popup.gameObject.SetActive(false);     
    }

    // Update is called once per frame
    void Update()
    {  // Managers.Player.S
>>>>>>> master:Assets/_Scripts/UIController.cs
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isOpen = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isOpen);
            //popup.Refresh();
        }
    }

    private void OnConditionUpdate()
    {
<<<<<<< HEAD:Assets/_Scripts/Managers/UIController.cs
        string message = "Health: " + Managers.Player.health;
        //winConditions.text = message;
    }
    public void SetText()
    {
        statusText.text = "WATER:" + Managers.Player.water.ToString() + " \n"+
                          "HEALTH:" + Managers.Player.health.ToString() + " \n"+
                          "SHELTER:" + Managers.Player.shelter.ToString() +" \n";
    }
}
=======
        string message = "Health: " + Managers.Player.health;
        winConditions.text = message;
    }
}
>>>>>>> master:Assets/_Scripts/UIController.cs
