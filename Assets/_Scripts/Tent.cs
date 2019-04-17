using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Tent : MonoBehaviour
{
    public GameObject tent;

    public Text promt;   
    // Start is called before the first frame update
    void Start()
    {
        promt.gameObject.SetActive(false);
        promt.text = " press [E] to pitch tent ";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Managers.Inventory.GetItemList().Contains("tent"))
        {
            promt.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Vector3 ts = this.gameObject.transform.position;
                ts.x = 15;
                ts.z = 12;
                ts.y = 0;
                Quaternion rs = new Quaternion();
                
               /* rs.y = 0;
                rs.z = 45;
                rs.x = 0;*/
                GameObject pt = Instantiate(tent,ts,rs);

                pt.transform.Rotate(new Vector3(0, 0, 45));
                //pt.transform.localScale(new Vector3(2.5, 2.5, 3));
                Managers.Player.ChangeShelter();
                Managers.Inventory.RemoveItem("tent");
                
                    
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        promt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
