using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPause : MonoBehaviour
{

    public Canvas canvas;
    public bool debounce;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
        debounce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !debounce)
        {
            debounce = true;
            canvas.enabled = !canvas.enabled;
        } else if (Input.GetKeyUp(KeyCode.Escape))
        {
            debounce = false;
        }
    }
}
