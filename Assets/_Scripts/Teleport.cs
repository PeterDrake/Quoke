using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    private Transform player;
    private string location;
    private GameObject tel;
    public GameObject teleport;
    public GameObject quake;

    /**
     * On awake, sets disables script and picks a random location to teleport to
     */
    private void Awake()
    {
        gameObject.GetComponent<Teleport>().enabled = false;
        var n = Random.Range(4, 6);
        location = "Teleport" + n;
        tel = teleport.transform.Find(location).gameObject;
    }

    /**
     * On start, teleports player to location set in Awake, and enables Quake script
     */
    void Start()
    {
        Managers.Level.GoToScene("StreetScene");
        player = gameObject.transform;
        player.position = tel.transform.position;
        gameObject.GetComponent<Teleport>().enabled = false;
        quake.GetComponent<Quake>().enabled = true;
    }
}
