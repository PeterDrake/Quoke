using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRandomizer : MonoBehaviour, IGameManager
{
    private float gasLeak;

    private float gasExplosion;

    private float RainBucket;

    private int waterLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ManagerStatus status { get; }
    public void Startup()
    {
        throw new System.NotImplementedException();
    }
}
