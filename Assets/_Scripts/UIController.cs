using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isOpen = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isOpen);
            //popup.Refresh();
        }
    }

    private void OnConditionUpdate()
    {
        string message = "Health: " + Managers.Player.health;
        winConditions.text = message;
    }
}
