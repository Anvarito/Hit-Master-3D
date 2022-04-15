using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<Platform> platforms;
    private int numberPlatform = 0;
    public Player player;
    public CameraBahaviour cameraBahaviour;
    private Platform currentPlatform;

    private void Start()
    {
        currentPlatform = platforms[0];
    }

    public void PlayerReachedPoint()
    {
        if (currentPlatform != null)
            currentPlatform.PointHasBeenReach();
    }

    public void NextPlatform()
    {
        numberPlatform += 1;
        if (numberPlatform >= platforms.Count)
        {
            SceneManager.LoadScene(0);
            return;
        }

        currentPlatform = platforms[numberPlatform];
        player.SetNewWayPoint(currentPlatform.GetWayPoint().position);
        cameraBahaviour.SetLookAt(currentPlatform.GetWayPoint());

    }
}
