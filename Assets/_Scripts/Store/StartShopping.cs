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
    [SerializeField] private Text prompt;
    // private Sprite m_CharacterBusinessManSuit01;

    private Behaviour halo;
    private bool isTriggered = false;

    void Awake()
    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo.enabled = false;
        isTriggered = false;
        prompt.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        UIController.pop.gameObject.SetActive(false);
    }

    /// <summary>
    /// opens and closes shopping menu when player collides with cashier trigger and presses 'E'
    /// </summary>
    void Update()
    {
        bool isOpen = popup.gameObject.activeSelf;
        if (Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
            popup.gameObject.SetActive(!isOpen);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ensures halo and text only appear when colliding with cashier trigger
        if (other.gameObject.name != "ThirdPersonController") return;
        isTriggered = true;
        prompt.gameObject.SetActive(true);
        halo.enabled = true;
    }

    /// <summary>
    /// On the mouse exit shuts off the back glow
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        prompt.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        UIController.pop.gameObject.SetActive(false);
        halo.enabled = false;
    }
}
