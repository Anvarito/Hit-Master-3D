using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform wayPoint;

    public static Action OnPlatformComplete;
    private Enemy[] enemies;

    private void Start()
    {
        enemies = GetComponentsInChildren<Enemy>();
    }

    public Vector3 GetWayPoint()
    {
        return wayPoint.position;
    }
    public void CompleteChecked()
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            if (!enemies[i].IsDeadStatus())
            {
                return;
            }
        }

        OnPlatformComplete?.Invoke();
    }
}
