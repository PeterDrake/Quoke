using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurifyAndCollect : MonoBehaviour
{
    private Behaviour halo;
    //GameObject prompt = new GameObject();
    [SerializeField] public Text prompt;
    private List<string> items;
    private bool purificationMethod;
    private bool waterCollectionMethod;
    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        items = Managers.Inventory.GetItemList();
        // Text t = prompt.GetComponent<Text>();
        //prompt.gameObject.SetActive(false);
        //prompt.text = "you have no water";
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        //Debug.Log("Start");

    }

    private void OnTriggerEnter(Collider other)
    {
        purificationMethod = items.Contains("iodine tablets") || items.Contains("bleach");
        waterCollectionMethod = items.Contains("jug");
        prompt.gameObject.SetActive(true);
        halo.enabled = true;
        //Debug.Log("On Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.gameObject.SetActive(false);
        halo.enabled = false;
        //Debug.Log("On Exit");
    }
    /// <summary>
    /// when the mouse is over the object it is glowed and if the user presses action button 'E' the item is picked up
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        //prompt.gameObject.SetActive(true);
        //if player presses E
        if (Managers.Player.bucketFill)
        {
            if (purificationMethod)
            {
                prompt.text = "The bucket is full! Press [E] to purify water."; //add else if statements to fix text
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (waterCollectionMethod)
                    {
                        prompt.text = "The water is purified! Press [E] to move into inventory.";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Managers.Inventory.removeItem("jug");
                            Managers.Inventory.AddItem("jug(FULL)");
                        }
                    }
                    else
                    {
                        prompt.text = "The water is purified, but you don't have a way to store it. Go to the store!";
                    }

                }

            }
            else
            {
                prompt.text = "The bucket is full, but you have no way to purify the water. Go to the store!";
            }
        }
        else
        {
            prompt.text = "This bucket is empty. Check back later!";
        }
        //print bucket is empty
        //Debug.Log("stay");
    }


    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            //prompt.gameObject.SetActive(false);
           // halo.enabled = false;
           // flag = false;
            //Debug.Log("update");
        }
    }
}
