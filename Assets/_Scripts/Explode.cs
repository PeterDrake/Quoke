using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;

    private void Start()
    {
        Messenger.AddListener(GameEvent.G_MAIN_EXPO,expo);
    }

    private void expo()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        explosion.GetComponent<Light>().enabled = false;
        Messenger.Broadcast(GameEvent.HEALTH_CHANGED);
    }
}
