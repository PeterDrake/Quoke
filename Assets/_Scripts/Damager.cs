
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    public class Damager:MonoBehaviour
    {
        private bool trigg;
        //private Collider o;
        private void Awake()
        {
            gameObject.GetComponent<Damager>().enabled = false;
            trigg = gameObject.GetComponent<Damager>().enabled;
            Messenger.AddListener(GameEvent.SEC,des);

        }

        void des()
        {
            Destroy(gameObject.GetComponent<Damager>());
        }
        private void OnTriggerEnter(Collider other)
        {
            //o = other;
            Debug. Log(trigg);
            if (other.gameObject.tag.Equals("Player")&&trigg)
            {
                Messenger.Broadcast(GameEvent.HEALTH_CHANGED);
            }
           // trigg=true;
        }

        private void Start()
        {
            
        }


        void Update()
        {
            
        }
    }
