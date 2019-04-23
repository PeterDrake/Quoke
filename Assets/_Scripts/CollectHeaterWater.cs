using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectHeaterWater : MonoBehaviour
{
    private Behaviour halo;
    //GameObject prompt = new GameObject();
    [SerializeField] public Text prompt;
    private List<string> items;
    private bool waterCollectionMethod;
    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        items = Managers.Inventory.GetItemList();
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
    }

    private void OnTriggerEnter(Collider other)
    {
        waterCollectionMethod = items.Contains("jug");
        prompt.gameObject.SetActive(true);
        halo.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.gameObject.SetActive(false);
        halo.enabled = false;
    }
    /// <summary>
    /// when the mouse is over the object it is glowed and if the user presses action button 'E' the item is picked up
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        //if (GameEvent.MAINSHUT) // check if main is shut
        //{
        if (waterCollectionMethod)
        {
            prompt.text = "Press [E] to collect water."; //add else if statements to fix text
            if (Input.GetKeyDown(KeyCode.E))
            {
                Managers.Inventory.removeItem("jug");
                Managers.Inventory.AddItem("jug(DIRTY)");
            }
        }
        else
        {
            prompt.text = "The bucket is full, but you don't have a way to store the water!";
        }
        //}
    }
}