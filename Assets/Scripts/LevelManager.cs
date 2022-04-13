using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<Platform> platforms;
    private int numberPlatform = 0;
    public Player player;

    private void Awake()
    {

        Application.targetFrameRate = 30;

        Platform.OnPlatformComplete += NextPlatform;
        //foreach (Transform t in transform)
        //{
        //    Platform platform;
        //    if (t.TryGetComponent(out platform))
        //    {
        //        platforms.Add(platform);
        //    }
        //}
    }
    void Start()
    {
    }

    private void NextPlatform()
    {
        numberPlatform++;
        if (numberPlatform >= platforms.Count)
        {
            Platform.OnPlatformComplete -= NextPlatform;
            SceneManager.LoadScene(0);
            return;
        }

        //scip the platfor if it not have an enemy
        if (platforms[numberPlatform].IsComplete())
        {
            NextPlatform();
        }

        player.SetNewWayPoint(platforms[numberPlatform].GetWayPoint());
    }
}
