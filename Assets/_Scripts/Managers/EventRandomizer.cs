using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRandomizer : MonoBehaviour, IGameManager
{
    private float gasLeak;

    private  float gasExplosion;

    private float RainBucket;

    private int waterLevel;
    private double storeStable;
    private double houseStable;
    //if ture then explosion will happen
    private bool Gexpo=true;

    // Start is called before the first frame update
    void Start()
    {
      Messenger.AddListener(GameEvent.ACTION_TAKEN,rollExpo);  
      Messenger.AddListener(GameEvent.ACTION_TAKEN,rollHouse);
      Messenger.AddListener(GameEvent.G_MAIN_SHUT,stopExpo);
    }

    private void stopExpo()
    {
        Gexpo = false;
    }


    private void rollHouse()
    {
        if (Managers.quake && houseStable < .5)
        {
            Messenger.Broadcast(GameEvent.SAFE);
            gasExplosion = Random.value;
            if (gasExplosion < .1)
            {
                Messenger.Broadcast(GameEvent.COLLAPSE);
            }
        }
     //   throw new NotImplementedException();

    }

    public  void rollExpo()
    {
        if (Managers.quake&& gasLeak <.5&&Gexpo)
        {
            gasExplosion = Random.value;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public ManagerStatus status { get; private set; }

    /// <summary>
    /// assigns the random values  for the stability of the house and likley hood of gas main
    /// </summary>
    public void Startup()
    {
        gasLeak = Random.value;
        houseStable= Random.value;
        status = ManagerStatus.Started;

       // throw new System.NotImplementedException();
    }
}
