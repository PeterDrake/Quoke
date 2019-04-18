using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    private Transform player;
    public GameObject teleport;
    public GameObject quake;

    private void Awake()
    {
        gameObject.GetComponent<Teleport>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Managers.Level.GoToScene("HouseInterior");
        player = gameObject.transform;
        player.position = teleport.transform.position;
        gameObject.GetComponent<Teleport>().enabled = false;
        quake.GetComponent<Quake>().enabled = true;
    }
}
