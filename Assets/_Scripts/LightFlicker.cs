using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light light;
    bool active = false;

    IEnumerator YieldFlicker()
    {
        active = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 4f));
        light.enabled = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0f, 0.1f));
        light.enabled = false;
        active = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetComponent<Light>();
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(light.enabled);
        if (!active)
        {
            StartCoroutine(YieldFlicker());
        }
    }
}
