using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGUI : MonoBehaviour
{
    [SerializeField] private PopupScript menu;
    private void Start()
    {

        menu.Close();
    }

    private void Update()
    {
        OnGUI();
    }
    private void OnGUI()
    {
        
         if(Input.GetKeyDown(KeyCode.I))
        {
            if (menu.isActiveAndEnabled)
            {
                menu.Close();
            }
            else {
                menu.Open();
            }
        }
    }
}
