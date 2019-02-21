using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public float speed;
    public Text winText;
    public Text countText;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    private void Update()//game code here
    {

    }
    private void FixedUpdate()//physics code here
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       
        rb.AddForce(movement*speed);


    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count > 7)
        {
            winText.text = "You're A Winner";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) { 
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        //Destroy(other.gameObject);
    } 
}
