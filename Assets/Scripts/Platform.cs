using System;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform wayPoint;

    public static Action OnPlatformComplete;
    private List<Enemy> enemies = new List<Enemy>();

    private LevelManager levelManager;
    private bool isReach = false;
    private bool platformClear = false;

    private void Awake()
    {
        enemies.AddRange(GetComponentsInChildren<Enemy>());
        levelManager = GetComponentInParent<LevelManager>();
    }

    public Transform GetWayPoint()
    {
        return wayPoint;
    }

    public void PointHasBeenReach()
    {
        isReach = true;
        CompleteCheker();
    }
    public void CompleteCheker()
    {
        var name = transform.name;
        if (IsComplete() && isReach /*&& !platformClear*/)
        {
            levelManager.NextPlatform();
            //platformClear = true;
        }
    }

    public bool IsComplete()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; ++i)
            {
                if (!enemies[i].isDead)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
