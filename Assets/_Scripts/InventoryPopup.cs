using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InventoryPopup : MonoBehaviour
{
    [SerializeField] private Text[] labels;
    [SerializeField] private Image[] icons;
    [SerializeField] private Text curItemLable;
    //[SerializeField] private Button equip
    [SerializeField] private Button use;
    [SerializeField] private string curItem;
    // Start is called before the first frame update

    void Start()
    {

    }
    public void Refresh()
    {
        List<string> items = Managers.Inventory.GetItemList();// list of items in player inventory

        int len = icons.Length;
        for (int i = 0; i < len; i++)
        {
            if (i < items.Count) //makes sure there is items to disply
            {   //make the item visible in the inventory popup
                labels[i].gameObject.SetActive(true);
                icons[i].gameObject.SetActive(true);
                string item = items[i];

                //loadin item icons from resources folder @param file path to item texture
                Sprite sprite = null;// = Resources.Load<Sprite>();
                icons[i].sprite = sprite;
                icons[i].SetNativeSize();
                int icount = Managers.Inventory.GetItemCount(item);
                string message = "x" + icount;
                //can put equiped checks here if we want to have equipables
                labels[i].text = message;

                //event listeners for clicking on icons
                EventTrigger.Entry enter = new EventTrigger.Entry();
                enter.eventID = EventTriggerType.PointerClick;
                enter.callback.AddListener((BaseEventData arg0) => { onItem(item); });

                EventTrigger trigger = icons[i].GetComponent<EventTrigger>();
                trigger.triggers.Clear();
                trigger.triggers.Add(enter);
            }
            else
            {
                icons[i].gameObject.SetActive(false);
                labels[i].gameObject.SetActive(false);
            }
        }
        if (!items.Contains(curItem))
        {
            curItem = null;
        }
        if (curItem == null)//if nothing is selcted hide buttons
        {
            curItemLable.gameObject.SetActive(false);
            use.gameObject.SetActive(false);
        }
        else
        {
            curItemLable.gameObject.SetActive(true);
            use.gameObject.SetActive(true);
            curItemLable.text = curItem + ":";
        }
    }




    void onItem(string item)
    {
        curItem = item;
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
