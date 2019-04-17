using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRandomizer : MonoBehaviour, IGameManager
{
    private float gasLeak;

    private  float gasExplosion;

    private float RainBucket;

    private int waterLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public  void rollExpo()
    {
        if (Managers.quake&& gasLeak <.5)
        {
            gasExplosion = Random.value;
            
        }

       // return gasExplosion;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public ManagerStatus status { get; }
    public void Startup()
    {
        gasLeak = Random.value;
        
        throw new System.NotImplementedException();
    }
}
