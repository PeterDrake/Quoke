using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; } //allows for global read but private write
    private Dictionary<string, int> items;

    /// <summary>
    /// Startup this instance.
    /// stores pickups and resources in dictionary [string,int]
    /// this allows for item stacking if there are multiples
    /// access through the Managers script
    /// </summary>
    public void Startup()
    {
        Debug.Log("Inventory starting ");
        items = new Dictionary<string, int>();//<string>();
        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, int> g in items)
        {
            itemDisplay += g.Key + "[" + g.Value + "]";
        }
        Debug.Log(itemDisplay);
    }

    /// <summary>
    /// Adds the item to inventory.
    /// </summary>
    /// <param name="name">Name of item to be added this comes form the Collect script .</param>
    public void AddItem(string name)

    {
        if (items.ContainsKey(name))
        {
            items[name] += 1;//stacks items
        }
        else
            items[name] = 1;//if new item creat new stack
        DisplayItems();
    }

    public List<string> GetItemList()
    {
        return new List<string>(items.Keys);//list of all our items
    }

    public int GetItemCount(string name)
    {
        if (items.ContainsKey(name))
        {
            return items[name];
        }
        return 0;
    }

}
