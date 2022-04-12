using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Platform[] platforms;
    private int numberPlatform = 0;
    public Player player;

    private void OnEnable()
    {
        Platform.OnPlatformComplete += NextPlatform;
    }
    private void OnDisable()
    {
        Platform.OnPlatformComplete -= NextPlatform;
    }

    void Start()
    {
        platforms = GetComponentsInChildren<Platform>();
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
