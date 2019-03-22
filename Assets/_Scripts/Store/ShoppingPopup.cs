using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ShoppingPopup : MonoBehaviour
{
   // private string[] recs = new string[] { "bleach", "tent", "wrench", "tools", "bucket", "bags", "shovel", "pick", "sawdust" };

    public Image prefab;
    public Image Inven;
    public Image linebreak;
    //private Image[] slots;

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

        //add devider between plaer and store objs
        //  OnGUI();
        //GUILayout.Label("____________________________________________________________________");

        this.GetList(Managers.Inventory);

    }
     void OnGUI()
    {
        GUILayoutOption[]  s = new GUILayoutOption[4];

        GUILayout.Label("____________________________________________________________________");
    }//*/

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
            slot.color = Color.cyan;
            slot.sprite = (Sprite)Resources.Load(items[i], typeof(Sprite));
            //slot.sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/popup", typeof(Sprite));
        }
    }
}
