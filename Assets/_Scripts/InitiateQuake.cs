﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateQuake : MonoBehaviour
{

    public int count;
    public int check;
    public float time;


    private void Awake()
    {
        check = Random.Range(8, 12);
        time = 7;
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
        }
    }
}