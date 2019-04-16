using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{

    public float pushAmount = 100f;
    public float pushDirection = 1f;
    public Boolean isReinforced = false;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (!isReinforced)
        {
            GetComponent<Rigidbody>().AddForce(pushDirection * transform.forward * pushAmount, ForceMode.Acceleration);
            //GetComponent<Rigidbody>().AddExplosionForce(1000f,transform.position,50f,30f); //for fun
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
