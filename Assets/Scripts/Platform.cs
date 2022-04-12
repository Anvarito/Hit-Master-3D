using System;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform wayPoint;

    public static Action OnPlatformComplete;
    private List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        foreach(Transform t in transform)
        {
            Enemy enemy;
            if(t.TryGetComponent(out enemy)){
                enemies.Add(enemy);
            }
        }
    }

    public Vector3 GetWayPoint()
    {
        return wayPoint.position;
    }
    public void CompleteCheker()
    {
        if (IsComplete())
            OnPlatformComplete?.Invoke();
    }

    [ContextMenu("C")]
    public bool IsComplete()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; ++i)
            {
                if (!enemies[i].IsDeadStatus())
                {
                    return false;
                }
            }
        }

        return true;
    }
}
