using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Collect script to be given to all collectable objects adds them to player inventory via Manager System.
/// </summary>
//script for all collectable items to add them to inventory
public class StartShopping : MonoBehaviour
{
    /// <summary>
    /// name of item this is set in the inspector when the scripts is added to an object
    /// </summary>
    [SerializeField] private ShoppingPopup popup;
    [SerializeField] private Canvas prompt;
    // private Sprite m_CharacterBusinessManSuit01;
    // private bool isOpen;

     void Awake()
    {
        prompt.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;

    }



    /// <summary>
    /// when the mouse is over the object it is glowed and if the user presses action button 'E' the item is picked up
    /// </summary>
     void OnTriggerStay()
    {
        prompt.gameObject.SetActive(true);

        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isOpen = true;
            //Debug.Log("picked up");
            Debug.Log("opens inve");
            Debug.Log(isOpen);
            isOpen = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isOpen);

        }
    }
    /// <summary>
    /// On the mouse exit shuts off the back glow
    /// </summary>
     void OnTriggerExit()
    {
        Behaviour halo = (Behaviour)this.gameObject.GetComponent("Halo");
        prompt.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        halo.enabled = false;
    }
}
