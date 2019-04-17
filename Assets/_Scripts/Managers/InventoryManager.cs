using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    //key is the name of object value is price of object
    public ManagerStatus status { get; private set; } //allows for global read but private write
    public List<string> items;
    private List<int> itemprices;
    public GameObject pre;
    public Transform dsite;

    /// <summary>
    /// Startup this instance.
    /// stores pickups and resources in dictionary [string,int]
    /// this allows for item stacking if there are multiples
    /// access through the Managers script
    /// </summary>
    public void Startup()
    {
        Debug.Log("Inventory starting ");
        items = new List<string>();//<string>();
       itemprices = new List<int>();
        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {

        string itemDisplay = "Items: ";
        foreach (string g in items)
        {
            itemDisplay += g+" ";
        }
        Debug.Log(itemDisplay);
    }

    public void drop(string item)
    {
        
        //pre.name = item;
        Vector3 s = dsite.position;
        s.y += (float).5;
       GameObject drop = Instantiate(pre,s,dsite.rotation);// drop = I;
       drop.name = item;
           int d = items.LastIndexOf(item);
                items.RemoveAt(d);
            Managers.Player.takeAction();
        DisplayItems();

    }

    public void RemoveItem(string item)
    {
        items.Remove(item);
    }
    /// <summary>
    /// Adds the item to inventory.
    /// Use for bottomless store inventory 
    /// </summary>
    /// <param name="name">Name of item to be added this comes form the Collect script .</param>
    public void AddItem(string name, int value)

    {
        items.Add(name);
        Debug.Log(name+ items.ToString());

        itemprices.Add(value);
        //Managers.Player.takeAction();
        DisplayItems();
    }
/// <summary>
/// use for limited palyer inventory
/// </summary>
/// <param name="name"></param>
    public void AddItem(string name)
    {
        if (items.Count < 4)
        {
            items.Add(name);
            Managers.Player.takeAction();

        }
        else
        {
           Debug.Log("I cant carry any more"); 
        }
        // Debug.Log(name + items.LastIndexOf(name)) ;

        //DisplayItems();
    }

    public List<string> GetItemList()
    {
        return items ;//list of all our itemsitems
    }


}
