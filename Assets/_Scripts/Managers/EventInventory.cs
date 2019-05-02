using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EventInventory : MonoBehaviour
{
    [SerializeField] private Image[] icons;
    [SerializeField] private Text[] labels;
    [SerializeField] private Button useBotton;
    [SerializeField] private Button dropBotton;
    [SerializeField] private Text curILabel;

    private string cur_item;
/// <summary>
/// redraws the inventory
/// </summary>
    public void Refresh()
    {
        List<string> itemList = Managers.Inventory.GetItemList();
        int len = icons.Length;
        if (!itemList.Contains(cur_item))
        {
            cur_item = null;
        }
        for (int i = 0; i < len; i++) //for item in the inventory 
        {
            if (i < itemList.Count)
            {
                icons[i].gameObject.SetActive(true);
                labels[i].gameObject.SetActive(true);//set them to be visible

                string item = itemList[i];//name of item

                Sprite sprite = Resources.Load<Sprite>(item); //load up item icon

                icons[i].sprite = sprite;//set inventory position with item icon and name
               // icons[i].SetNativeSize();

                labels[i].text = item;

                //Event based things below here
                EventTrigger.Entry enter = new EventTrigger.Entry();
                enter.eventID = EventTriggerType.PointerClick;
                enter.callback.AddListener((BaseEventData data) =>
                {
                    onItem(item);
                });
                EventTrigger trigger = icons[i].GetComponent<EventTrigger>();
                trigger.triggers.Clear();
                trigger.triggers.Add(enter);
            }
            else
            {
                //if we done have a full inventorty
                icons[i].gameObject.SetActive(false);
                labels[i].gameObject.SetActive(false);//set them to be invisible }
            }
        }
       
        if (cur_item == null)//if no item selected hid drop button
        {
            curILabel.gameObject.SetActive(false);
            dropBotton.gameObject.SetActive(false);
            useBotton.gameObject.SetActive(false);
        }
       
        else
        {
            curILabel.gameObject.SetActive(true);
            dropBotton.gameObject.SetActive(true);     
            if (cur_item=="jug(DIRTY)" && (Managers.Inventory.GetItemList().Contains("iodine") ||
                                                  Managers.Inventory.GetItemList().Contains("bleach")))
            {
                useBotton.gameObject.SetActive(true);
            }
            else
            {
                useBotton.gameObject.SetActive(false);
            }
            curILabel.text = cur_item + ":";

        }


    }
/// <summary>
///
/// set item label
/// </summary>
/// <param name="item"></param>
    public void onItem(string item)
    {
        cur_item = item;
        Refresh();
    }
/// <summary>
/// drops item from inventory and spwans in world 
/// </summary>
    public void onDrop()
    {
        Debug.Log(cur_item);
        Managers.Inventory.drop(cur_item);
        Refresh();
    }

/// <summary>
/// puifies water in inventory
/// </summary>
    public void onUse()
    {
        Managers.Inventory.removeItem("jug(DIRTY)");
        if (Managers.Inventory.GetItemList().Contains("iodine"))
        {
            Managers.Inventory.removeItem("iodine");
        }
        else if (Managers.Inventory.GetItemList().Contains("bleach"))
        {
            Managers.Inventory.removeItem("bleach");
        }
        else
        {
            Debug.Log("AHHHHH");
        }
        Managers.Inventory.AddItem("jug(CLEAN)");
        Messenger.Broadcast(GameEvent.WATER);
        Refresh();
    }
    // Start is called before the first frame update
    void Start()
    {
        Refresh();   
    }

    // Update is called once per frame
    void Update()
    {
      Refresh();   
    }
}
