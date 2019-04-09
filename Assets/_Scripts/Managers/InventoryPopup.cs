using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InventoryPopup : MonoBehaviour
{
   
    public Image prefab;
    public Image Inven;
    //private Image[] slots;

    void Start()
    {

    }
    /// <summary>
    /// On the opening of athe inventory its set up
    /// </summary>
    private void OnEnable()
    {
        Debug.Log(Managers.Inventory.GetItemList().Count);
        this.GetList();

    }
    private void Update()
    {
        Refresh();
    }
    public void Refresh()
    {
        clear();
        GetList();
    }
    void clear()
    {
        int c = Inven.transform.childCount;
        for (int i = c - 1; i >= 0; i--)
        {
            Destroy(Inven.transform.GetChild(i).gameObject);
        }
    }
    private void OnDisable()
    {

        Debug.Log("ondiable");


        clear();
    }

    private void GetList()
    {
        //  int len = Managers.Inventory.GetItemList().Count;

        List<string> items = Managers.Inventory.GetItemList();
        int len = items.Count;
        for (int i = 0; i < len; i++)
        {
            //slots[i] =
            Image slot = Instantiate(prefab);
            //  slots[i] = slot;
            slot.transform.SetParent(Inven.transform, false);
            Text[] mess = slot.GetComponentsInChildren<Text>();
            mess[0].text = items[i];
            slot.color = Color.cyan;
            slot.sprite = (Sprite)Resources.Load(items[i], typeof(Sprite));
            //slot.sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/popup", typeof(Sprite));
        }
    }
}
