using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    // Start is called before the first frame update
    // private int[] prices;
    //public i


    public void OnClick()
    {
         
        int i;
        for (i = 0; i < StoreManager.recs.Length; i++) {
            if (StoreManager.recs[i].Equals(this.name)){
                break;
            }
        }
        if (Managers.Player.cash>= StoreManager.recsp[i])
        {
            Managers.Player.cash -= StoreManager.recsp[i];
           
            Managers.Inventory.AddItem(StoreManager.recs[i]);
           // pop.Refresh();

        }

    }

}
