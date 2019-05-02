using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ShoppingPopup : MonoBehaviour
{
   // private string[] recs = new string[] { "bleach", "tent", "wrench", "tools", "bucket", "bags", "shovel", "pick", "sawdust", "hand sanitizer" };

    public Image prefab;
    public Image Inven;

    void Start()
    {

    }
    /// <summary>
    /// On the opening of the shopping menu, the list of items is set up
    /// </summary>
    private void Awake()
    {
        Debug.Log(StoreManager.SInventory.GetItemList().Count);
        this.GetList(StoreManager.SInventory); 
    }

    /// <summary>
    /// sets up slots in shopping menu with an image of an item and text to describe its name and price
    /// </summary>
    private void GetList(InventoryManager inventory)
    {        
        List<string> items =inventory.GetItemList();
        int len = items.Count;
        for (int i = 0; i < len; i++)
        {
            Image slot = Instantiate(prefab);
            slot.transform.SetParent(Inven.transform, false);
            Text [] mess =slot.GetComponentsInChildren<Text>();
            mess[0].text = items[i];
            mess[1].text =  StoreManager.recsp[i].ToString();
            slot.color = Color.cyan;
            slot.name = items[i];
            slot.sprite = (Sprite)Resources.Load(items[i], typeof(Sprite));
        }
    }
}
