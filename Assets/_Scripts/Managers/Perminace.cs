using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perminace : MonoBehaviour, IGameManager
{
    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener(GameEvent.W_MAIN_SHUT,fW);
        Messenger.AddListener(GameEvent.G_MAIN_SHUT,fG);
        Messenger.AddListener(GameEvent.SEC,fB);
        //Messenger.AddListener(GameEvent.);
    }

    public bool fw { get;private set;  }
    public bool fg{ get; private set; }
    public bool fb{ get; private set; }
    
    private void fB()
    {
        fb = true;
    }

    private void fG()
    {
        fg = true;
    }

    private void fW()
    {
        fw = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        
    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        status = ManagerStatus.Started;
    }
}
