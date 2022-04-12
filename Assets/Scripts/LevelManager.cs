using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Platform[] platforms;
    private int numberPlatform = 0;
    public Player player;

    void Start()
    {
        platforms = GetComponentsInChildren<Platform>();
        Platform.OnPlatformComplete += NextPlatform;
        NextPlatform();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void NextPlatform()
    {
        numberPlatform++;
        if (numberPlatform >= platforms.Length)
        {
            // restart game
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
