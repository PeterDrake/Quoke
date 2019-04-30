using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour
{
    [SerializeField] public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        prompt.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        prompt.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.gameObject.SetActive(false);
    }
}
