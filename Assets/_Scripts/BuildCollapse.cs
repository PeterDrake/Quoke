using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCollapse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener(GameEvent.COLLAPSE,kill);
       // Messenger.AddListener(GameEvent.SHELTER, survive);
    }
//void su
    void kill()
    {
        Messenger.Broadcast(GameEvent.HEALTH_CHANGED);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
