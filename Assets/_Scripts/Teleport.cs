using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Teleports Player to random location after Quake is initiated
 */
public class Teleport : MonoBehaviour
{
    // Character x, y, z positions
    private Transform player;
    // Teleport string for GameObjects
    private string location;
    // int value to attach to Teleport string
    private int n;
    // Random teleport GameObject
    private GameObject tel;
    // GameObject that contains all Teleport GameObjects
    public GameObject teleport;
    // QuakeStart GameObject in Mangers prefab
    public GameObject quake;

    /**
     * On awake, sets disables script and picks a random location to teleport to
     */
    private void Awake()
    {
        gameObject.GetComponent<Teleport>().enabled = false;
        n = Random.Range(1, 6);
        location = "Teleport" + n;
        tel = teleport.transform.Find(location).gameObject;
    }

    /**
     * On start, teleports player to location set in Awake, and enables Quake script
     */
    void Start()
    {
        if (n <= 3)
        {
            Managers.Level.GoToScene("HouseInterior");
        } else if (n >= 4)
        {
            Managers.Level.GoToScene("StreetScene");
        }

        player = gameObject.transform;
        player.position = tel.transform.position;
        gameObject.GetComponent<Teleport>().enabled = false;
        quake.GetComponent<Quake>().enabled = true;
    }
}
