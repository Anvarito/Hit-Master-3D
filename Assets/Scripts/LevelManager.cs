using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Platform[] platforms;
    private int numberPlatform = 0;
    public Player player;

    void Start()
    {
        Platform.OnPlatformComplete += NextPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextPlatform()
    {
        numberPlatform++;
        if (numberPlatform >= platforms.Length)
            numberPlatform = 0;
        player.SetNewWayPoint(platforms[numberPlatform].GetWayPoint());
    }
}
