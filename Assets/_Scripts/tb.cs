using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tb : MonoBehaviour
{
    // Start is called before the first frame update
    // private int[] prices;
    //public int i;

    private void Update()
    {

    }
    void OnClick()
    { //what to put in [0]
        int i;
        for (i = 0; i < StoreManager.recs.Length; i++)
        {
            if (StoreManager.recs[i].Equals(this.name))
            {
                break;
            }
        }
        if (Managers.Player.cash >= StoreManager.recsp[i])
        {
            Managers.Player.cash -= StoreManager.recsp[i];
            Managers.Inventory.AddItem(StoreManager.recs[i], StoreManager.recsp[i]);
        }

    }

}
