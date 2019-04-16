using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateQuake : MonoBehaviour
{

    private int count;
    private int check;
    public float time;
    public GameObject player;


    private void Awake()
    {
        check = Random.Range(8, 12);
        time = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Find("Transition").gameObject.SetActive(false);
        count = Managers.Player.actionCount;
        if (count >= check)
        {
            gameObject.transform.Find("Transition").gameObject.SetActive(false);
            gameObject.GetComponent<InitiateQuake>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        count = Managers.Player.actionCount;
        if (count >= check && time > 0)
        {
            gameObject.transform.Find("Transition").gameObject.SetActive(true);
            time -= Time.deltaTime;

        } else if (time <= 0)
        {
            gameObject.transform.Find("Transition").gameObject.SetActive(false);
            player.GetComponent<Teleport>().enabled = true;
        }
    }
}
