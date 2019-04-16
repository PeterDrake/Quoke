using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour, IGameManager
{
    // Start is called before the first frame update
    public ManagerStatus status { get; private set; }
    public int curlevel { get; private set; }
    public int maxLevel { get; private set; }
    public void Startup()
    {
        Debug.Log("Loading Levels");
        curlevel = 0;
        status = ManagerStatus.Started;
    }
    /// <summary>
    /// generic transistion that simply goes to next scene in build order
    ///
    /// </summary>
    public void GoToNext()
    {
        curlevel++;
        SceneManager.LoadScene(curlevel);
        SceneManager.UnloadScene(curlevel-1);
        Managers.Player.takeAction();

        Debug.Log(curlevel);
    }
    /// <summary>
    /// goes to scene based build order
    /// the build order should be 
    /// 0 systems scene 
    /// 1 house scene
    /// 2 street scene
    /// 3 store scene
    /// if this is not what the build order looks like then you will have issues
    /// change you build order to match if needed
    /// </summary>
    /// <param name="scene">Scene in build order to load.</param>
    public void GoToScene(int scene)
    {
        curlevel = scene;
        Debug.Log(SceneManager.GetSceneByBuildIndex(curlevel).name);
        SceneManager.LoadScene(curlevel);
        Managers.Player.takeAction();
    }
    /// <summary>
    /// goes to scene  based on passed string 
    /// scene must be in bulid order for this to work
    /// </summary>
    /// <param name="scene">Scene in build order to load.</param>
    public void GoToScene(string scene)
    {   
         SceneManager.LoadScene(scene);
         Managers.Player.takeAction();

       // curlevel= SceneManager.GetActiveScene.
        ///curlevel = scene;
       // Debug.Log(SceneManager.GetSceneByBuildIndex(curlevel).name);
    }
}