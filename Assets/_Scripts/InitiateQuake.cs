using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateQuake : MonoBehaviour
{

    private int count;
    private int check;
    
    // Start is called before the first frame update
    void Start()
    {
        check = Random.Range(8, 12);
        count = Managers.Player.actionCount;
        if (check >= count)
        {
            gameObject.GetComponent<InitiateQuake>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        count = Managers.Player.actionCount;
        if (count >= check)
        {
            //Managers.Level.GoToScene("Transition");
            //gameObject.GetComponent<InitiateQuake>().enabled = false;
        }
    }
}
