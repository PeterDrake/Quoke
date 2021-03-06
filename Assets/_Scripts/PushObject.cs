﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{

    public float pushAmount = 100f;
    public float pushDirection = 1f;
    public Boolean isReinforced = false;
    private Rigidbody rigidbody;
    
    // On awake, sets script to false and gets RigidBody of GameObject
    void Awake()
    {
        Messenger.AddListener(GameEvent.SEC,enforce);

        gameObject.GetComponent<PushObject>().enabled = false;
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Sets isReinforced boolean to true
    void enforce()
    {
        isReinforced = true;
    }
    
    // On start, pushes object over
    void Start()
    {
        if (!isReinforced)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().AddForce(pushDirection * transform.forward * pushAmount, ForceMode.Acceleration);
            //GetComponent<Rigidbody>().AddExplosionForce(1000f,transform.position,50f,30f); //for fun
            GetComponent<Rigidbody>().useGravity = true;
            //rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.GetComponent<PushObject>().enabled = false;
        }
    }

}
