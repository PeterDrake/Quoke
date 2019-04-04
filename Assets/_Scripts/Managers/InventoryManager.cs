using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    //key is the name of object value is price of object
    public ManagerStatus status { get; private set; } //allows for global read but private write
    public List<string> items;
    private List<int> itemprices;

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
            itemDisplay += g;
        }
        Debug.Log(itemDisplay);
    }

    /// <summary>
    /// Adds the item to inventory.
    /// </summary>
    /// <param name="name">Name of item to be added this comes form the Collect script .</param>
    public void AddItem(string name, int value)

    {
        items.Add(name);
        itemprices.Add(value);
        Managers.Player.takeAction();
        DisplayItems();
    }

    public List<string> GetItemList()
    {
        return items ;//list of all our itemsitems
    }

    //public int GetItemCount(string name)
    //{
    //    if (items.ContainsKey(name))
    //    {
    //        return items[name];
    //    }
    //    return 0;
    //}

}
