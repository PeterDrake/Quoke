using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurifyAndCollect : MonoBehaviour
{
    private Behaviour halo;
    [SerializeField] private Canvas prompt;
    Text text;
    private List<string> items;
    private bool purificationMethod;
    private bool waterCollectionMethod;

    // Start is called before the first frame update
    void Start()
    {
        items = Managers.Inventory.GetItemList();
        text = prompt.GetComponent<Text>();
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
    }

    private void OnTriggerEnter(Collider other)
    {
        purificationMethod = items.Contains("iodine tablets") || items.Contains("bleach");
        waterCollectionMethod = items.Contains("jug");
    }

    /// <summary>
    /// when the mouse is over the object it is glowed and if the user presses action button 'E' the item is picked up
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        //if player presses E
        if (Managers.Player.bucketFill)
        {
            if (purificationMethod)
            {
                text.text = "The bucket is full! Press [E] to purify water.";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (waterCollectionMethod)
                    {
                        text.text = "The water is purified! Press [E] to move into inventory.";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Managers.Inventory.removeItem("jug");
                            Managers.Inventory.AddItem("jug (FULL)");
                        }
                    }
                    else
                    {
                        text.text = "The water is purified, but you don't have a way to store it. Go to the store!";
                    }

                }

            }
            else
            {
                text.text = "The bucket is full, but you have no way to purify the water. Go to the store!";
            }
        }
        else
        {
            text.text = "This bucket is empty. Check back later!";
        }
        //print bucket is empty
    }


    // Update is called once per frame
    void Update()
    {

    }
}