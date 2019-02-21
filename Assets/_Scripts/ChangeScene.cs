using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	
    private void OnTriggerEnter (Collider sceneTrigger)
    {
        //When your Character collides with the box collider
        if(sceneTrigger.CompareTag("DoorToStreet"))
        {
            SceneManager.LoadScene("StreetScene", LoadSceneMode.Additive);
        }
    }

}
