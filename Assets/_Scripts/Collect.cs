using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Collect script to be given to all collectable objects adds them to player inventory via Manager System.
/// </summary>
//script for all collectable items to add them to inventory
public class Collect : MonoBehaviour
{
  /// <summary>
  /// name of item this is set in the inspector when the scripts is added to an object
  /// </summary>
  [SerializeField] private string itemName;
    /// <summary>
    /// Adds the trigger object to plays inventory then delets it form game world
    /// </summary>
    /// <param name="other">Other.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("picked up");
        Managers.Inventory.AddItem(itemName);

        Destroy(this.gameObject);
    }
}
