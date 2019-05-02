using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
/// <summary>
/// this script is depreicated do not use
/// </summary>
public class InventoryPopup : MonoBehaviour
{
   /// <summary>
  
   /// </summary>
    public Image prefab;
    public Image Inven;
    //private Image[] slots;
    [SerializeField] private Button DropButton;
    [SerializeField] private Button UseButton;

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
    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        RefresH();
    }
    /// <summary>
    /// clearse and redrwas
    /// </summary>
    public void RefresH()
    {
        clear();
        GetList();
    }


    /// <summary>
    /// removes all items from the canavas used so that things are redrawn each time its opened
    /// </summary>
    void clear()
    
    {
        int c = Inven.transform.childCount;
        for (int i = c - 1; i >= 0; i--)
        {
            Destroy(Inven.transform.GetChild(i).gameObject);
        }
    }
    /// <summary>
    /// clears screen when its closed
    /// </summary>
    private void OnDisable()
    
    {

        Debug.Log("ondiable");


        clear();
    }

    /// <summary>
    /// get list of all items on player
    /// </summary>
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
