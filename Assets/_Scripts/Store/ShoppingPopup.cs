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
    /// On the opening of athe inventory its set up
    /// </summary>
    private void OnEnable()
    {
        Debug.Log(StoreManager.SInventory.GetItemList().Count);


        this.GetList(StoreManager.SInventory);

 
    }


    private void OnDisable()
    {

        Debug.Log("ondiable");
        int c = Inven.transform.childCount;
        for (int i = c - 1; i >= 0; i--)
        {
            Destroy(Inven.transform.GetChild(i).gameObject);
        }


    }
   

    private void GetList(InventoryManager inventory)
    {
        //  int len = Managers.Inventory.GetItemList().Count;
        
        List<string> items =inventory.GetItemList();
        int len = items.Count;
        for (int i = 0; i < len; i++)
        {
            //slots[i] =
            Image slot = Instantiate(prefab);
            //  slots[i] = slot;
            slot.transform.SetParent(Inven.transform, false);
           Text [] mess =slot.GetComponentsInChildren<Text>();
            mess[0].text = items[i];
            mess[1].text =  StoreManager.recsp[i].ToString();
            slot.color = Color.cyan;
            slot.name = items[i];
            slot.sprite = (Sprite)Resources.Load(items[i], typeof(Sprite));
            //slot.sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/popup", typeof(Sprite));
        }
    }
}
