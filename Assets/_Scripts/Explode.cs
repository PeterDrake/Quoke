using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;

    private void OnMouseDown()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        explosion.GetComponent<Light>().enabled = false;
    }
}
